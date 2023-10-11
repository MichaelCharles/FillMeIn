using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillMeIn.Utility
{
    public class CsvParser
    {
        public static Dictionary<string, string> Parse(string csvData)
        {
            Dictionary<string, string> fieldValues = new Dictionary<string, string>();

            // Your CSV parsing logic here. For example,
            string[] lines = csvData.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    fieldValues[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return fieldValues;
        }
    }
}
