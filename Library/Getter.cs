using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iText.Forms;
using iText.Kernel.Pdf;
using FillMeIn.Utility;

namespace FillMeIn.Library
{
    internal class Getter
    {
        private string pdfFilePath;
        private string? outputPath;

        public Getter(string pdfFilePath, string? outputPath)
        {
            this.pdfFilePath = pdfFilePath;
            this.outputPath = outputPath;
        }

        public string GetFieldsAsCsv(PdfDocument pdfDoc)
        {
            List<string> lines = new List<string>();
            var form = PdfAcroForm.GetAcroForm(pdfDoc, false);
            var fields = form.GetAllFormFields();

            foreach (var fieldName in fields.Keys)
            {
                string fieldValue = fields[fieldName].GetValueAsString();
                lines.Add($"{fieldName},{fieldValue}");
            }

            return string.Join('\n', lines);
        }

        public void Run()
        {
            PdfReader reader = new PdfReader(pdfFilePath);
            reader.SetUnethicalReading(true); // bypass the password protection

            var pdfDoc = new PdfDocument(reader);
            {
                string csvContent = this.GetFieldsAsCsv(pdfDoc);

                if (outputPath is not null)
                {
                    File.WriteAllText(outputPath, csvContent);
                }
                else
                {
                    Console.WriteLine(csvContent);
                }
            }
            pdfDoc.Close();
        }
    }
}
