using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Data.SqlClient;

namespace AutoCA
{
    public partial class AutoCA : Form
    {
        public static IWebDriver chromeDriver;
        public static SqlConnection sqlConnection;
        public static bool firstClose = true;
        public static bool firstCreate = true;
        public static int speed = 1;
        public AutoCA()
        {
            InitializeComponent();

            //Init values from configuration file
            txbUserName.Text = ConfigurationManager.AppSettings["UserName"];
            txbPassword.Text = ConfigurationManager.AppSettings["Password"];
            txbName.Text = ConfigurationManager.AppSettings["Name"];
            txbGroup.Text = ConfigurationManager.AppSettings["Group"];
            txbAffected.Text = ConfigurationManager.AppSettings["AffectedEndUserPosition"];
            txbAssignee.Text = ConfigurationManager.AppSettings["AssigneePosition"];

            txbReportName.Text = ConfigurationManager.AppSettings["ReportName"];
            txbReportUserName.Text = ConfigurationManager.AppSettings["ReportUserName"];
            txtResult.Text = ConfigurationManager.AppSettings["SolutionResult"];
            txbReportUserLevel.Text = ConfigurationManager.AppSettings["UserLevel"];
            try
            {
                speed = int.Parse(txbSpeed.Text);
            }
            catch { speed = 1; }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!CheckInputData())
            {
                MessageBox.Show("Missing something");
                return;
            }

            string fileName = "";
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult file = openFile.ShowDialog();
            if (file == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }

            try
            {
                DataTable data = ParseExcelFile(fileName);

                data.Rows[0].Delete();
                data.AcceptChanges();

                //Create request
                ConnectAndSignIn();
                if (data.Rows.Count > 0)
                {
                    try
                    {
                        sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                        sqlConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex.ToString());
                    }

                    foreach (DataRow row in data.Rows)
                    {
                        if (string.IsNullOrEmpty(row[0].ToString()))
                            continue;

                        //Parsing Data
                        string summary = row[1].ToString();
                        string description = row[2].ToString();
                        string requestArea = row[3].ToString();
                        string rootCause = row[4].ToString();
                        int catId = int.Parse(row[6].ToString());
                        string caDate = row[7].ToString();

                        //Create ticket on CA site                        
                        CreateRequest(summary, description, requestArea, rootCause, txbName.Text, txbGroup.Text);

                        //Insert ticket to DB for reporting
                        InsertDataToDB(sqlConnection, caDate, catId, summary, description, requestArea, rootCause);
                    }
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    //
                    WriteLog("Finish create tickets");
                }
                else
                    WriteLog("Excel file doesnot contain data");

                //Close Request
                if (ckbAutoClose.Checked == true)
                {
                    ConnectAndSignIn();
                    while (true)
                    {
                        try
                        {
                            //ConnectAndSignIn();
                            CloseTicket(txtResult.Text);
                        }
                        catch
                        {
                            WriteLog("Error when close ticket");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
            chromeDriver.Close();
            chromeDriver.Dispose();
        }

        private void ConnectAndSignIn()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Url = "https://hotro.tct.vn/CAisd/SD";

            chromeDriver.FindElement(By.Id("USERNAME")).SendKeys(txbUserName.Text);
            chromeDriver.FindElement(By.Id("PIN")).SendKeys(txbPassword.Text);
            chromeDriver.FindElement(By.Name("imgBtn0")).Click();
        }

        private void CreateRequest(string summary, string description, string requestName,
            string rootCauseName, string userName, string groupName)
        {
            Thread.Sleep(5000/speed);
            
            Actions selectFileMenu = new Actions(chromeDriver);
            selectFileMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "f").Build().Perform();            
            Actions selectNewRequest = new Actions(chromeDriver);
            if (!firstCreate)
            {
                selectFileMenu.Release();
                selectFileMenu = new Actions(chromeDriver);
                selectFileMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "f").Build().Perform();
                selectNewRequest.Release();
                selectNewRequest = new Actions(chromeDriver);
            }
            selectNewRequest.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "n").Build().Perform();

