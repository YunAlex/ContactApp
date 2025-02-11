﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContactApp.Model;

namespace ContactApp
{
    /// <summary>
    /// Логика взаимодействия для ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        /// <summary>
        /// Цвет некоректного ввода.
        /// </summary>
        private readonly Brush _wrongValueColor = Brushes.Red;

        /// <summary>
        /// Цвет корректного ввода.
        /// </summary>
        private readonly Brush _correctValueColor = Brushes.Gray;

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        private string _titleError;

        /// <summary>
        /// Свойство для пердачи данных контакта.
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Возвращает и задает свойство для передачи двнных контакта.
        /// </summary>
        public Contact Contact
        {
            get => _contact;
            set {
                _contact = value;                
                UpdateWindow();               
            }
        }

        public ContactWindow()
        {
            InitializeComponent();                        
        }

        /// <summary>
        /// Заполняет поля формы данными из плоля _note.
        /// </summary>
        private void UpdateWindow()
        {
            ContactWindowNameTextBox.Text = _contact.Name;
            ContactWindowSurnameTextBox.Text = _contact.Surname;
            ContactWindowPatronymicTextBox.Text = _contact.Patronymic;
            ContactWindowPhoneTextBox.Text = _contact.Phone;
        }

        /// <summary>
        /// Обновляет данные в объекте _note.
        /// </summary>
        private void UpdateContact()
        {
            _contact.Surname = ContactWindowSurnameTextBox.Text;
            _contact.Name = ContactWindowNameTextBox.Text;
            _contact.Patronymic = ContactWindowPatronymicTextBox.Text;
            _contact.Phone = ContactWindowPhoneTextBox.Text;
        }

        /// <summary>
        /// Проверяет форму на наличие ошибок.
        /// </summary>
        private bool CheckOnErrors()
        {
            if (_titleError.Length > 1)
            {
                MessageBox.Show(_titleError);
                return false;
            }
            return true;
        }

        private void ContactWindowSurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Surname = ContactWindowSurnameTextBox.Text;
                ContactWindowSurnameTextBox.BorderBrush = _correctValueColor;
                _titleError = "";
            }
            catch (Exception exception)
            {
                ContactWindowSurnameTextBox.BorderBrush = _wrongValueColor;
                _titleError = exception.Message;
            }
        }

        private void ContactWindowNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Name = ContactWindowNameTextBox.Text;
                ContactWindowNameTextBox.BorderBrush = _correctValueColor;
                _titleError = "";
            }
            catch (Exception exception)
            {
                ContactWindowNameTextBox.BorderBrush = _wrongValueColor;
                _titleError = exception.Message;
            }
        }

        private void ContactWindowPatronymicTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Patronymic = ContactWindowPatronymicTextBox.Text;
                ContactWindowPatronymicTextBox.BorderBrush = _correctValueColor;
                _titleError = "";
            }
            catch (Exception exception)
            {
                ContactWindowPatronymicTextBox.BorderBrush = _wrongValueColor;
                _titleError = exception.Message;
            }
        }

        private void ContactWindowPhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Phone = ContactWindowPhoneTextBox.Text;
                ContactWindowPhoneTextBox.BorderBrush = _correctValueColor;
                _titleError = "";
            }
            catch (Exception exception)
            {
                ContactWindowPhoneTextBox.BorderBrush = _wrongValueColor;
                _titleError = exception.Message;
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            CheckOnErrors();
            UpdateContact();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
