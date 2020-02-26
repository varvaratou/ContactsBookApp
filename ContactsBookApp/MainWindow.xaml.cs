using ContactsBookApp.Models;
using System.Windows;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;

namespace ContactsBookApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts = new ObservableCollection<Contact>();

        public MainWindow()
        {
            InitializeComponent();
            ContactsBox.ItemsSource = Contacts;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Contact Contact = new Contact();
            Contact.FirstName = FirstNameBox.Text;
            Contact.LastName = LastNameBox.Text;
            Contact.Email = EmailAddressBox.Text;
            Contact.Phone = PhoneNumberBox.Text;
            Contacts.Add(Contact);
            FirstNameBox.Clear();
            LastNameBox.Clear();
            EmailAddressBox.Clear();
            PhoneNumberBox.Clear();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(Contacts);

            File.WriteAllText("contacts.json", jsonString);
        }
    }
}
