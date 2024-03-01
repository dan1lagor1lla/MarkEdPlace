using MarkEdPlace.model;
using System.Diagnostics;
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

namespace MarkEdPlace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void OpenRegistrationWindow(object sender, MouseButtonEventArgs e) => ((App)App.Current).ReplaceWindow(this, new RegistrationWindow());

        private void TryLogIn(object sender, RoutedEventArgs e)
        {
            using (MarkEdPlaceContext db = new())
            {
                if (string.IsNullOrEmpty(LoginInput.Text) || string.IsNullOrEmpty(PasswordInput.Text))
                {
                    new AlertWindow("Заполните поля!") { Owner = this }.ShowDialog();
                    return;
                }
                User? user = db.Users.FirstOrDefault(user => user.Login == LoginInput.Text);
                if (user is null)
                {
                    new AlertWindow("Пользователя с данным логином не существует!") { Owner = this }.ShowDialog();
                    return;
                }
                if (user.Password != PasswordInput.Text)
                {
                    new AlertWindow("Вы ввели неверный пароль!") { Owner = this }.ShowDialog();
                    return;
                }
                new Catalog(user).Show();
                Close();
            }
        }
    }
}