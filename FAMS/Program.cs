using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

using EnvDTE80;

namespace FAMS
{
    static class Program
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static Process currentProcess;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                foreach (Process theProcess in Process.GetProcessesByName("EXCEL"))
                    theProcess.Kill();

                if (Process.GetProcessesByName("FAMS").Length > 1)
                {
                    foreach (Process theProcess in Process.GetProcessesByName("FAMS"))
                        theProcess.Kill();
                }

                if (!IsRunningAsAdministrator())
                {
                    Restart();
                    return;
                }

                using (Microsoft.Win32.RegistryKey rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true))
                {
                    rkey.SetValue("sShortDate", "dd/MM/yyyy");
                    rkey.Close();
                }

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.ApplicationExit += (ss, ee) =>
                {
                    foreach (Process theProcess in Process.GetProcessesByName("EXCEL"))
                        theProcess.Kill();

                    foreach (Process theProcess in Process.GetProcessesByName("FAMS"))
                        theProcess.Kill();
                };

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                /*GF.Settings("Reset();
                GF.Settings("Save();*/

                Microsoft.Win32.RegistryKey key;

                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("FAMS_Settings", true);
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("FAMS_Settings");
                    key.SetValue("host_url", "fams.fit-answer.com");
                    key.SetValue("branch_id", "");
                    key.SetValue("tmp_path", "C:\\FAMS\\TMP\\");
                    key.SetValue("member_prefix", "");
                    key.SetValue("localCardPath", "C:\\FAMS\\MEMBERCARD\\");
                    key.SetValue("card_printer", "");
                    key.SetValue("receipt_printer", "");
                    key.SetValue("vat", "");
                    key.SetValue("emp_card", "C:\\FAMS\\EMPCARD\\");
                }
                else
                {
                    if (key.GetValue("host_url") == null) key.SetValue("host_url", "fams.fit-answer.com");
                    if (key.GetValue("branch_id") == null) key.SetValue("branch_id", "");
                    if (key.GetValue("tmp_path") == null) key.SetValue("tmp_path", "C:\\FAMS\\TMP\\");
                    if (key.GetValue("member_prefix") == null) key.SetValue("member_prefix", "");
                    if (key.GetValue("localCardPath") == null) key.SetValue("localCardPath", "C:\\FAMS\\MEMBERCARD\\");
                    if (key.GetValue("card_printer") == null) key.SetValue("card_printer", "");
                    if (key.GetValue("receipt_printer") == null) key.SetValue("receipt_printer", "");
                    if (key.GetValue("vat") == null) key.SetValue("vat", "");
                    if (key.GetValue("emp_card") == null) key.SetValue("emp_card", "C:\\FAMS\\EMPCARD\\");
                }

                //key.SetValue("host_url", "fams.topladyshop.net");
                key.SetValue("host_url", "fams.fit-answer.com");

                Boolean nullConfig = false;
                foreach (string valueName in key.GetValueNames())
                    Console.WriteLine(valueName + " = " + key.GetValue(valueName));

                foreach (string valueName in key.GetValueNames())
                {
                    if ((key.GetValue(valueName) ?? "").ToString() == String.Empty)
                    {
                        nullConfig = true;
                        break;
                    }
                }
                key.Close();
                key.Dispose();

                GF.cultureList = new List<string>();

                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo culture in cultures)
                {
                    RegionInfo region = new RegionInfo(culture.LCID);

                    if (!(GF.cultureList.Contains(region.EnglishName)))
                    {
                        GF.cultureList.Add(region.EnglishName);
                    }
                }

                String tmp_path = GF.Settings("tmp_path");

                if (!Directory.Exists(tmp_path))
                {
                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(@"Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                    Directory.CreateDirectory(tmp_path, securityRules);
                }
                else
                {
                    var di = new DirectoryInfo(tmp_path);

                    foreach (var file in di.GetFiles("*", SearchOption.AllDirectories))
                        file.Attributes &= ~FileAttributes.ReadOnly;
                }

                DirectoryInfo downloadedMessageInfo = new DirectoryInfo(tmp_path);

                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                {
                    dir.Delete(true);
                }

                DirectorySecurity sec = Directory.GetAccessControl(tmp_path);
                // Using this instead of the "Everyone" string means we work on non-English systems.
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                Directory.SetAccessControl(tmp_path, sec);

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");

                if (nullConfig) Console.WriteLine("!! NULL CONFIG !!");
                else Console.WriteLine("^^ HAS CONFIG ^^");

                if (DB.IsServerAlive())
                {
                    if (DB.IsDBAlive())
                    {
                        if (nullConfig) Application.Run(new init_config());
                        else Application.Run(new Login());
                    }
                }

                return;

                /*long time1 = 0;
                long time2 = 0;

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                // JSON
                for (int i = 1; i <= 5; i++)
                {
                    Dictionary<string, string> values = new Dictionary<string, string>()
                    {
                        { "user_id", GF.userID },
                        { "page" , "1" },
                        { "recordCount", GF.rowsPerPage.ToString() },
                        { "branch_id", "1" }
                    };

                    Dictionary<String, Object> Obj = DB.Post("Member/MemberList/", values);
                    if (Obj == null)
                    {
                        GF.Error("JSON Error !!");
                        return;
                    }
                }
                stopwatch.Stop();
                time1 = stopwatch.ElapsedMilliseconds;
                
                // SSH
                stopwatch.Start();
                for (int i = 1; i <= 5; i++)
                {
                    using (DataTable DT = SSH.GET("SELECT * FROM TEST"))
                    {
                        String str = "";

                        foreach (DataRow DR in DT.Rows)
                        {
                            foreach (DataColumn DC in DT.Columns)
                            {
                                str += DC + " = " + DR[DC] + ", ";
                            }
                            str = str.Substring(0, str.Length - 2);
                            str += "\r\n";
                        }

                        Console.WriteLine(str);
                    }
                }
                stopwatch.Stop();
                time2 = stopwatch.ElapsedMilliseconds;

                Console.WriteLine("JSON : " + time1 + " ms.");
                Console.WriteLine("SSH : " + time2 + " ms.");

                return;*/
            }
            catch (Win32Exception e)
            {
                GF.printError("********** APPLICATION EXIT WITH CODE (" + e.ErrorCode + ") **********");
                GF.printError(e.Message + "\r\n");

                GF.printError("FILE : " + new StackTrace(e, true).GetFrame(0).GetFileName());
                GF.printError("LINE : " + new StackTrace(e, true).GetFrame(0).GetFileLineNumber());

                GF.printError("STACK-TRACE : \r\n" + e.StackTrace.ToString() + "\r\n");

                GF.submitErrorLog();
                
                if (currentProcess != null) currentProcess.Kill();
                System.Environment.Exit(0);
            }
        }

        public static bool IsRunningAsAdministrator()
        {
            // Get current Windows user
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

            // Get current Windows user principal
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);

            // Return TRUE if user is in role "Administrator"
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void Restart()
        {
            // Setting up start info of the new process of the same application
            ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);

            // Using operating shell and setting the ProcessStartInfo.Verb to “runas” will let it run as admin
            processStartInfo.UseShellExecute = true;
            processStartInfo.Verb = "runas";

            // Start the application as new process
            currentProcess = Process.Start(processStartInfo);

            // Shut down the current (old) process
            Application.Exit();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                GF.closeLoading();
                Exception ex = (Exception)e.ExceptionObject;

                GF.printError("********** FATAL UNHANDLED EXCEPTION ERROR *********");
                GF.printError("[" + ex.TargetSite.ToString() + "]");
                GF.printError(ex.ToString() + "\r\n");

                GF.printError("FILE : " + new StackTrace(ex, true).GetFrame(0).GetFileName());
                GF.printError("LINE : " + new StackTrace(ex, true).GetFrame(0).GetFileLineNumber());

                GF.printError("STACK-TRACE : \r\n" + ex.StackTrace.ToString() + "\r\n");

                GF.submitErrorLog();
                waitHandle.WaitOne();
                /*MessageBox.Show("Whoops! Please contact the developers with the following"
                      + " information:\n\n" + ex.Message + ex.StackTrace,
                      "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);*/
            }
            finally
            {
                foreach (Process theProcess in Process.GetProcessesByName("EXCEL"))
                    theProcess.Kill();

                if (currentProcess != null)
                    foreach (Process theProcess in Process.GetProcessesByName("FAMS"))
                        theProcess.Kill();

                System.Environment.Exit(0);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                GF.closeLoading();
                Exception ex = (Exception)e.Exception;

                GF.printError("********** THREAD FATAL ERROR **********");
                GF.printError("[" + ex.TargetSite.ToString() + "]");
                GF.printError(ex.ToString() + "\r\n");

                GF.printError("FILE : " + new StackTrace(ex, true).GetFrame(0).GetFileName());
                GF.printError("LINE : " + new StackTrace(ex, true).GetFrame(0).GetFileLineNumber());

                GF.printError("STACK-TRACE : \r\n" + ex.StackTrace.ToString() + "\r\n");

                GF.submitErrorLog();
                waitHandle.WaitOne();
            }
            finally
            {
                foreach (Process theProcess in Process.GetProcessesByName("EXCEL"))
                    theProcess.Kill();

                if (currentProcess != null)
                    foreach (Process theProcess in Process.GetProcessesByName("FAMS"))
                        theProcess.Kill();
                System.Environment.Exit(0);
            }
        }

        public static void clearDebug()
        {
            EnvDTE80.DTE2 dte;
            dte = (EnvDTE80.DTE2)Marshal.GetActiveObject("VisualStudio.DTE.12.0");
            EnvDTE.OutputWindow outputWin = dte.ToolWindows.OutputWindow;

            EnvDTE.OutputWindowPane pane = outputWin.OutputWindowPanes.Item("Debug");

            // Show the Output window and activate the new pane.
            outputWin.Parent.AutoHides = false;
            outputWin.Parent.Activate();
            pane.Activate();

            // Add a line of text to the new pane.
            pane.OutputString("Some text." + "\r\n");

            pane.Clear();
        }
    }
}
