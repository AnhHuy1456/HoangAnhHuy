using System.Data;
using OfficeOpenXml;
namespace HoangAnhHuy_BTH2.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelpackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelpackage.Workbook.Worksheets[0];
            // check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;

            }
            //create a list to hold the column names
            List<string> columnNames = new List<string>();
            //needed to keep track of empty column headers
            int currenntColumn = 1;
            //loop all columns in the sheet and add them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();
                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currenntColumn);
                    dt.Columns.Add("Header_" + currenntColumn);
                    currenntColumn++;
                }
                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);
                //count the suplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTaable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }
                //add the column to the datatable
                dt.Columns.Add(columnName);
                currenntColumn++;
            }
        }
    }
}