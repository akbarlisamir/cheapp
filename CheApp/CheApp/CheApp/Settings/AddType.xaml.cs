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
    public partial class AddType : ContentPage
    {
        private DataAccess dataAccess;
        public AddType()
        {
            InitializeComponent();
            this.dataAccess = new DataAccess();
        }

        public void OnSaveAddType(Object o, EventArgs e)
        {
            if (dataAccess.AddType(typevalueE.Text) == 1)
            {
                Navigation.PopAsync();
            }
        }
    }
}