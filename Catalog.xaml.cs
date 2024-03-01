using MarkEdPlace.model;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        private MarkEdPlaceContext db;
        private User currentUser;

        internal Catalog(User user)
        {
            InitializeComponent();
            currentUser = user;
            db = ((App)App.Current).db;
            db.Users.Update(user);

            Products.ItemsSource = db.Products.ToList();
        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            Button buttonSender = (Button)sender;
            Product product = (Product)buttonSender.DataContext;
            
            buttonSender.IsEnabled = false;
            buttonSender.Content = "Добавлено";
            if (db.Cart.FirstOrDefault(cart => cart.ProductID == product.ID && cart.UserID == currentUser.ID) is not null)
                return;
            db.Cart.Add(new Cart(currentUser, product, 1));
            db.SaveChanges();
        }

        private void OpenCartWindow(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).ReplaceWindow(this, new CartWindow(currentUser));
        }

        private void SearchFilterChanged(object sender, TextChangedEventArgs e)
        {
            Products.ItemsSource = db.Products.Where(p => Search.Text == "" || p.Name.Contains(Search.Text)).ToList();
        }

        private void OpenPersonalAccount(object sender, RoutedEventArgs e)
        {
            new PersonalAccountWindow(currentUser).Show();
            Close();
        }
    }
}
