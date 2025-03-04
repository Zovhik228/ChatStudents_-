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
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : UserControl
    {
        public Message(Messages Messages, Users UserFrom)
        {
            InitializeComponent();
            imgUser.Source = BitmapFromArrayByte.LoadImage(UserFrom.Photo);
            FIO.Content = UserFrom.ToFIO();
            tbMessage.Text = Messages.Message;
        }
    }
}
