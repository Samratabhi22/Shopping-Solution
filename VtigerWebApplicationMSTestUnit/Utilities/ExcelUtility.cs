using Bytescout.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.Utilities
{
    public class ExcelUtility
    {
        public static string excelPath = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\Resources\\VtigerData.xlsx";
        public string Get_value_by_pasing_key(string sheetName, string key)
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile(excelPath);
            Worksheet book = spreadsheet.Workbook.Worksheets.ByName(sheetName);
            int lrow = book.UsedRangeRowMax;
            string vl = null;
            for (int i = 0; i <= lrow; i++)
            {
                string k = book.Cell(i, 0).ToString();
                if (k.Equals(key))
                {

                    vl = book.Cell(i, 1).ToString();
                    break;
                }

            }

            return vl;
        }
    }
}
