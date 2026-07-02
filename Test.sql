	WITH RECURSIVE OrgChart AS (
	    -- 1. Anchor Member: Find the CEO (who has no manager)
	    SELECT 
	        EmployeeID, 
	        Name, 
	        ManagerID, 
	        1 AS Level
	    FROM Employees
	    WHERE ManagerID IS NULL
	
	    UNION ALL
	
	    -- 2. Recursive Member: Join the CTE back to the Employees table
	    SELECT 
	        e.EmployeeID, 
	        e.Name, 
	        e.ManagerID, 
	        oc.Level + 1
	    FROM Employees e
	    INNER JOIN OrgChart oc ON e.ManagerID = oc.EmployeeID
	)
	-- 3. Final Result
	SELECT * FROM OrgChart ORDER BY Level;