            Thread.Sleep(2000/speed);
            //Go to frame which contains infor that we need to provide
            IWebElement product = chromeDriver.FindElement(By.Name("product"));
            chromeDriver.SwitchTo().Frame(product);
            IWebElement tab_1003 = chromeDriver.FindElement(By.Id("tab_1003"));
            chromeDriver.SwitchTo().Frame(tab_1003);
            IWebElement role_main = chromeDriver.FindElement(By.Id("role_main"));
            chromeDriver.SwitchTo().Frame(role_main);
            IWebElement cai_main = chromeDriver.FindElement(By.Id("cai_main"));
            chromeDriver.SwitchTo().Frame(cai_main);

            //Affected End User
            chromeDriver.FindElement(By.Id("df_0_1")).SendKeys(userName);
            Thread.Sleep(500);
            string xPath = "/html/body/ul[2]/li[" + txbAffected.Text + "]/a";
            chromeDriver.FindElement(By.XPath(xPath)).Click();
            //Assignee User
            chromeDriver.FindElement(By.Id("df_1_2")).SendKeys(userName);
            Thread.Sleep(500);
            xPath = "/html/body/ul[6]/li[" + txbAssignee.Text + "]/a";
            chromeDriver.FindElement(By.XPath(xPath)).Click();

            chromeDriver.FindElement(By.Id("df_1_1")).SendKeys(groupName);

            chromeDriver.FindElement(By.Id("df_2_1")).SendKeys(rootCauseName);

            chromeDriver.FindElement(By.Id("df_4_0")).SendKeys(summary);
            chromeDriver.FindElement(By.Id("df_5_0")).SendKeys(description);

            chromeDriver.FindElement(By.Id("df_0_2")).SendKeys(requestName);
            Thread.Sleep(500);
            chromeDriver.FindElement(By.XPath("/html/body/ul[3]/li/a")).Click();

