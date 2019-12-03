using CheApp.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace CheApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductEntryPage : ContentPage
    {
        private DataAccess dataAccess;
        public string categoryPicker;
        public string typePicker;
        public string marketPicker;
        public ProductEntryPage()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.dataAccess;
        }

        public void BackToHome(Object o, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        public void Cancel(Object o, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            double a = 0;
            double.TryParse(priceE.Text, out a);
            if(dataAccess.AddProduct(productE.Text, a, categoryPicker, typePicker,
                marketPicker) == 1)
            {
                Navigation.PopAsync();
            }
        }

        public void SelIndChanged(Object o, EventArgs e)
        {
            categoryPicker = categoryP.Items[categoryP.SelectedIndex].ToString();
        }

        public void SelIndChanged2(Object o, EventArgs e)
        {
            typePicker = typeP.Items[typeP.SelectedIndex].ToString();
        }

        public void SelIndChanged1(Object o, EventArgs e)
        {
            marketPicker = marketP.Items[marketP.SelectedIndex].ToString();
        }

        #region Checking
        int checking_1(string a)
        {
            switch (a)
            {
                case "Lidl":
                    return 1;
                case "Tesco":
                    return 2;
                case "Auchan":
                    return 3;
                case "Aldi":
                    return 4;
                case "Spar":
                    return 5;
                case "Interspar":
                    return 6;
                case "Prima":
                    return 7;
                default:
                    return 0;
            }
        }

        int checking_2(string a)
        {
            switch (a)
            {
                case "kg":
                    return 1;
                case "litre":
                    return 2;
                case "meter":
                    return 3;
                case "piece":
                    return 4;
                default:
                    return 0;
            }
        }

        int checking_3(string a)
        {
            switch (a)
            {
                case "food":
                    return 1;
                case "drink":
                    return 2;
                case "vegetable":
                    return 3;
                case "fruit":
                    return 4;
                case "object":
                    return 5;
                default:
                    return 0;
            }
        }
        #endregion
    }
}