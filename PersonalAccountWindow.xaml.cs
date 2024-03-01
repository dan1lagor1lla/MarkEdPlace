using MarkEdPlace.model;
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
    /// Interaction logic for PersonalAccountWindow.xaml
    /// </summary>
    public partial class PersonalAccountWindow : Window
    {
        private User user;
        private MarkEdPlaceContext db;
        internal PersonalAccountWindow(User user)
        {
            InitializeComponent();
            db = ((App)App.Current).db; 
            DataContext = this.user = user;
        }

        private void LoginChanged(object sender, TextChangedEventArgs e)
        {
            string newLogin = ((TextBox)sender).Text;
            if (db.Users.FirstOrDefault(u => u.Login == newLogin && u.ID != user.ID) is not null)
            {
                ((TextBox)sender).Text = user.Login;
                new AlertWindow("Пользователь с данным логином уже существует!").ShowDialog();
                return;
            }
            user.Login = newLogin;
            db.SaveChanges();
        }

        private void EmailChanged(object sender, TextChangedEventArgs e)
        { 
            string newEmail = ((TextBox)sender).Text;
            if (db.Users.FirstOrDefault(u => u.Email == newEmail && u.ID != user.ID) is not null)
            {
                ((TextBox)sender).Text = user.Email;
                new AlertWindow("Пользователь с данной почтой уже существует!") { Owner = this }.ShowDialog();
                return;
            }
            user.Email = newEmail;
            db.SaveChanges();

        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            if (OldPassword.Text != user.Password)
            {
                new AlertWindow("Неверный пароль!") { Owner = this }.ShowDialog();
                return;
            }
            new AlertWindow("Пароль сменен.") { Owner = this }.ShowDialog();
            OldPassword.Text = "";
            user.Password = NewPassword.Text;
            NewPassword.Text = "";
            db.SaveChanges();
        }

        private void BackToCatalog(object sender, RoutedEventArgs e)
        {
            new Catalog(user).Show();
            Close();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            ((App)App.Current).db.Dispose();
            ((App)App.Current).db = new();
            Close();
        }
    }
}
