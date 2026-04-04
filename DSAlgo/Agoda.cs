using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    namespace AgodaInterviewPrep
    {
        // 1. Data Models mapping to the JSON payload and historical rates
        public class BookingData
        {
            [JsonPropertyName("bookingId")]
            public string BookingId { get; set; }

            [JsonPropertyName("hotelName")]
            public string HotelName { get; set; }

            [JsonPropertyName("localPrice")]
            public decimal LocalPrice { get; set; }

            [JsonPropertyName("currency")]
            public string Currency { get; set; }

            [JsonPropertyName("timestamp")]
            public long Timestamp { get; set; }
        }

        public class ExchangeRate
        {
            public long Timestamp { get; set; }
            public decimal Rate { get; set; }
        }

        public class AgodaRevenueCalculator
        {
            private readonly HttpClient _httpClient;

            // Inject HttpClient to allow for easy mocking during Unit Testing
            public AgodaRevenueCalculator(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<decimal> CalculateUsdRevenueAsync(string bookingId, List<ExchangeRate> exchangeRates)
            {
                string url = $"https://mock-api.agoda.com/v1/booking/{bookingId}";
                BookingData booking = null;

                // 2. Fetch and Parse the Data
                try
                {
                    // Note: In a real scenario, this will throw a DNS error since the mock URL doesn't exist
                    HttpResponseMessage response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    booking = JsonSerializer.Deserialize<BookingData>(jsonResponse);
                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Network or HTTP error while fetching booking {bookingId}: {e.Message}");
                }
                catch (JsonException e)
                {
                    throw new Exception($"Failed to parse JSON response for booking {bookingId}: {e.Message}");
                }

                if (booking == null)
                {
                    throw new InvalidOperationException("Booking data deserialized to null.");
                }

                // 3. Find the applicable rate using Binary Search
                decimal applicableRate = GetApplicableRate(exchangeRates, booking.Timestamp);

                // 4. Calculate and return the final USD price
                return booking.LocalPrice * applicableRate;
            }

            /// <summary>
            /// Uses Binary Search to find the most recent exchange rate at or before the booking timestamp.
            /// Assumes the 'rates' list is sorted chronologically by Timestamp.
            /// </summary>
            private decimal GetApplicableRate(List<ExchangeRate> rates, long targetTimestamp)
            {
                if (rates == null || rates.Count == 0)
                    throw new ArgumentException("Exchange rates list cannot be empty.");

                int left = 0;
                int right = rates.Count - 1;
                decimal bestRate = -1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (rates[mid].Timestamp == targetTimestamp)
                    {
                        // Exact match found
                        return rates[mid].Rate;
                    }
                    else if (rates[mid].Timestamp < targetTimestamp)
                    {
                        // This rate is BEFORE the booking, so it's a valid candidate.
                        // However, there might be a closer one to the right, so we save it and keep searching right.
                        bestRate = rates[mid].Rate;
                        left = mid + 1;
                    }
                    else
                    {
                        // This rate is AFTER the booking, which means we can't use it. Search left.
                        right = mid - 1;
                    }
                }

                // Edge case: All exchange rates in the array happened AFTER the booking timestamp
                if (bestRate == -1)
                {
                    throw new InvalidOperationException("No valid exchange rate found for the given booking timestamp. The booking predates our rate records.");
                }

                return bestRate;
            }
        }
    }
}
