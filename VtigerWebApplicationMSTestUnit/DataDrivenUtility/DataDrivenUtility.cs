using Bytescout.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.DataDrivenUtility
{
    public  class DataDrivenUtility
    {
        Spreadsheet sheet;
        //reading single data from excel
        public string FetchingleDataExcel(string sheetName, int row, int col)
        {
            string projdata = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\Resources\\Actitime.xlsx";
            sheet = new Spreadsheet();
            sheet.LoadFromFile(projdata);//loading the excel
            //getting single data from excel sheet
            string data = sheet.Workbook.Worksheets.ByName(sheetName).Cell(row, col).ToString();
            return data;//returning the data
        }
        public static IEnumerable<Object[]> MultipleData
        {
            get
            {
                return new[]
                {
                   new Object[]{ "admin", "admin" },
                   new Object[] { "admin", "manager" }
                };
            }

        }
    }
}
