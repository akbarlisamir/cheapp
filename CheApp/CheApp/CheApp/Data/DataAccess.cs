using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using CheApp.Models;

namespace CheApp
{
    public class DataAccess
    {
        public SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Market> Markets { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Models.Type> Types { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<MainViewModel> MainViewModels { get; set; }


        public DataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Market>();
            this.Markets = new ObservableCollection<Market>(database.Table<Market>());
            // If the table is empty, initialize the collection
            if (!database.Table<Market>().Any())
            {
                AddNewMarket();
            }

            database.CreateTable<Category>();
            this.Categories = new ObservableCollection<Category>(database.Table<Category>());
            // If the table is empty, initialize the collection
            if (!database.Table<Category>().Any())
            {
                AddNewCategory();
            }

            database.CreateTable<Models.Type>();
            this.Types = new ObservableCollection<Models.Type>(database.Table<Models.Type>());
            // If the table is empty, initialize the collection
            if (!database.Table<Models.Type>().Any())
            {
                AddNewType();
            }

            database.CreateTable<Product>();
            this.Products = new ObservableCollection<Product>(database.Table<Product>());
            if (!database.Table<Product>().Any())
            {
                AddNewProduct();
            }

            database.CreateTable<MainViewModel>();
            this.MainViewModels = new ObservableCollection<MainViewModel>(database.Table<MainViewModel>());
        }


        #region Adding
        public void AddNewMarket()
        {
            this.Markets.
              Add(new Market
              {
                  MarketName = "Market Name",
                  Address = "Market Address"
              });
            //this.Markets.
            //  Add(new Market
            //  {
            //      MarketName = "Aldi",
            //      Address = "Lehel ut"
            //  });
        }

        public void AddNewProduct()
        {
            this.Products.
              Add(new Product
              {
                  ProductName = "Product Name",
                  Price = 0,
                  CategoryName = "category",
                  MarketName = "Market Name",
                  CreatedDateTime = DateTime.Now,
                  TypeName = "type"
              });
            //this.Products.
            //  Add(new Product
            //  {
            //      ProductName = "Butter",
            //      Price = 519,
            //      CategoryName = "food",
            //      MarketName = "Auchan",
            //      CreatedDateTime = DateTime.Now,
            //      TypeName = "kg"
            //  });
            //this.Products.
            //  Add(new Product
            //  {
            //      ProductName = "Bread",
            //      Price = 219,
            //      CategoryName = "food",
            //      MarketName = "Penny",
            //      CreatedDateTime = DateTime.Now,
            //      TypeName = "kg"
            //  });
        }

        public void AddNewCategory()
        {
            this.Categories.
              Add(new Category
              {
                  Value = "value"
              });

            //this.Categories.
            //  Add(new Category
            //  {
            //      Value = "drink"
            //  });

            //this.Categories.
            //  Add(new Category
            //  {
            //      Value = "vegetable"
            //  });

            //this.Categories.
            //  Add(new Category
            //  {
            //      Value = "fruit"
            //  });

            //this.Categories.
            //  Add(new Category
            //  {
            //      Value = "object"
            //  });
        }

        public void AddNewType()
        {
            this.Types.
              Add(new Models.Type
              {
                  Value = "value"
              });

            //this.Types.
            //  Add(new Models.Type
            //  {
            //      Value = "litre"
            //  });

            //this.Types.
            //  Add(new Models.Type
            //  {
            //      Value = "kg"
            //  });

            //this.Types.
            //  Add(new Models.Type
            //  {
            //      Value = "meter"
            //  });
        }
        #endregion

        //public IEnumerable<Market> GetFilteredCustomers(string countryName)
        //{
        //    lock (collisionLock)
        //    {
        //        var query = from cust in database.Table<Customer>()
        //                    where cust.Country == countryName
        //                    select cust;
        //        return query.AsEnumerable();
        //    }
        //}

        #region Get
        #region Market
        public IEnumerable<Market> GetMarkets()
        {
            lock (collisionLock)
            {
                return database.Query<Market>("SELECT * FROM Markets").AsEnumerable();
            }
        }

        public int AddMarket(string mName, string address)
        {
            Market market = new Market()
            {
                MarketName = mName,
                Address = address
            };
            return database.Insert(market);

        }

        public int DeleteMarket(Market market)
        {
            var id = market.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Market>(id);
                }
            }
            this.Markets.Remove(market);
            return 1;
        }
        public void DeleteAllMarkets()
        {
            lock (collisionLock)
            {
                database.DropTable<Market>();
                database.CreateTable<Market>();
            }
            this.Markets = null;
            this.Markets = new ObservableCollection<Market>
              (database.Table<Market>());
        }
        #endregion

