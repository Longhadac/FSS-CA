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
                        ConnectAndSignIn();
                        CreateRequest(summary, description, requestArea, rootCause, txbName.Text, txbGroup.Text);

                        //Insert ticket to DB for reporting
                        InsertDataToDB(sqlConnection, caDate, catId, summary, description, requestArea, rootCause);
                    }
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                else
                    WriteLog("Excel file doesnot contain data");

                //Close Request
                if (ckbAutoClose.Checked == true)
                {
                    while (true)
                    {
                        try
                        {
                            ConnectAndSignIn();
                            CloseTicket(txtResult.Text);
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
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
            Thread.Sleep(5000);

            Actions selectFileMenu = new Actions(chromeDriver);
            selectFileMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "f").Build().Perform();
            Actions selectNewRequest = new Actions(chromeDriver);
            selectNewRequest.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "n").Build().Perform();

            Thread.Sleep(2000);
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

            Thread.Sleep(1000);
            selectNewRequest = new Actions(chromeDriver);
            selectNewRequest.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "s").Build().Perform();
            
            Thread.Sleep(5000);
            chromeDriver.Close();
            chromeDriver.Dispose();
        }

        private void CloseTicket(string result)
        {
            Thread.Sleep(5000);//Wait for loading page

            //Go to frame which contains infor that we need to provide
            IWebElement product = chromeDriver.FindElement(By.Name("product"));
            chromeDriver.SwitchTo().Frame(product);
            IWebElement tab_1003 = chromeDriver.FindElement(By.Id("tab_1003"));
            chromeDriver.SwitchTo().Frame(tab_1003);
            IWebElement role_main = chromeDriver.FindElement(By.Id("role_main"));
            chromeDriver.SwitchTo().Frame(role_main);
            IWebElement scoreboard = chromeDriver.FindElement(By.Id("scoreboard"));
            chromeDriver.SwitchTo().Frame(scoreboard);

            chromeDriver.FindElement(By.XPath("//*[@id='s4pm']/span[2]")).Click();//My assign ticket
            chromeDriver.FindElement(By.XPath("//*[@id='s14pm']/span[2]")).Click();//Request
            chromeDriver.FindElement(By.XPath("//*[@id='s15ds']/span")).Click();//Open request

            //Switch back to parent frame then go to frame containts all open ticket
            chromeDriver.SwitchTo().ParentFrame();
            IWebElement cai_main = chromeDriver.FindElement(By.Id("cai_main"));
            chromeDriver.SwitchTo().Frame(cai_main);

            Thread.Sleep(1000);
            WriteLog("Closing Ticket: " + chromeDriver.FindElement(By.XPath("//*[@id='rslnk_0_0']")).Text);
            chromeDriver.FindElement(By.XPath("//*[@id='rslnk_0_0']")).Click();

            Thread.Sleep(2000);
            Actions activityMenu = new Actions(chromeDriver);
            activityMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "t").Build().Perform();
            Actions updateStatusMenu = new Actions(chromeDriver);
            updateStatusMenu.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "u").Build().Perform();

            Thread.Sleep(5000);
            //Tick internal
            chromeDriver.FindElement(By.Id("df_2_3")).Click();
            //Choose closed
            chromeDriver.FindElement(By.XPath("//*[@id='df_1_1']/option[1]")).Click();
            chromeDriver.FindElement(By.Id("df_3_0")).SendKeys(result);
            //Save new status
            Actions saveNewStatus = new Actions(chromeDriver);
            saveNewStatus.SendKeys(OpenQA.Selenium.Keys.LeftAlt + "s").Build().Perform();

            Thread.Sleep(5000);
            chromeDriver.Close();
            chromeDriver.Dispose();
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
                string command = "INSERT INTO DBO.CA (UserName, CADate, CatId, Summary, [Description], RequestArea, RootCause) "
                + "VALUES (@userName,@caDate,@catId,@summary,@description,@requestArea,@rootCause)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                sqlCommand.Parameters.AddWithValue("@userName", txbUserName.Text);
                sqlCommand.Parameters.AddWithValue("@caDate", CADate);
                sqlCommand.Parameters.AddWithValue("@catId", CatId);
                sqlCommand.Parameters.AddWithValue("@summary", Summary);
                sqlCommand.Parameters.AddWithValue("@description", Description);
                sqlCommand.Parameters.AddWithValue("@requestArea", RequestArea);
                sqlCommand.Parameters.AddWithValue("@rootCause", RootCause);                

                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                WriteLog(ex.ToString());
            }
            
        }        
    }
}
