using System.Windows;
using GUI.ViewModels.Classes;

namespace GUI.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }
    }
}