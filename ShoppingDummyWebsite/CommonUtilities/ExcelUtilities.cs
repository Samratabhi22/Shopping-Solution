using Bytescout.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.CommonUtilities
{
    public  class ExcelUtilities
    {
        public static string excelPath = "C:\\Users\\Hp\\Desktop\\Shopping.xlsx";
        //public static string sheetName = "Login";

        public static string ReadSingleExceldata(string sheetName, int row, int column)
        {
            Spreadsheet spread_sheet = new Spreadsheet();
            spread_sheet.LoadFromFile(excelPath);
            //getting the Sheet
            Worksheet workbook = spread_sheet.Workbook.Worksheets.ByName(sheetName);
            int lastRow = workbook.UsedRangeRowMax;
            int lastColumn = workbook.UsedRangeColumnMax;
            string key = spread_sheet.Workbook.Worksheets.ByName(sheetName).Cell(row, column).ToString();
            return key;
        }

        public static IEnumerable<Object[]> ReadMultipleDataFromExcel(string sheetName)
        {
            Spreadsheet sp = new Spreadsheet();
            sp.LoadFromFile(excelPath);
            Worksheet book = sp.Workbook.Worksheets.ByName(sheetName);
            int lastRow = book.UsedRangeRowMax;


            for (int i = 0; i <= lastRow; i++)
            {
                string key = sp.Workbook.Worksheets.ByName(sheetName).Cell(i, 0).ToString();
                string value = sp.Workbook.Worksheets.ByName(sheetName).Cell(i, 1).ToString();
                yield return new object[] { key, value };
            }
        }
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
