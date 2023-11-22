using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Window_Author_Registr {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            users.Add(new User("admin", "1234"));
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //bool isValidUser = false;
            foreach (User user in users)
            {
                if (user.login.Equals(loginBox.Text) && user.password.Equals(passwordBox.Password))
                {
                    Window1 win1 = new Window1();
                    win1.Show();
                    this.Close();
                }
                else
                {
                    exceptionBlock.Text = "Неправильный логин или пароль";
                    loginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }
        private void registrButton_Click(object sender, RoutedEventArgs e)
        {
            if (repeatPasswordBox.Password != regPasswordBox.Password)
            {
                exceptionRegistrBlock.Text = "Неверный пароль";
            }
            else if (nameBox.Text == "")
            {
                exceptionRegistrBlock.Text = "Укажите своё имя";
            }
            else if (maleCheckBox.IsChecked != true && femaleCheckBox.IsChecked != true)
            {
                exceptionRegistrBlock.Text = "Укажите свой пол";
            }
            else if (emailBox.Text == "")
            {
                exceptionRegistrBlock.Text = "Укажите свою эл. почту";
            }
            else if (maleCheckBox.IsChecked == true && femaleCheckBox.IsChecked == false)
            {
                users.Add(new User(nameBox.Text, emailBox.Text, "Мужской", regPasswordBox.Password));
                repeatPasswordBox.Password = "";
                regPasswordBox.Password = "";
                nameBox.Text = "";
                emailBox.Text = "";
                maleCheckBox.IsChecked = false;
                exceptionRegistrBlock.Text = "";
                logIn.IsSelected = true;
            }
            else if (femaleCheckBox.IsChecked == true && maleCheckBox.IsChecked == false)
            {
                users.Add(new User(nameBox.Text, emailBox.Text, "Женский", regPasswordBox.Password));
                repeatPasswordBox.Password = "";
                regPasswordBox.Password = "";
                nameBox.Text = "";
                emailBox.Text = "";
                femaleCheckBox.IsChecked = false;
                exceptionRegistrBlock.Text = "";
                logIn.IsSelected = true;
            }
            else if (maleCheckBox.IsChecked == true && femaleCheckBox.IsChecked == true)
            {
                exceptionRegistrBlock.Text = "Не может быть два пола одновременно";
            }
        }
    }

}