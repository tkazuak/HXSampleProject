using System;
using System.Data.SqlClient;
using System.Windows;  // MessageBox を使うために必要

namespace HX_Sample_App.ViewModel
{
    public class DatabaseExample
    {
        // データベースに接続するメソッド
        public void ConnectToDatabase()
        {
            // app.config に記載した接続文字列を取得
            // ここでは "MyDbConnection" という名前で接続文字列を取得しています
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ToString();

            // SQL Server への接続
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // データベースへの接続を開く
                    connection.Open();

                    // 接続成功のメッセージボックスを表示
                    MessageBox.Show("データベースに接続しました。", "接続成功", MessageBoxButton.OK, MessageBoxImage.Information);

                    // 実行する SQL クエリを定義
                    string query = "SELECT TOP 10 user_id, user_password FROM dbo.UserInfo";  // dbo.UserInfo テーブルからデータを取得

                    // SQL コマンドを実行する準備
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // クエリを実行して、結果を SqlDataReader で読み込む
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // データを1行ずつ読み取る
                            while (reader.Read())
                            {
                                // 読み取ったデータをメッセージボックスに表示
                                string message = $"User ID: {reader["user_id"]}, User Password: {reader["user_password"]}";
                                MessageBox.Show(message, "ユーザー情報", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 例外が発生した場合、そのエラーメッセージを表示
                    MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
