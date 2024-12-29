using HX_Sample_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HX_Sample_App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand ShowView1Command { get; }
        public ICommand ShowView2Command { get; }

        public MainViewModel()
        {
            // 初期画面を設定
            CurrentView = new View1();

            // コマンドを初期化
            ShowView1Command = new RelayCommand(_ => CurrentView = new View.View1());
            ShowView2Command = new RelayCommand(_ => CurrentView = new View.View2());
        }

    }
}