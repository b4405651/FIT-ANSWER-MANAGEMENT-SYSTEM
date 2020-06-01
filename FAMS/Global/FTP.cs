using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FAMS
{
    public class FTP
    {
        static string ftpPath = "public_html/fams/";
        static FtpWebRequest open(string Method, string folderName, string fileName)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + GF.Settings("host_url") + "/" + ftpPath + folderName + "/" + fileName);
            request.Method = Method;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("fitanswer", "9OeqLQfnI");
            Console.WriteLine("FTP :: CONNECTION IS OPENED TO " + request.RequestUri.AbsoluteUri);
            return request;
        }

        public static bool upload(string folderName, string file_path, string new_fileName)
        {
            if (new_fileName.Trim().ToLower().IndexOf(".jpg") == -1)
            {
                GF.Error("ต้องเป็นไฟล์สกุล .JPG เท่านั้น !!");
                return false;
            }
            bool boolReturn = false;
            FtpWebRequest request = open(WebRequestMethods.Ftp.UploadFile, folderName, new_fileName);
            if (request != null)
            {
                try
                {
                    // Copy the contents of the file to the request stream.
                    byte[] fileContents = File.ReadAllBytes(file_path);

                    request.RenameTo = new_fileName;
                    request.ContentLength = fileContents.Length;

                    Stream requestStream;
                    using (requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                        requestStream.Close();

                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                        if (response.StatusCode == FtpStatusCode.ClosingData) boolReturn = true;
                        else
                        {
                            GF.Error("(" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                            Console.WriteLine("FTP :: FILE [" + new_fileName + "] UPLOAD FAILED !! (" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                            boolReturn = false;
                        }

                        response.Close();
                    }
                }
                catch (Exception e)
                {
                    GF.Error("เกิดความผิดพลาด !!\r\n\r\n" + e.Message);
                    boolReturn = false;
                    return boolReturn;
                }
            }
            Console.WriteLine("FTP :: FILE [" + new_fileName + "] UPLOAD SUCCEEDED !!");
            return boolReturn;
        }

        public static Image download(string folderName, string fileName)
        {
            if(folderName == String.Empty)
            {
                Console.WriteLine("\r\nระบุ folderName !!\r\n");
                GF.Error("เกิดความผิดพลาดในการ download ไฟล์จาก server !!\r\n\r\nกรุณาติดต่อผู้ดูแลเกี่ยวกับปัญหานี้ ...");
                return null;
            }
            Console.WriteLine("folderName = " + folderName);

            if (fileName.IndexOf(GF.Settings("tmp_path")) != -1)
                fileName = fileName.Replace(GF.Settings("tmp_path"), "");

            if (fileName == String.Empty)
            {
                Console.WriteLine("\r\nระบุ fileName !!\r\n");
                GF.Error("เกิดความผิดพลาดในการ download ไฟล์จาก server !!\r\n\r\nกรุณาติดต่อผู้ดูแลเกี่ยวกับปัญหานี้ ...");
                return null;
            }
            Console.WriteLine("fileName = " + fileName);

            Image returnImage = null;
            try
            {
                FtpWebRequest request = open(WebRequestMethods.Ftp.DownloadFile, folderName, fileName);
                if (request != null)
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    Stream responseStream = response.GetResponseStream();

                    if (response.StatusCode == FtpStatusCode.OpeningData)
                    {
                        returnImage = Bitmap.FromStream(responseStream);
                    }
                    else
                    {
                        GF.Error("(" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                        Console.WriteLine("FTP :: FILE [" + fileName + "] DOWNLOAD FAILED !! (" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                        returnImage = null;
                    }

                    response.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                GF.Error("เกิดความผิดพลาดในการดึงไฟล์รูปภาพสมาชิกจาก Server !");
                return null;
            }
            Console.WriteLine("FTP :: FILE [" + fileName + "] DOWNLOAD SUCCEEDED !!");
            return returnImage;
        }

        public static bool delete(string folderName, string fileName)
        {
            bool boolReturn = false;
            Console.WriteLine("FTP :: DELETING FILE [" + fileName + "] ...");
            FtpWebRequest request = open(WebRequestMethods.Ftp.DeleteFile, folderName, fileName);
            if (request != null)
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                if (response.StatusCode == FtpStatusCode.FileActionOK) boolReturn = true;
                else
                {
                    GF.Error("(" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                    Console.WriteLine("FTP :: FILE [" + fileName + "] DELETE FAILED !! (" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                    boolReturn = false;
                }
            }
            Console.WriteLine("FTP :: FILE [" + fileName + "] DELETE SUCCEEDED !!");
            return boolReturn;
        }

        public static List<string> getFTPFileList(String folderName)
        {
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            List<string> FTPFiles = null;
            try
            {
                Console.WriteLine("[" + folderName + "] connecting to ftp://" + GF.Settings("host_url") + "/public_html/fams/" + folderName + "/");
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GF.Settings("host_url") + "/public_html/fams/" + folderName + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential("fitanswer", "9OeqLQfnI");
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = true;
                reqFTP.UsePassive = true;
                using (response = reqFTP.GetResponse())
                {
                    using (reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        // to remove the trailing '\n'
                        result.Remove(result.ToString().LastIndexOf('\n'), 1);
                        result.Replace("version.txt\n", "");
                        String[] tmp = result.ToString().Split('\n');
                        Console.WriteLine("\r\n[" + folderName + "] ========== FTP FILE ==========");
                        FTPFiles = new List<string>();
                        foreach (String tmpStr in tmp)
                        {
                            if (tmpStr != "." && tmpStr != "..")
                            {
                                FTPFiles.Add(tmpStr);
                                Console.WriteLine("- " + tmpStr);
                            }
                        }
                        Console.WriteLine("\r\n");
                        return FTPFiles;
                    }
                }
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                Console.WriteLine("[" + folderName + "] [ GET FILE LIST :: ERROR ] >>> " + ex.Message);
                return null;
            }
        }
    }
}
