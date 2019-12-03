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
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            InitializeComponent();
        }

        public void MarketsSetting(Object o, EventArgs e)
        {
            Navigation.PushAsync(new Markets());
        }

        public void TypesSetting(Object o, EventArgs e)
        {
            Navigation.PushAsync(new Types());
        }

        public void CategoriesSetting(Object o, EventArgs e)
        {
            Navigation.PushAsync(new Categories());
        }

        void Home_Clicked(Object o, EventArgs e)
        {

        }
    }
}