            Thread.Sleep(1000/speed);
            selectNewRequest = new Actions(chromeDriver);
            selectNewRequest.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "s").Build().Perform();

            Thread.Sleep(5000/speed);            
            //chromeDriver.Close();
            //chromeDriver.Dispose();
            chromeDriver.SwitchTo().ParentFrame();
            chromeDriver.SwitchTo().ParentFrame();
            chromeDriver.SwitchTo().ParentFrame();
            chromeDriver.SwitchTo().ParentFrame();
            firstCreate = false;
        }

        private void CloseTicket(string result)
        {
            Thread.Sleep(5000/speed);//Wait for loading page

            //Go to frame which contains infor that we need to provide
            IWebElement product = chromeDriver.FindElement(By.Name("product"));
            chromeDriver.SwitchTo().Frame(product);
            IWebElement tab_1003 = chromeDriver.FindElement(By.Id("tab_1003"));
            chromeDriver.SwitchTo().Frame(tab_1003);
            IWebElement role_main = chromeDriver.FindElement(By.Id("role_main"));
            chromeDriver.SwitchTo().Frame(role_main);
            IWebElement scoreboard = chromeDriver.FindElement(By.Id("scoreboard"));
            chromeDriver.SwitchTo().Frame(scoreboard);

            if(firstClose)
            {
                chromeDriver.FindElement(By.XPath("//*[@id='s4pm']/span[2]")).Click();//My assign ticket
                chromeDriver.FindElement(By.XPath("//*[@id='s14pm']/span[2]")).Click();//Request
            }
            chromeDriver.FindElement(By.XPath("//*[@id='s15ds']/span")).Click();//Open request

            //Switch back to parent frame then go to frame containts all open ticket
            chromeDriver.SwitchTo().ParentFrame();
            IWebElement cai_main = chromeDriver.FindElement(By.Id("cai_main"));
            chromeDriver.SwitchTo().Frame(cai_main);

            Thread.Sleep(1000/speed);
            WriteLog("Closing Ticket: " + chromeDriver.FindElement(By.XPath("//*[@id='rslnk_0_0']")).Text);
            chromeDriver.FindElement(By.XPath("//*[@id='rslnk_0_0']")).Click();

            Thread.Sleep(2000/speed);
            Actions activityMenu = new Actions(chromeDriver);
            activityMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "t").Build().Perform();
            Actions updateStatusMenu = new Actions(chromeDriver);
            if(firstClose)
                updateStatusMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "u").Build().Perform();
            else
            {
                activityMenu.Release();
                activityMenu = new Actions(chromeDriver);
                activityMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "t").Build().Perform();
                updateStatusMenu.Release();
                updateStatusMenu = new Actions(chromeDriver);
                updateStatusMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "u").Build().Perform();
            }


            Thread.Sleep(5000/speed);
            //Tick internal
            chromeDriver.FindElement(By.Id("df_2_3")).Click();
            //Choose closed
            chromeDriver.FindElement(By.XPath("//*[@id='df_1_1']/option[1]")).Click();
            chromeDriver.FindElement(By.Id("df_3_0")).SendKeys(result);
            //Save new status
            Actions saveNewStatus = new Actions(chromeDriver);
            saveNewStatus.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "s").Build().Perform();

            Thread.Sleep(5000/speed);
            chromeDriver.SwitchTo().ParentFrame();
            chromeDriver.SwitchTo().ParentFrame();
            chromeDriver.SwitchTo().ParentFrame();
            chromeDriver.SwitchTo().ParentFrame();
            firstClose = false;
            //chromeDriver.Close();
            //chromeDriver.Dispose();
        }

        private bool CheckInputData()
        {
            if (string.IsNullOrWhiteSpace(txbGroup.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txbName.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txbPassword.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txbUserName.Text))
                return false;

            return true;
        }

        private DataTable ParseExcelFile(string fileName)
        {
            DataTable results = new DataTable();
            string sheetName = ConfigurationManager.AppSettings["SheetName"];

            try
            {
                string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=no'", fileName);
                string sql = "SELECT * FROM [" + sheetName.ToString() + "]";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader rdr = cmd.ExecuteReader())
                        {
                            results.Load(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Couldnot parse file");
            }
            return results;
        }

        private static void WriteLog(string logData, bool logTimeStamp = true)
        {
            try
            {
                using (StreamWriter w = File.AppendText(ConfigurationManager.AppSettings.Get("LogFile")))
                {
                    if (logTimeStamp)
                    {
                        logData = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ": " + logData;
                    }
                    w.WriteLine(logData);
                }
            }
            catch
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            chromeDriver.Close();
            chromeDriver.Dispose();
        }

        private void InsertDataToDB(SqlConnection sqlCon, string CADate, int CatId, string Summary,
            string Description, string RequestArea, string RootCause)
        {
            try
            {
                string command = "INSERT INTO DBO.CA (UserName, CADate, CatId, Summary, [Description], RequestArea, RootCause, Note) "
                + "VALUES (@userName,@caDate,@catId,@summary,@description,@requestArea,@rootCause, @note)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                sqlCommand.Parameters.AddWithValue("@userName", txbUserName.Text);
                sqlCommand.Parameters.AddWithValue("@caDate", CADate);
                sqlCommand.Parameters.AddWithValue("@catId", CatId);
                sqlCommand.Parameters.AddWithValue("@summary", Summary);
                sqlCommand.Parameters.AddWithValue("@description", Description);
                sqlCommand.Parameters.AddWithValue("@requestArea", RequestArea);
                sqlCommand.Parameters.AddWithValue("@rootCause", RootCause);
                sqlCommand.Parameters.AddWithValue("@note", txtResult.Text);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }

        }

        private void CreateCSVFileFromTable(DataTable dt, string fileName)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                    string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(fileName, sb.ToString());
        }

        private static void ExportToExcel(DataTable DataTable, string ExcelFilePath = null)
        {
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;
                Worksheet.Cells.NumberFormat = "@";//Type of all cells set to text


                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)
                    (Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), 
                    (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;
                Worksheet.Columns.AutoFit();//Extend column width if necessary
                // check fielpath
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath);
                        Excel.Quit();
                        //System.Windows.MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex.ToString());
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    Excel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        private static DataTable GetDataFromDB(string sqlString, SqlConnection connection)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sqlString, connection))
                {
                    dataTable.Load(cmd.ExecuteReader());
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                return null;
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //Check input parameter
            if (!CheckReportParameter())
            {
                MessageBox.Show("Missing parameter for report");
                return;
            }

            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                conn.Open();

                //Generate header for report
                SqlCommand command = new SqlCommand("GetNumberOfCaBetweenDate", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FromDate", calFromDate.Value.Date.ToString("yyyy-MM-dd"));                
                command.Parameters.AddWithValue("@ToDate", calToDate.Value.Date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@UserName", txbReportUserName.Text);
                command.Parameters.AddWithValue("@UserLevel", int.Parse(txbReportUserLevel.Text));
                DataTable header = new DataTable();
                header.Load(command.ExecuteReader());
                ExportToExcel(header, ConfigurationManager.AppSettings["ReportHeaderFile"]);
                command.Dispose();

                //GenerateDetail
                List<Category> categories = new List<Category>();
                List<CA> CAs = new List<CA>();

                //Get all category for current userLevel
                string strSql = " Select Id, Category, SubCategory, Text, Note from Categories where UserLevel = " 
                    + txbReportUserLevel.Text + " Order by Category, SubCategory";
                DataTable cats = new DataTable();
                command = new SqlCommand(strSql,conn);
                cats.Load(command.ExecuteReader());
                //Transform DataTable to List
                if (cats.Rows.Count > 0)
                    foreach (DataRow row in cats.Rows)
                    {
                        Category cat = new Category();
                        cat.Id = int.Parse(row[0].ToString());
                        cat.Cat = int.Parse(row[1].ToString());
                        cat.SubCat = int.Parse(row[2].ToString());
                        cat.Text = row[3].ToString();
                        cat.Note = row[4].ToString();
                        categories.Add(cat);
                    }
                command.Dispose();

                //Get all CA for user between selected date
                command = new SqlCommand("GetCaBetweenDate", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FromDate", calFromDate.Value.Date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ToDate", calToDate.Value.Date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@UserName", txbReportUserName.Text);                
                DataTable details = new DataTable();
                details.Load(command.ExecuteReader());
                //Transform DataTable to List
                if(details.Rows.Count >0)
                    foreach(DataRow row in details.Rows)
                    {
                        CA ca = new CA();
                        ca.Date = row[0].ToString();
                        ca.CatId = int.Parse(row[1].ToString());
                        ca.Summary = row[2].ToString();
                        ca.Description = row[3].ToString();
                        ca.Note = row[4].ToString();
                        CAs.Add(ca);
                    }
                command.Dispose();

                //Create results list for export to excel
                DataTable results = new DataTable();
                results.Columns.Add("Number", typeof(string));
                results.Columns.Add("Content", typeof(string));
                results.Columns.Add("Date", typeof(string));
                results.Columns.Add("Name", typeof(string));
                results.Columns.Add("Note", typeof(string));
                foreach(var cat in categories)
                {
                    DataRow row = results.NewRow();
                    if (cat.SubCat == 0)
                        row[0] = cat.Note;
                    else row[0] = cat.SubCat;
                    row[1] = cat.Text;
                    results.Rows.Add(row);

                    int count = 1;
                    foreach(var ca in CAs)
                    {
                        if(ca.CatId == cat.Id)
                        {
                            DataRow detailRow = results.NewRow();
                            detailRow[0] = cat.SubCat.ToString() + "." + count.ToString();//Number
                            detailRow[1] = "Tóm tắt: " + ca.Summary +"\r\n"+ ca.Description;//Content
                            detailRow[2] = ca.Date;//Date
                            detailRow[3] = txbReportName.Text;//Name
                            detailRow[4] = ca.Note;//Note
                            count++;
                            results.Rows.Add(detailRow);
                        }
                    }
                }
                ExportToExcel(results, ConfigurationManager.AppSettings["ReportDetailFile"]);
            }
            MessageBox.Show("Excel files created");
        }

        private bool CheckReportParameter()
        {
            if (string.IsNullOrWhiteSpace(txbReportName.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txbReportUserName.Text))
                return false;
            if (string.IsNullOrWhiteSpace(calFromDate.Text))
                return false;
            if (string.IsNullOrWhiteSpace(calToDate.Text))
                return false;
            return true;
        }
    }

    public class CA
    {
        public int CatId;
        public string Date;
        public string Summary;
        public string Description;
        public string Note;        
    }

    public class Category
    {
        public int Id;
        public int Cat;
        public int SubCat;
        public string Text;
        public string Note;//Roman number of Category;
    }    
}
