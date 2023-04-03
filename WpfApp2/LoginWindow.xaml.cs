using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private event Func<string, bool>? checkEmailIndividual;
        private event Func<string, string, bool>? checkUserData;

        public User User
        {
            get => new User(email_TextBox.Text, password_PasswordBox.Password);
            set
            {
                email_TextBox.Text = value.Email;
                password_PasswordBox.Password = value.Password;
            }
        }

        public event Func<string, bool> CheckEmailIndividual
        {
            add => checkEmailIndividual += value;
            remove => checkEmailIndividual -= value;
        }

        public event Func<string, string, bool> CheckUserData
        {
            add => checkUserData += value;
            remove => checkUserData -= value;
        }

        public LoginWindow(string title)
        {
            InitializeComponent();
            Title = title;
        }

        public LoginWindow(string title, User user)
        {
            InitializeComponent();

            Title = title;
            email_TextBox.Text = user.Email;
            password_PasswordBox.Password = user.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(password_PasswordBox.Password.Length < 8)
            {
                MessageBox.Show("Invalid password length", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(email_TextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
            {
                MessageBox.Show("Invalid email regex", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (checkEmailIndividual != null && !checkEmailIndividual.Invoke(email_TextBox.Text))
            {
                MessageBox.Show("Email is already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(checkUserData != null && !checkUserData.Invoke(email_TextBox.Text, password_PasswordBox.Password))
            {
                MessageBox.Show("Something went wrong...", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
