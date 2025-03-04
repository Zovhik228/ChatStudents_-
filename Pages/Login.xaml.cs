using ChatStudents_Пешков.Classes;
using ChatStudents_Пешков.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatStudents_Пешков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string srcUserImage = "";
        UsersContext usersContext = new UsersContext();

        public Login()
        {
            InitializeComponent();
        }
        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите фотографию:";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                srcUserImage = openFileDialog.FileName;
            }
        }

        public bool CheckEmpty(string Pattern, string Input)
        {
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty("^[А-ЯёЁ][а-яА-ЯёЁ]*$", Lastname.Text))
            {
                MessageBox.Show("Укажите фамилию!");
                return;
            }
            if (!CheckEmpty("^[А-ЯёЁ][а-яА-ЯёЁ]*$", Firstname.Text))
            {
                MessageBox.Show("Укажите имя!");
                return;
            }
            if (!CheckEmpty("^[А-ЯёЁ][а-яА-ЯёЁ]*$", Surname.Text))
            {
                MessageBox.Show("Укажите отчество!");
                return;
            }
            if (String.IsNullOrEmpty(srcUserImage))
            {
                MessageBox.Show("Выберите фотографию!");
                return;
            }
            if (usersContext.Users.Where(x => x.Firstname == Firstname.Text && x.Lastname == Lastname.Text && x.Surname == Surname.Text).Count() > 0)
            {
                MainWindow.Instance.LoginUser = usersContext.Users.Where(x => x.Firstname == Firstname.Text && x.Lastname == Lastname.Text && x.Surname == Surname.Text).First();
                MainWindow.Instance.LoginUser.Photo = File.ReadAllBytes(srcUserImage);
                usersContext.SaveChanges();
            }
            else
            {
                usersContext.Users.Add(new Users(Lastname.Text, Firstname.Text, Surname.Text, File.ReadAllBytes(srcUserImage)));
                usersContext.SaveChanges();
                MainWindow.Instance.LoginUser = usersContext.Users.Where(x => x.Firstname == Firstname.Text && x.Lastname == Lastname.Text && x.Surname == Surname.Text).First();
            }
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
    }
}