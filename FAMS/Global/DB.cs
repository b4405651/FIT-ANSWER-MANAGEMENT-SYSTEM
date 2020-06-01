using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FAMS
{
    public static class DB
    {
        public static Boolean isDebug = true;
        
        public static Dictionary<String, Object> Post(String url, Dictionary<string, string> values = null)
        {
            String requestUri = "http://" + GF.Settings("host_url") + "/" + url;

            Console.WriteLine("URL : " + requestUri);

            string postData = String.Empty;
            byte[] postBytes = null;
            NameValueCollection outgoingQueryString = null;

            if (values != null)
            {
                outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
                foreach (KeyValuePair<string, string> obj in values)
                {
                    String theValue = (obj.Value ?? "").Replace("'", "''");
                    Console.WriteLine(obj.Key + " = " + theValue);
                    postData += obj.Key + "=" + theValue + "&";
                }
                if(postData.Trim().Length > 0)
                    postData = postData.Substring(0, postData.Length - 1);
                //postData = outgoingQueryString.ToString();
                //postBytes = new ASCIIEncoding().GetBytes(postData.ToString());
                postBytes = new UTF8Encoding().GetBytes(postData.ToString());
            }

            // set up request object
            WebRequest request;
            try
            {
                request = WebRequest.Create(requestUri);
            }
            catch (Exception e)
            {
                GF.closeLoading();
                GF.Error(e.Message, "ERROR CREATE CONNECTION");
                return null;
            }
            
            if (request == null)
            {
                throw new ApplicationException("Invalid URL: " + requestUri);
            }

            ((HttpWebRequest)request).Timeout = 10000;

            ((HttpWebRequest)request).UserAgent = "FAMS";

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (values != null)
            {
                request.ContentLength = postBytes.Length;
                try
                {
                    using (Stream postStream = request.GetRequestStream())
                    {
                        postStream.Write(postBytes, 0, postBytes.Length);
                        postStream.Flush();
                        postStream.Close();
                        Console.WriteLine("\r\nJSON POST LENGTH : " + postBytes.Length.ToString());
                    }
                }
                catch (WebException wex)
                {
                    GF.closeLoading();
                    GF.Error(wex.Message, "ERROR SENDING REQUEST");
                    return null;
                }
            }
            
            String returnString = "";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    if (((HttpWebResponse)response).StatusDescription.Trim() == "OK")
                    {
                        using (Stream returnStream = response.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(returnStream, Encoding.UTF8))
                            {
                                returnString = readStream.ReadToEnd();
                                Console.WriteLine("JSON GET LENGTH : " + returnString.Length.ToString() + "\r\n");
                            }
                        }
                    }
                    else
                    {
                        GF.closeLoading();
                        GF.Error("ERROR IN RESPONSE FROM SERVER !!", "ERROR GETTING RESPONSE FROM SERVER");
                    }
                }
            }
            catch (WebException wex)
            {
                GF.closeLoading();
                
                Console.WriteLine("");
                Console.WriteLine("=== WEB EXCEPTION :: BEGIN ===");
                Console.WriteLine("");

                if (wex.Response != null)
                {
                    String Error = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();

                    Error = Error.Substring(Error.IndexOf("<p>"), Error.LastIndexOf("</p>") - Error.IndexOf("<p>"));
                    Error = Error.Replace("<p>", "");
                    Error = Error.Replace("</p>", "\r\n");

                    Console.WriteLine(Error);

                    GF.printError("********** DATABASE ERROR : " + Environment.MachineName + " **********");
                    GF.printError(Error + "\r\n");

                    GF.Error("DATABASE ERROR !!");
                    GF.submitErrorLog();
                }
                else
                {
                    GF.closeLoading();
                    GF.Error(wex.Message);
                    Console.WriteLine("ERROR : " + wex.Message);
                }
                
                Console.WriteLine("");
                Console.WriteLine("=== WEB EXCEPTION :: END ===");
                Console.WriteLine("");
                //Application.Exit();

                return null;
            }

            Console.WriteLine("JSON : " + returnString);
            //StreamWriter sw = new StreamWriter(GF.Settings("tmp_path") + "TEST.txt", true);
            //sw.WriteLine(returnString);
            //sw.Close();

            if (returnString == String.Empty) return null;

            if (returnString != "INVALID REQUEST !!" && returnString != "TRANSACTION INCOMPLETE !!" && returnString.IndexOf("ERROR !!") == -1)
            {
                if (returnString[0] != '[' && returnString[returnString.Length - 1] != ']') return JSONDecode("[" + returnString + "]");
                else return JSONDecode(returnString);
            }
            else
            {
                GF.closeLoading();
                GF.Error(returnString);
                return null;
            }
        }

        static dynamic JSONDecode(String json){
            Console.WriteLine("JSONDecode : " + json);
            try
            {
                if (json.Substring(1, json.Length - 2) == String.Empty) return null;

                object obj = new JavaScriptSerializer().DeserializeObject(json);

                if (obj != null)
                {
                    if ((obj as Array).Length == 0) return null;
                    obj = ((Array)obj).GetValue(0);
                    if (((Dictionary<String, Object>)obj)["result"].ToString() == "false")
                    {
                        GF.Error(((Dictionary<String, Object>)obj)["msg"].ToString());
                        return null;
                    }
                    if (((Dictionary<String, Object>)obj)["result"].ToString().IndexOf("Can't connect to local MySQL server") > -1)
                    {
                        GF.Error("ไม่สามารถเชื่อมต่อฐานข้อมูล !!\r\nกรุณาติดต่อผู้พัฒนาโปรแกรม ...");
                        return null;
                    }
                    return obj;

                }
                else return null;
            }
            catch (Exception ex)
            {
                GF.printError("===== JSONDecode Error !! =====\r\n");
                GF.printError(ex.Message + "\r\n");
                GF.printError("===== JSON String =====\r\n");
                GF.printError(json + "\r\n");
                GF.Error(ex.Message, "JSONDecode Error !!");
                GF.submitErrorLog();
                return null;
            }
        }

        public static void PerformWebNavigate(String url, webBrowser wb, Dictionary<string, string> values = null)
        {
            String requestUri = "http://" + GF.Settings("host_url") + "/Report/" + url;

            Console.WriteLine("[NAVIGATE] WEB BROWSER URL : " + requestUri);

            string postData = "user_id=" + GF.userID.ToString() + "&";
            byte[] postBytes = null;
            NameValueCollection outgoingQueryString = null;

            if (values != null)
            {
                values.Add("mode", "1");
                outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
                foreach (KeyValuePair<string, string> obj in values)
                {
                    Console.WriteLine(obj.Key + " = " + obj.Value);
                    postData += obj.Key + "=" + obj.Value + "&";
                }
                if (postData.Trim().Length > 0)
                    postData = postData.Substring(0, postData.Length - 1);
                //postData = outgoingQueryString.ToString();
                //postBytes = new ASCIIEncoding().GetBytes(postData.ToString());
                postBytes = new UTF8Encoding().GetBytes(postData.ToString());
            }

            wb.Navigate(requestUri, "_self", postBytes, "User-Agent: FAMS\r\nContent-Type: application/x-www-form-urlencoded\r\nCache-Control: no-cache, no-store, must-revalidate\r\nPragma: no-cache\r\nExpires: 0");
        }

        public static void WebDownload(Form Sender, String url, String localFileName, Dictionary<string, string> values = null)
        {
            using (ExtWebClient downloadClient = new ExtWebClient())
            {
                String localFilePath = String.Empty;
                using (SaveFileDialog saveFileDlg = new SaveFileDialog())
                {
                    saveFileDlg.DefaultExt = "xls";
                    saveFileDlg.Filter = "Excel File (*.xls)|*.xls";
                    saveFileDlg.FileName = localFileName;
                    if (saveFileDlg.ShowDialog() == DialogResult.OK)
                    {
                        localFilePath = saveFileDlg.FileName;

                        downloadClient.PostParam = values;
                        GF.showLoading(Sender);
                        downloadClient.DownloadFile("http://" + GF.Settings("host_url") + "/Report/" + url, localFilePath);
                        GF.Error("ดาวน์โหลดไฟล์เรียบร้อยแล้ว !!", "สำเร็จ");
                        GF.closeLoading();
                    }
                }
            }
        }

        public static Dictionary<String, Object> ReportGetTotalRecord(String url, Dictionary<string, string> values = null)
        {
            Dictionary<string, string> Params = null;
            if (values != null)
            {
                Params = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> obj in values)
                {
                    Params.Add(obj.Key, obj.Value);
                }
                Params.Add("get_total_record", "true");
            }

            return Post("Report/" + url, Params);
        }

        public static Boolean IsServerAlive()
        {
            Console.WriteLine(">>>>> SERVER ALIVE CHECK ...");
            if (!IsAlive(80))
            {
                GF.Error("ไม่สามารถติดต่อ Server ได้ !\r\n\r\nกรุณาลองใหม่ภายหลัง ...");
                Application.Exit();
                return false;
            }
            else
            {
                Console.WriteLine("SERVER IS ALIVE ...");
                return true;
            }
        }

        public static Boolean IsDBAlive()
        {
            Console.WriteLine(">>>>> DB ALIVE CHECK ...");
            if (!IsAlive(GF.SSH_Port))
            {
                GF.Error("ไม่สามารถติดต่อ ฐานข้อมูล ได้ !\r\n\r\nกรุณาลองใหม่ภายหลัง ...");
                Application.Exit();
                return false;
            }
            else
            {
                Console.WriteLine("DB IS ALIVE ...");
                return true;
            }
        }

        static Boolean IsAlive(Int32 Port)
        {
            try
            {
                using (System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient())
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("FAMS_Settings", true))
                    {
                        tcpClient.Connect(key.GetValue("host_url").ToString(), Port);
                        key.Close();
                        return true;
                    }
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                return false;
            }
        }
    }
}