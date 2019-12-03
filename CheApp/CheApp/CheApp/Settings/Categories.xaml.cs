using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheApp.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categories : ContentPage
    {
        private DataAccess dataAccess;
        public Categories()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // The instance of CustomersDataAccess
            // is the data binding source
            this.dataAccess = new DataAccess();
            this.BindingContext = this.dataAccess;
        }

        public void OnAddCategory(Object o, EventArgs e)
        {
            //if (dataAccess.AddMarket()
            Navigation.PushAsync(new AddCategory());
        }

        public void OnRemoveAllCategories(Object o, EventArgs e)
        {
            if (this.dataAccess.Categories.Any())
            {
                this.dataAccess.DeleteAllCategories();
                this.BindingContext = this.dataAccess;
            }
            Navigation.PopAsync();
        }

        public void BackToHome(Object o, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        public void OnRemoveCategory(Object o, EventArgs e)
        {
            if (this.dataAccess.Categories.Any())
            {
                this.dataAccess.DeleteAllCategories();
                this.BindingContext = this.dataAccess;
            }
            Navigation.PopAsync();
        }
    }
}