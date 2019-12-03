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
    public partial class AddCategory : ContentPage
    {
        private DataAccess dataAccess;
        public AddCategory()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }
        
        public void Cancel(Object o, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnSaveAddCategory(Object o, EventArgs e)
        {
            if (dataAccess.AddCategory(categoryvalueE.Text) == 1)
            {
                Navigation.PopAsync();
            }
        }
    }
}