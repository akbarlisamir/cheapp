using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace CheApp.Models
{
    [Table("Products")]
    public class Product : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _productName;
        [NotNull]
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
        private double _price;
        [NotNull]
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
        private string _categoryName;
        [NotNull]
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                this._categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }
        private string _marketName;
        [NotNull]
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
        private string _typeName;
        [NotNull]
        public string TypeName
        {
            get
            {
                return _typeName;
            }
            set
            {
                this._typeName = value;
                OnPropertyChanged(nameof(TypeName));
            }
        }
        public DateTime CreatedDateTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
