using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Loader;

class ExeDetailsReader
{
    static void Main(string[] args)
    {
        var path = args.Length > 0 ? args[0] : @"K:\Code\DSAlgo\DSAlgo\bin\Debug\net8.0\DSAlgo.exe";
        if (!File.Exists(path))
        {
            Console.Error.WriteLine("File not found: " + path);
            return;
        }

        var fvi = FileVersionInfo.GetVersionInfo(path);
        Console.WriteLine($"File: {path}");
        Console.WriteLine($"ProductName: {fvi.ProductName}");
        Console.WriteLine($"ProductVersion: {fvi.ProductVersion}");
        Console.WriteLine($"FileVersion: {fvi.FileVersion}");
        Console.WriteLine($"Company: {fvi.CompanyName}");
        Console.WriteLine();

        try
        {
            var an = AssemblyName.GetAssemblyName(path);
            Console.WriteLine("AssemblyName: " + an.FullName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("AssemblyName.GetAssemblyName failed: " + ex.Message);
        }

        // Use MetadataLoadContext to read custom attributes (TargetFramework)
        var resolver = new PathAssemblyResolver(new[] { typeof(object).Assembly.Location });
        using var mlc = new MetadataLoadContext(resolver);
        try
        {
            var asm = mlc.LoadFromAssemblyPath(path);
            var tfAttr = asm.GetCustomAttribute<TargetFrameworkAttribute>();
            Console.WriteLine("TargetFramework: " + (tfAttr?.FrameworkName ?? "unknown"));
            Console.WriteLine("Referenced Assemblies:");
            foreach (var r in asm.GetReferencedAssemblies())
                Console.WriteLine("  " + r.FullName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("MetadataLoadContext error: " + ex.Message);
        }
    }
}