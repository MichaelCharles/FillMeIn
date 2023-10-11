using System;
using System.Collections.Generic;
using System.IO;
using FillMeIn.Utility;
using FillMeIn.Library;

// Helper function to retrieve form fields as CSV

if (args.Length < 2)
{
    Console.WriteLine("Usage: FillMeIn <command> <arguments...>");
    return;
}

string command = args[0].ToLower();

try
{
    switch (command)
    {
        case "fill":
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: .\\FillMeIn.exe fill <pdfPath> <outputPdfPath> <csvString|csvFilePath>");
                return;
            }

            string pdfFilePath = args[1];
            string outputPdfPath = args[2];
            string csvData = args[3];

            var filler = new Filler(pdfFilePath, outputPdfPath, csvData);

            filler.Run();

            break;

        case "get":
            if (args.Length < 2 || args.Length > 3)
            {
                Console.WriteLine("Usage: .\\FillMeIn.exe get <pdfPath> [outputPath]");
                return;
            }

            pdfFilePath = args[1];
            var outputPath = args.Length == 3 ? args[2] : null;

            var getter = new Getter(pdfFilePath, outputPath);

            getter.Run();

            break;

        default:
            Console.WriteLine("Invalid command. Use 'fill' or 'get'.");
            break;
    }

} catch (Exception e)
{
    Console.WriteLine($"Error: {e}");
}