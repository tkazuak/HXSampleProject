using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HX_Sample_App.ViewModel
{ 
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// プロパティ変更通知を送信する
    /// </summary>
    /// <param name="propertyName">変更されたプロパティ名</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty));
    }

    /// <summary>
    /// フィールド値を更新し、プロパティ変更通知を送信する
    /// </summary>
    /// <typeparam name="T">プロパティの型</typeparam>
    /// <param name="field">変更する対象のフィールド</param>
    /// <param name="value">新しい値</param>
    /// <param name="propertyName">プロパティ名</param>
    /// <returns>値が変更された場合はtrue、変更されなかった場合はfalse</returns>
    protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    /// <summary>
    /// IDisposableの実装: 必要ならリソースを解放する
    /// </summary>
    public virtual void Dispose()
    {
        // 派生クラスでリソース解放処理が必要な場合にオーバーライドする
    }
}
}
