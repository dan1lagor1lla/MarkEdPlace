using MarkEdPlace.model;
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
using System.Windows.Shapes;

namespace MarkEdPlace
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void OpenAuthorizationWindow(object sender, MouseButtonEventArgs e) => ((App)App.Current).ReplaceWindow(this, new AuthorizationWindow());

        private void TryRegister(object sender, RoutedEventArgs e)
        {
            using (MarkEdPlaceContext db = new())
            {
                if (string.IsNullOrEmpty(LoginInput.Text) || string.IsNullOrEmpty(EmailInput.Text) || string.IsNullOrEmpty(PasswordInput.Text))
                {
                    new AlertWindow("Заполните все поля.") { Owner = this }.ShowDialog();
                    return;
                }
                if (db.Users.FirstOrDefault(user => user.Login == LoginInput.Text) is not null)
                {
                    new AlertWindow("Данный логин уже занят.") { Owner = this }.ShowDialog();
                    return;
                }
                if (db.Users.FirstOrDefault(user => user.Email == EmailInput.Text) is not null)
                {
                    new AlertWindow("Данная почта уже занята.") { Owner = this }.ShowDialog();
                    return;
                }
                if (PasswordInput.Text != PasswordCheckInput.Text)
                {
                    new AlertWindow("Пароли не совпадают.") { Owner = this }.ShowDialog();
                    return;
                }
                db.Users.Add(new User(LoginInput.Text, EmailInput.Text, PasswordInput.Text));
                db.SaveChanges();
                new AlertWindow("Поздравляем! Вы зарегистрировались.") { Owner = this }.ShowDialog();
                ((App)App.Current).ReplaceWindow(this, new AuthorizationWindow());
            }
        }
    }
}