        #region Category
        public IEnumerable<Category> GetCategoris()
        {
            lock (collisionLock)
            {
                return database.Query<Category>("SELECT * FROM Categories").AsEnumerable();
            }
        }

        public int AddCategory(string value)
        {
            Category category = new Category()
            {
                Value = value
            };
            return database.Insert(category);

        }

        public int DeleteCategory(Category category)
        {
            var id = category.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Category>(id);
                }
            }
            this.Categories.Remove(category);
            return 1;
        }
        public void DeleteAllCategories()
        {
            lock (collisionLock)
            {
                database.DropTable<Category>();
                database.CreateTable<Category>();
            }
            this.Categories = null;
            this.Categories = new ObservableCollection<Category>
              (database.Table<Category>());
        }
        #endregion

        #region Type
        public IEnumerable<Models.Type> GetTypes()
        {
            lock (collisionLock)
            {
                return database.Query<Models.Type>("SELECT * FROM Types").AsEnumerable();
            }
        }

        public int AddType(string value)
        {
            Models.Type type = new Models.Type()
            {
                Value = value
            };
            return database.Insert(type);

        }

        public int DeleteType(Models.Type type)
        {
            var id = type.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Models.Type>(id);
                }
            }
            this.Types.Remove(type);
            return 1;
        }
        public void DeleteAllTypes()
        {
            lock (collisionLock)
            {
                database.DropTable<Models.Type>();
                database.CreateTable<Models.Type>();
            }
            this.Types = null;
            this.Types = new ObservableCollection<Models.Type>
              (database.Table<Models.Type>());
        }
        #endregion

        #region Product
        public IEnumerable<Product> GetProducts()
        {
            lock (collisionLock)
            {
                //var query = from prod in database.Table<Product>()
                //            join mar in database.Table<Market>() on prod.MarketId equals mar.Id
                //            select prod;
                //return query.AsEnumerable();

                //var q = database.Query<Product>("SELECT p.ProductName, p.Price, m.MarketName FROM Products p " +
                //    "INNER JOIN Markets m on p.MarketId = m.Id").ToList();
                //return q.AsEnumerable();
                return database.Query<Product>("SELECT * FROM Products ORDER BY Price ASC").AsEnumerable();
            }
        }

        public int AddProduct(string pName, double price, string tName, string cName, string mName)
        {
            Product product = new Product()
            {
                ProductName = pName,
                Price = price,
                TypeName = tName,
                CategoryName = cName,
                MarketName = mName,
                CreatedDateTime = DateTime.Now
            };
            return database.Insert(product);

        }

        public IEnumerable<Product> GetProductsForMain()
        {
            lock (collisionLock)
            {
                return database.Query<Product>("SELECT Products.*, Markets.MarketName " +
                    "FROM Products JOIN Markets ON Products.MarketId = Markets.Id").AsEnumerable();
            }
        }

        public IEnumerable<Product> GetProductsF()
        {
            lock (collisionLock)
            {
                var q = database.Query<Product>("SELECT p.ProductName, p.Price, m.MarketName FROM Products p " +
                    "INNER JOIN Markets m on p.MarketId = m.Id").ToList();
                return q.AsEnumerable();
                //var query = from cust in database.Table<Product>()
                //            join 
                //            where cust.Country == countryName
                //            select cust;
                //return query.AsEnumerable();
            }
        }

        public void DeleteAllProducts()
        {
            lock (collisionLock)
            {
                database.DropTable<Product>();
                database.CreateTable<Product>();
            }
            this.Products = null;
            this.Products = new ObservableCollection<Product>
              (database.Table<Product>());
        }
        #endregion
        #endregion
    }
}
