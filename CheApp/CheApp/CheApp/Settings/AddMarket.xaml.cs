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
    public partial class AddMarket : ContentPage
    {
        private DataAccess dataAccess;
        public AddMarket()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }

        public void OnSaveAddMarket(Object o, EventArgs e)
        {
            if (dataAccess.AddMarket(marketnameE.Text, addressE.Text) == 1)
            {
                Navigation.PopAsync();
            }
        }
    }
}