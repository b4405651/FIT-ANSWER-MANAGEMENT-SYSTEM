using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace FAMS
{
    public partial class progress : Form
    {
        static List<String> FTPFiles, FilesToDownload;
        static long[] bytesTotal;
        int index = 0;
        int Mode = 0; // 0 = GET FILE SIZE ; 1 = DOWNLOAD
        NetworkCredential credential = new NetworkCredential("fitanswer", "9OeqLQfnI");
        int currentFile = 1;
        public Boolean isOpening = true;
        int taskCount = 2;

        delegate void SetTextCallback(string text);

        String remoteAddr = GF.Settings("host_url");

        public progress()
        {
            InitializeComponent();
        }

        private void SetText(string text)
        {
            if (this.file_no.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.file_no.Text = text;
            }
        }

        private void progress_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            backgroundTask.RunWorkerAsync();
        }

        private void backgroundTask_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Directory.Exists(GF.Settings("emp_card")))
                Directory.CreateDirectory(GF.Settings("emp_card"));

            versionCheck("emp_card", GF.Settings("emp_card"));
        }

        private void backgroundTask_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (FilesToDownload.Count > 0 && Mode == 1) this.SetText("FILE : " + (index + 1).ToString() + "/" + FilesToDownload.Count);
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (FilesToDownload != null)
            {
                if (FilesToDownload.Count > 0)
                {
                    bool halt = false;
                    this.Close();
                    if (currentFile < FilesToDownload.Count)
                    {
                        GF.Error("เกิดความผิดพลาดในการ Download ไฟล์ !!");
                        halt = true;
                    }
                    if (isOpening)
                    {
                        if (halt) new Login().exit_btn.PerformClick();
                    }
                }
                else
                {
                    if (taskCount == 0)
                        this.Close();
                }
            }
            else
            {
                if(taskCount == 0)
                    this.Close();
            }
        }

        void versionCheck(String folderName, String localPath)
        {
            this.SetText("[" + folderName + "] getting local file list ...");
            
            // GET FTP FILE LIST
            this.SetText("กำลังรับรายชื่อไฟล์ ... ");
            FTPFiles = FTP.getFTPFileList(folderName);

            FilesToDownload = new List<string>();
            if (FTPFiles != null)
            {
                foreach (String fileName in FTPFiles)
                    FilesToDownload.Add(fileName);
            }
            
            if (FilesToDownload.Count > 0)
                syncFile(folderName, localPath);

            taskCount--;
        }

        void syncFile(String folderName, String localPath)
        {
            if (FilesToDownload.Count > 0)
            {
                Console.WriteLine("[" + folderName + "] [ FILE LIST :: BEGIN ] TOTAL : " + FilesToDownload.Count.ToString() + " FILE" + (FilesToDownload.Count > 1 ? "S" : ""));
                int count = 1;
                foreach (String file in FilesToDownload)
                {
                    Console.WriteLine(count.ToString() + ". " + file);
                    count++;
                }
                Console.WriteLine("[" + folderName + "] [ FILE LIST :: END ]");
                backgroundTask.ReportProgress(0);

                bytesTotal = new long[FilesToDownload.Count];

                foreach (String file in FilesToDownload)
                {
                    FtpWebRequest fileSizeFTP;
                    fileSizeFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/public_html/fams/" + folderName + "/" + file));
                    fileSizeFTP.Credentials = credential;
                    fileSizeFTP.KeepAlive = true;
                    fileSizeFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                    fileSizeFTP.UseBinary = true;
                    fileSizeFTP.Proxy = null;
                    fileSizeFTP.UsePassive = true;
                    Console.WriteLine("ftp://" + remoteAddr + "/public_html/fams/" + folderName + "/" + file);

                    using (FtpWebResponse fileSizeResponse = (FtpWebResponse)fileSizeFTP.GetResponse())
                    {
                        bytesTotal[index] = fileSizeResponse.ContentLength;
                        fileSizeResponse.Close();
                    }

                    index++;
                }

                // START DOWNLOAD FILE
                Mode = 1;
                index = 0;
                foreach (String file in FilesToDownload)
                {
                    backgroundTask.ReportProgress(0);
                    //GF.doDebug("FILE " + (index + 1).ToString() + " : " + file);
                    string uri = "ftp://" + remoteAddr + "/public_html/fams/" + folderName + "/" + file;
                    Uri serverUri = new Uri(uri);
                    if (serverUri.Scheme != Uri.UriSchemeFtp)
                    {
                        return;
                    }

                    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/public_html/fams/" + folderName + "/" + file));
                    reqFTP.Credentials = credential;
                    reqFTP.KeepAlive = true;
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Proxy = null;
                    reqFTP.UsePassive = true;

                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            int Length = 2048;
                            Byte[] buffer = new Byte[Length];
                            int bytesRead = 0;
                            long allRead = 0;
                            using (FileStream writeStream = new FileStream(localPath + @"\" + file, FileMode.Create))
                            {
                                Console.WriteLine("[" + folderName + "] [ DOWNLOAD FILE ] " + "ftp://" + remoteAddr + "/public_html/fams/" + folderName + "/" + file);
                                allRead += bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                                //GF.doDebug("[" + file + "] " + ((int)(((float)allRead / (float)bytesTotal[index]) * 100.0)).ToString() + "% " + allRead.ToString() + "/" + bytesTotal[index].ToString());
                                backgroundTask.ReportProgress((int)(((float)allRead / (float)bytesTotal[index]) * 100.0));
                                while (bytesRead > 0)
                                {
                                    writeStream.Write(buffer, 0, bytesRead);
                                    allRead += bytesRead = responseStream.Read(buffer, 0, Length);
                                    backgroundTask.ReportProgress((int)(((float)allRead / (float)bytesTotal[index]) * 100.0));
                                    //GF.doDebug("[" + file + "] " + ((int)(((float)allRead / (float)bytesTotal[index]) * 100.0)).ToString() + "% " + allRead.ToString() + "/" + bytesTotal[index].ToString());
                                }
                                Console.WriteLine("[" + folderName + "] [ DOWNLOAD COMPLETED ] " + file);
                                writeStream.Close();
                            }
                            response.Close();
                        }
                    }
                    
                    while (true)
                    {
                        if (progressBar.Value == progressBar.Maximum)
                        {
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                    index++;
                    //if (index == 2) return;
                    currentFile++;
                }
                        
                //GF.doDebug("PROGRESS CLOSE !!");
            }
        }
    }
}
