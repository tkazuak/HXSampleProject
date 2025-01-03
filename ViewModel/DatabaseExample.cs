using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;

namespace HX_Sample_App.ViewModel
{
    public class DatabaseExample
    {
        public void ConnectToDatabase()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ToString();

            // SQL Server への接続
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL クエリを作成
                    string query = "SELECT TOP 10 * FROM dbo.UserInfo";

                    // SQL コマンドを実行
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // データを読み取る
                    while (reader.Read())
                    {
                        Console.WriteLine("User ID: " + reader["user_id"]);
                        Console.WriteLine("User Password: " + reader["user_password"]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("エラー: " + ex.Message);
                }
            }
        }
    }
}
