using System.Collections.Generic;
using System.IO;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using FillMeIn.Utility;
using iText.IO.Font;

namespace FillMeIn.Library
{
    internal class Filler
    {
        private string pdfFilePath;
        private string csvData;
        private string outputPdfPath;

        public Filler(string pdfFilePath, string outputPdfPath, string csvData)
        {
            this.csvData = csvData;
            this.pdfFilePath = pdfFilePath;
            this.outputPdfPath = outputPdfPath;
        }

        public void Run()
        {
            if (File.Exists(csvData))
            {
                csvData = File.ReadAllText(csvData);
            }

            Dictionary<string, string> fieldValues = CsvParser.Parse(csvData);

            PdfReader reader = new PdfReader(pdfFilePath);
            reader.SetUnethicalReading(true); // bypass the password protection

            PdfWriter writer = new PdfWriter(outputPdfPath);
            PdfDocument pdf = new PdfDocument(reader, writer);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);

            PdfFont font = PdfFontFactory.CreateFont("./japanese.ttf", PdfEncodings.IDENTITY_H);

            IDictionary<string, PdfFormField> fields = form.GetAllFormFields();
            foreach (var pair in fieldValues)
            {
                if (fields.ContainsKey(pair.Key))
                {
                    fields[pair.Key].SetValue(pair.Value, font, 12); // You can adjust the size as needed
                }
            }

            pdf.Close();
        }
    }
}
