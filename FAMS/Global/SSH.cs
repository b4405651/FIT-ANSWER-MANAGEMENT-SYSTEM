using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Web;
//Add MySql Library
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

// SSH
using Renci.SshNet;
using Renci.SshNet.Common;

namespace FAMS
{
    public struct Param
    {
        public String key;
        public Object value;
        public MySqlDbType type;
        public Boolean encrypt;

        public Param(String theKey, Object theValue, MySqlDbType theType, Boolean theEncrypt = false)
        {
            key = theKey;
            value = theValue;
            type = theType;
            encrypt = theEncrypt;
        }
    }
    public static class SSH
    {
        static SshClient client;
        static MySqlConnection connection;
        static MySqlDataAdapter da;
        static DataSet ds;

        static SSH()
        {
            if (!DB.IsServerAlive()) Application.Exit();
            if (!DB.IsDBAlive()) Application.Exit();
        }
        static Boolean initSSH()
        {
            try
            {
                PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo("fit-answer.com", GF.SSH_Port, "fitanswer", "9OeqLQfnI");
                connectionInfo.Timeout = TimeSpan.FromSeconds(30);
                client = new SshClient(connectionInfo);

                Console.WriteLine("[SSH] Trying SSH connection...\r\n");
                client.Connect();

                if (!client.IsConnected)
                {
                    Console.WriteLine("[SSH] Connection has failed: {0}", client.ConnectionInfo.ToString());
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    Console.WriteLine("[SSH] Host : {0}", client.ConnectionInfo.Host);
                    Console.WriteLine("[SSH] Port : {0}", client.ConnectionInfo.Port.ToString());
                    Console.WriteLine("[SSH] Username : {0}", client.ConnectionInfo.Username);
                    Console.WriteLine();
                    Console.WriteLine("[SSH] connection is active: {0}", client.ConnectionInfo.ToString());

                    return true;
                }
            }
            catch (SshException e)
            {
                Console.WriteLine("[SSH] Client connection error: {0}", e.Message);
                return false;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine("[SSH] Socket connection error: {0}", e.Message);
                return false;
            }
        }

        static Boolean forwardPort()
        {
            try
            {
                Console.WriteLine("\r\n[PF] Trying port forwarding...\r\n");
                var portFwld = new ForwardedPortLocal("127.0.0.1", Convert.ToUInt32(3306), "127.0.0.1", Convert.ToUInt32(3306));

                Console.WriteLine("[PF] Bound Host : {0}:{1}", ((ForwardedPortLocal)portFwld).BoundHost, ((ForwardedPortLocal)portFwld).BoundPort);
                Console.WriteLine("[PF] Local Host : {0}:{1}\r\n", ((ForwardedPortLocal)portFwld).Host, ((ForwardedPortLocal)portFwld).Port);

                client.AddForwardedPort(portFwld);

                portFwld.Start();
                if (!portFwld.IsStarted)
                {
                    Console.WriteLine("[PF] Port forwarding has failed.\r\n");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    Console.WriteLine("[PF] Port forwarded: {0}\r\n", portFwld.ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[PF] Port Forwarding is ERROR !!\r\n\r\n[PF] Error Message : {0}\r\n[PF] Stack Trace : {1}\r\n", ex.Message, ex.StackTrace);
                return false;
            }
        }

        static Boolean openDB()
        {
            try
            {
                MySqlConnectionStringBuilder strBuilder = new MySqlConnectionStringBuilder();
                strBuilder.Server = "127.0.0.1";
                strBuilder.Port = 3306;
                strBuilder.Database = "fitanswer_ms";
                strBuilder.UserID = "fitanswer_root";
                strBuilder.Password = "schwarzenegger";

                //string connectionString;
                //connectionString = "SERVER=" + server + "; " + "DATABASE=" + database + "; " + "UID=" + uid + "; " + "PASSWORD=" + password + "; ";
                connection = new MySqlConnection(strBuilder.ConnectionString);
                Console.WriteLine("[DB] CONNECTION STRING : {0}\r\n", strBuilder.ConnectionString);

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("[DB] MySQL Connection is ERROR !!\r\n\r\n[DB] Error Number : {0}\r\n[DB] Error Message : {1}\r\n[DB] Stack Trace : {2}", ex.Number.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }

        static bool closeDB()
        {
            Console.WriteLine("\r\n[DB] Closing DB ... \r\n");
            try
            {
                ds.Dispose(); ds = null;
                da.Dispose(); da = null;

                connection.Close();
                Console.WriteLine("[DB] DB is closed.\r\n");
                return true;
            }
            catch (MySqlException mex)
            {
                Console.WriteLine("[DB] Closing MySQL Error !! : {0}", mex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB] Closing Error !! : {0}", ex.Message);
                return false;
            }
        }

        static bool closeSSH()
        {
            Console.WriteLine("\r\n[SSH] Closing SSH ... \r\n");
            try
            {
                client.Disconnect();
                Console.WriteLine("[SSH] SSH is closed.\r\n");
                return true;
            }
            catch (SshException sshEX)
            {
                Console.WriteLine("[SSH] Closing SSH Error !! : {0}", sshEX.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SSH] Closing Error !! : {0}", ex.Message);
                return false;
            }
        }

        public static DataTable GET(String queryString, List<Param> Params = null)
        {
            try
            {
                if (!initSSH())
                    return null;

                if (!forwardPort())
                    return null;

                if (!openDB())
                    return null;

                MySqlCommand msc = new MySqlCommand(queryString, connection);

                da = new MySqlDataAdapter(msc);
                //da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.MissingSchemaAction = MissingSchemaAction.Add;

                if (Params != null)
                {
                    foreach (Param param in Params)
                    {
                        msc.Parameters.Add(param.key, param.type).Value = (param.encrypt ? base64_encode(param.value.ToString()) : param.value.ToString());
                    }
                }

                Console.WriteLine("[DB] Final QueryString : {0}", getQueryString(msc));

                ds = new DataSet();
                da.Fill(ds, "DATA");
                return ds.Tables[0];
            }
            finally
            {
                closeDB();
                closeSSH();
            }
        }

        static string getQueryString(MySqlCommand cmd)
        {
            string query = cmd.CommandText;
            String[] keys = new string[cmd.Parameters.Count];

            int index = -1;
            foreach (MySqlParameter p in cmd.Parameters)
            {
                index++;
                keys[index] = p.ParameterName;
                //Console.WriteLine("{0} : {1}", (index+1), keys[index]);
            }

            Array.Sort(keys, (x, y) => x.Length.CompareTo(y.Length));

            foreach (String key in keys)
            {
                //Console.WriteLine(query);
                //Console.WriteLine("{0} : {1}", key, cmd.Parameters[key].Value.ToString());
                query = query.Replace(key, cmd.Parameters[key].Value.ToString());
                //Console.WriteLine(query + "\r\n");
            }
            return query;
        }

        static String base64_encode(String raw)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(raw);
            return Convert.ToBase64String(encbuff);
        }

        static string base64_decode(string encodeStr)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodeStr);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
