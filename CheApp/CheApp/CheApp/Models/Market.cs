using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace CheApp.Models
{
    [Table("Markets")]
    public class Market : INotifyPropertyChanged
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
        private string _address;
        [MaxLength(50)]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                this._address = value;
                OnPropertyChanged(nameof(Address));
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
