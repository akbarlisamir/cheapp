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

        public void OnSaveAddCategory(Object o, EventArgs e)
        {
            if (dataAccess.AddCategory(categoryvalueE.Text) == 1)
            {
                Navigation.PopAsync();
            }
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