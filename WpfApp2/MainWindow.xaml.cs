using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();

            login_Button.IsEnabled = users.Any();
        }

        private bool CheckEmailIndividual(string email)
        {
            return !users.Any(i => i.Email == email);
        }

        private bool CheckUserData(string email, string password)
        {
            return users.Contains(new User(email, password));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new LoginWindow("Login");
            dialog.CheckUserData += CheckUserData;
            if (dialog.ShowDialog() == true)
            {
                var user = dialog.User;
                MessageBox.Show($"Welcome, {user.Email}!");
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)//add account
        {
            var dialog = new LoginWindow("Sign up");
            dialog.CheckEmailIndividual += CheckEmailIndividual;
            if (dialog.ShowDialog() == true)
            {
                users.Add(dialog.User);
                MessageBox.Show("You have successfully registered!");
                login_Button.IsEnabled = users.Any();
            }
        }
    }
}
