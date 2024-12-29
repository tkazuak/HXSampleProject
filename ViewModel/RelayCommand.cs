using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HX_Sample_App.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        /// <summary>
        /// コマンドが実行可能かどうかが変わったときに発生するイベント
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// コンストラクタ: 実行ロジックのみ指定する場合
        /// </summary>
        /// <param name="execute">コマンドの実行ロジック</param>
        public RelayCommand(Action<object?> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// コンストラクタ: 実行ロジックと実行可否ロジックを指定する場合
        /// </summary>
        /// <param name="execute">コマンドの実行ロジック</param>
        /// <param name="canExecute">コマンドの実行可否ロジック</param>
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// コマンドが実行可能かどうかを判断する
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        /// <returns>実行可能ならtrue、そうでなければfalse</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// コマンドを実行する
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}