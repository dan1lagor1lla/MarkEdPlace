using MarkEdPlace.model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MarkEdPlace
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal MarkEdPlaceContext db = new();

        public void ReplaceWindow(Window oldWindow, Window newWindow)
        {
            newWindow.Show();
            oldWindow.Close();
        }
    }
}
