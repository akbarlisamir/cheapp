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
    public partial class Markets : ContentPage
    {
        private DataAccess dataAccess;
        public Markets()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }
        // An event that is raised when the page is shown
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.dataAccess = new DataAccess();
            this.BindingContext = this.dataAccess;
        }

        public void OnAddClick(Object o, EventArgs e)
        {
            //if (dataAccess.AddMarket()
            Navigation.PushAsync(new AddMarket());
        }

        public void OnRemoveAllClick(Object o, EventArgs e)
        {
            if (this.dataAccess.Markets.Any())
            {
                this.dataAccess.DeleteAllMarkets();
                this.BindingContext = this.dataAccess;
            }
            Navigation.PopAsync();
        }

        public void OnRemoveClick(Object o, EventArgs e)
        {
            if (this.dataAccess.Markets.Any())
            {
                this.dataAccess.DeleteAllMarkets();
                this.BindingContext = this.dataAccess;
            }
            Navigation.PopAsync();
        }
    }
}