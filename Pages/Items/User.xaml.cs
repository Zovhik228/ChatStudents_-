﻿using ChatStudents_Пешков.Classes.Common;
using ChatStudents_Пешков.Models;
using System;
using System.Collections.Generic;
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

namespace ChatStudents_Пешков.Pages.Items
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        Users user;
        Main main;
        public User(Users user, Main main)
        {
            InitializeComponent();
            this.main = main;
            this.user = user;
            imgUser.Source = BitmapFromArrayByte.LoadImage(user.Photo);
            FIO.Content = user.ToFIO();
        }
        private void SelectChat(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            main.SelectUser(user);
        }

    }
}