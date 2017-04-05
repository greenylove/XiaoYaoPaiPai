using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ClosedXML.Excel;
using ClosedXML;
using CMSEmergencySystem;


namespace CMSEmergencySystem.Email
{
    public class GetExcelFile
    {
        public static void DataTable ()
        {
            {
                try
                { 
                    DataBaseHelper myDB = new DataBaseHelper();
                    DataTable DT = myDB.getAllIncident();  
                    ExportDataSetToExcel(DT);                  
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private static void ExportDataSetToExcel(DataTable DT)
        {
            try
            {
                string AppLocation = "";
                AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                AppLocation = AppLocation.Replace("file:\\", "");
                string file = AppLocation + "\\ExcelFiles\\DataFile.xlsx";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add((String)DT.Rows[1][5]);                                   
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;
                    wb.SaveAs(file);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}