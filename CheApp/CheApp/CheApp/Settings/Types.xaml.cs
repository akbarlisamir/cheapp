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
    public partial class Types : ContentPage
    {
        private DataAccess dataAccess;
        public Types()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // The instance of CustomersDataAccess
            // is the data binding source
            this.BindingContext = this.dataAccess;
        }

        public void OnAddType(Object o, EventArgs e)
        {
            //if (dataAccess.AddMarket()
            Navigation.PushAsync(new AddType());
        }

        public void OnRemoveAllTypes(Object o, EventArgs e)
        {
            if (this.dataAccess.Types.Any())
            {
                this.dataAccess.DeleteAllTypes();
                this.BindingContext = this.dataAccess;
            }
            Navigation.PopAsync();
        }

        public void OnRemoveType(Object o, EventArgs e)
        {
            if (this.dataAccess.Markets.Any())
            {
                this.dataAccess.DeleteAllTypes();
                this.BindingContext = this.dataAccess;
            }
            Navigation.PopAsync();
        }
    }
}