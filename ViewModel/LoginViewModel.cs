using System;
using System.Windows.Input;

namespace HX_Sample_App.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// ログインボタンのコマンド
        /// </summary>
        public ICommand LogionCheck { get; private set; }

        public LoginViewModel()
        {
            // コマンドの初期化（実行ロジックと実行可否ロジック）
            // RelayCommandは、コマンドの実行メソッド(ExecuteLogin)と実行可否メソッド(CanExecuteLogin)を指定する
            LogionCheck = new RelayCommand(
                ExecuteLogin // ログイン処理を実行するメソッド
                             // , CanExecuteLogin // 必要に応じて、実行可能かどうかを判定するメソッド
            );
        }

        /// <summary>
        /// ログインボタンクリック時の処理
        /// </summary>
        /// <param name="parameter">コマンドが呼び出されたときに渡されるパラメータ</param>
        private void ExecuteLogin(object? parameter)
        {
            // ログイン処理が実行されたことをコンソールに出力
            Console.WriteLine("ログイン処理を実行しました！");

            // データベース接続チェック処理を呼び出す
            // DatabaseExample クラスの ConnectToDatabase メソッドを実行して、DB 接続処理を行う
            DatabaseExample dbcheck = new DatabaseExample();
            dbcheck.ConnectToDatabase();
        }

        // コマンドの実行可否を判定するメソッド（オプション）
        // ここでは、引数として渡される parameter が null でない場合にログイン可能としています
        private bool CanExecuteLogin(object? parameter)
        {
            // 例えば、ログインの条件が入力されたパラメータが null でない場合にログイン可能とする
            return parameter != null;
        }
    }
}
