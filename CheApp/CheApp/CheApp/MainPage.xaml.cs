using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CheApp.Models;
using SQLite;
using CheApp.Settings;

namespace CheApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private DataAccess dataAccess;
        public MainPage()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.dataAccess = new DataAccess();

            this.BindingContext = this.dataAccess;
        }

        public void OnTextChanged(Object o, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)o;

        }


        public void OnRemoveAllProducts(Object o, EventArgs e)
        {
            if (this.dataAccess.Products.Any())
            {
                this.dataAccess.DeleteAllProducts();
                this.BindingContext = this.dataAccess;
            }
            OnAppearing();
        }

        void New_Clicked(Object o, EventArgs e)
        {
            Navigation.PushAsync(new ProductEntryPage());
        }

        void Settings_Clicked(Object o, EventArgs e)
        {
            Navigation.PushAsync(new Setting());
        }

        void Home_Clicked(Object o, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        #region Comment
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    ProductsView.ItemsSource = dataAccess.database.Query<Product>("SELECT * FROM " +
        //            "Products").ToList();

        //ProductsView.ItemsSource = dataAccess.database.Query<Product>("SELECT ProductName, Price, MarketName FROM " +
        //        "Products INNER JOIN Markets ON Products.MarketId = Markets.Id").ToList();
        //using (SQLiteConnection con = new SQLiteConnection(App.filePath))
        //{
        //    con.CreateTable<Product>();
        //    var source = con.Table<Product>();

        //productsLV.ItemsSource = products.OrderByDescending(d => d.Price).ToList();

        /*
         * var sales = db.Sales
.Where(sale => sale.DateOfSale > startDate && sale.DateOfSale < endDate)
.GroupBy(
sale => new {sale.ItemID, sale.EstimatedShipping},
sale => sale.ActualShipping)
.ToList();*/


        //var source = con.Query<Product>("SELECT ProductName, Price, MarketID FROM Product GROUP BY MarketID " +
        //    "ORDER BY Price");


        //}
        //}


        //ProductsView.ItemsSource = q.ToList();
        //}

        //public void lv()
        //{
        //    var q = database.Query<MusicItems>(
        //"select MI.Name, MI.ResId, MI.Tension from MusicItems MI"
        //+ " inner join MusicInThemes MT"
        //+ " on MI.ResId = MT.ResId where MT.ThemeId = ?",
        //ThemeID).ToList();
        //    return q.Select(x => new Playlist { Name = x.Name, ResId = x.ResId, LoopStart = x.LoopStart });
        //}


        // The instance of CustomersDataAccess
        // is the data binding source
        //this.BindingContext = this.dataAccess;
        //var q = dataAccess.database.Query<Product>("SELECT p.ProductName, p.Price, m.MarketName FROM Products p " +
        //    //    "INNER JOIN Markets m on p.MarketId = m.Id").ToList();

        //var q = from prod in dataAccess.database.Table<Product>()
        //        join mar in dataAccess.database.Table<Market>() on prod.MarketId equals mar.Id
        //        select prod;
        #endregion
    }
}
