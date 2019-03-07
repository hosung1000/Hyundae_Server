using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
namespace Hyundae_Server.Modules
{
    public class MySql
    {
        MySqlConnection conn;
        MySqlCommand comm;
        private MySqlConnection GetConnection()
        {
            string host = "192.168.3.136";
            string user = "root";
            string pwd = "1234";
            string db = "test_Hyundae";

            string Connstr =
            string.Format(@"server={0};user={1};password={2};database={3};convert zero datetime=True", host, user, pwd, db);

            conn = new MySqlConnection(Connstr);

            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                Console.WriteLine("연결 실패");
                return null;
            }
        }
        public int GetConnectionClose()
        {
            try
            {
                conn.Close();
                return 1;
            }
            catch
            {
                Console.WriteLine("Close 실패");
                return 0;
            }
        }

        public int NonQuery(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.ExecuteNonQuery();
                    return 1;
                }
                else
                {
                    Console.WriteLine("NonQuery try 실행 실패");
                    return 0;
                }
            }
            catch
            {
                Console.WriteLine("NonQuery catch 실행 실패");
                return 0;
            }
        }
        public int NonQuery(string sql,Hashtable ht)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    
                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }
                    
                    comm.ExecuteNonQuery();
                    return 1;
                }
                else
                {
                    Console.WriteLine("NonQuery try 실행 실패");
                    return 0;
                }
            }
            catch
            {
                Console.WriteLine("NonQuery catch 실행 실패");
                return 0;
            }
        }
        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    return comm.ExecuteReader();
                }
                else
                {
                    Console.WriteLine("Reader try 실행 실패");
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Reader catch 실행 실패");
                return null;
            }
        }
        public MySqlDataReader Reader(string sql, Hashtable ht)
        {

            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    return comm.ExecuteReader();
                }
                else
                {
                    Console.WriteLine("Reader try 실행 실패");
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Reader catch 실행 실패");
                return null;
            }

        }
        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }

}