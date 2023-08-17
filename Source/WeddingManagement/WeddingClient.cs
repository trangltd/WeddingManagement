using CryptSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeddingManagement
{
    internal class WeddingClient
    {
        internal static List<Item> listItems = new List<Item>();
        internal static List<Service> listServices = new List<Service>();
        internal static List<Shift> listShifts = new List<Shift>();
        internal static List<LobbyType> listLobbyTypes = new List<LobbyType>();
        internal static List<Lobby> listLobbies = new List<Lobby>();

        internal static Random rand = new Random();

        internal static string sqlConnectionString = ConfigurationManager.AppSettings.Get("Kiet");

        public static string client_id;
        public static short client_priority;
        public static bool Logged_in(string username, string password)
        {
            string query = "select top 1 AccountNo, Password, Priority " +
                "from ACCOUNT where Username=@username";
            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(query, sql))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (password == reader["Password"].ToString() || 
                                Crypter.CheckPassword(password, 
                                reader["Password"].ToString()))
                            {
                                bool skip = false;
                                if (password == reader["Password"].ToString())
                                {
                                    using (SqlCommand changepass = 
                                        new SqlCommand("update top (1) ACCOUNT " +
                                        "set Password = @password " +
                                        "where AccountNo = @accountno", sql))
                                    {
                                        changepass.Parameters.AddWithValue("@password", 
                                            Crypter.Blowfish.Crypt(password));
                                        changepass.Parameters.AddWithValue("@accountno", 
                                            reader["AccountNo"].ToString());
                                        reader.Close();
                                        changepass.ExecuteNonQuery();
                                        skip = true;
                                        return false;
                                    }
                                }
                                if (!skip)
                                {
                                    string accountno = reader["AccountNo"].ToString();
                                    string str_id = accountno;
                                    while (accountno.Length < 19) accountno = '0' + accountno;
                                    client_id = accountno;
                                    client_priority = (short)reader["Priority"];
                                    return true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Wrong password");
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Wrong username");
                            return false;
                        }
                    }
                }
                MessageBox.Show("Cannot connect to Database");
                return false;
            }
        }
        internal static Int64 NextInt64(Random rand)
        {
            var buffer = new byte[sizeof(Int64)];
            rand.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        private static bool check_existed_username(string username)
        {
            string query = "select top 1 AccountNo from ACCOUNT where Username=@username";
            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(query, sql))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }

        internal static long GetNewACCOUNTSId()
        {
            Int64 randomid = 0;
            while (randomid <= 0 || check_existed_id(randomid))
            {
                randomid = NextInt64(rand);
            }
            return randomid;
        }

        internal static long GetNewIdFromTable(string tableKey)
        {
            if (tableKey.Length > 2) throw new Exception("Table key is too long");
            Int64 randomid = 0;
            while (randomid <= 0 || check_existed_id(randomid, tableKey))
            {
                randomid = NextInt64(rand);
            }
            return randomid;
        }

        private static bool check_existed_id(long randomid, string key)
        {
            if (randomid > 0)
            {
                switch (key)
                {
                    case "LT":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("LOBBY_TYPE", "LobbyTypeNo", idStr);
                        }
                    case "LO":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("LOBBY", "LobbyNo", idStr);
                        }
                    case "SH":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("SHIFT", "ShiftNo", idStr);
                        }
                    case "WD":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("WEDDING", "WeddingNo", idStr);
                        }
                    case "MN":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("MENU", "ItemNo", idStr);
                        }
                    case "SV":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("SERVICE", "ServiceNo", idStr);
                        }
                    case "BI":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("BILL", "BillNo", idStr);
                        }
                    case "RR":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("REVENUE_REPORT", "ReportNo", idStr);
                        }
                    case "PA":
                        {
                            string idStr = key + randomid.ToString().PadLeft(19, '0');
                            return check_existed_id("PARAMETER", "ParameterNo", idStr);
                        }
                    default:
                        throw new Exception("Unknown table key");
                }
            }
            else
            {
                return true;
            }
        }

        private static bool check_existed_id(string table, string idColumn, string key)
        {
            string query = "select top 1 * from " + table + " where " + idColumn + "=@id";
            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(query, sql))
                {
                    command.Parameters.AddWithValue("@id", key.PadLeft(19, '0'));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }

        private static bool check_existed_id(long randomid)
        {
            if (randomid > 0)
            {
                string query = "select top 1 AccountNo from ACCOUNT where AccountNo=@id";
                using (SqlConnection sql = new SqlConnection(sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand(query, sql))
                    {
                        command.Parameters.AddWithValue("@id", randomid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                            else return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
