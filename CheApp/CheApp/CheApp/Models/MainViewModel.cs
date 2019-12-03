using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace CheApp.Models
{
    [Table("MainViewModels")]
    public class MainViewModel
    {
        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                this._productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }
        private string _marketName;
        public string MarketName
        {
            get
            {
                return _marketName;
            }
            set
            {
                this._marketName = value;
                OnPropertyChanged(nameof(MarketName));
            }
        }
        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                this._price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
