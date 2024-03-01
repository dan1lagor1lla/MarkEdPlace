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
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private MarkEdPlaceContext db;
        private User user;

        internal CartWindow(User user)
        {
            InitializeComponent();
            db = ((App)App.Current).db;
            this.user = user;
            ProductQuantity.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity).ToString();
            Summary.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity * a.Product.Cost).ToString();
            Products.ItemsSource = db.Cart.Where(cart => cart.User == user).Include(cart => cart.Product).ThenInclude(product => product.Vendor).ToList();
        }

        private void PlusProduct(object sender, RoutedEventArgs e)
        {
            Cart cart = (Cart)((Button)sender).DataContext;
            if (cart.Quantity + 1 > cart.Product.Quantity)
                return;
            cart.Quantity += 1;
            db.SaveChanges();
            Products.Items.Refresh();
            ProductQuantity.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity).ToString();
            Summary.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity * a.Product.Cost).ToString();

        }

        private void MinusProduct(object sender, RoutedEventArgs e)
        {
            Cart cart = (Cart)((Button)sender).DataContext;
            if (cart.Quantity == 1)
                return;
            cart.Quantity -= 1;
            db.SaveChanges();
            Products.Items.Refresh();
            ProductQuantity.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity).ToString();
            Summary.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity * a.Product.Cost).ToString();

        }

        private void DeleteFromCart(object sender, RoutedEventArgs e)
        {
            Cart cart = (Cart)((Button)sender).DataContext;
            db.Cart.Remove(cart);
            db.SaveChanges();
            Products.ItemsSource = db.Cart.Local.ToList();
            ProductQuantity.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity).ToString();
            Summary.Text = db.Cart.Where(cart => cart.User == user).Sum(a => a.Quantity * a.Product.Cost).ToString();
        }

        private void BackToCatalog(object sender, RoutedEventArgs e) => ((App)App.Current).ReplaceWindow(this, new Catalog(user));
    }
}
