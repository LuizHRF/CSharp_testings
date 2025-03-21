using System.Windows;
using PeopleApp.ViewModels;

namespace PeopleApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel? _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = DataContext as MainWindowViewModel;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.AddPerson(PeopleNameInput.Text, PeopleAgeInput.Text);
            PeopleNameInput.Clear();
            PeopleAgeInput.Clear();
        }
    }
}
