using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using PeopleApp.Models;

namespace PeopleApp.ViewModels;

public class MainWindowViewModel
{
    public ObservableCollection<Person> People { get; } = new();

    public MainWindowViewModel()
    {
        // Sample data
        People.Add(new Person { Name = "Nome_automatico", Age = 10 });
        People.Add(new Person { Name = "Nome_automatico_2", Age = 2 });
    }

    public void AddPerson(string name, string age)
    {
        if (!string.IsNullOrWhiteSpace(name))

            if (int.TryParse(age, out int ageInt))
            People.Add(new Person { Name = name, Age = ageInt });
    }

}