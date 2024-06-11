using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        
        private static List<Product> listProducts;

        public static List<Product> GetProducts()
        {

            using var db = new MyStoreContext();
            return db.Products.ToList();
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using var db = new MyStoreContext();
                db.Products.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                using var db = new MyStoreContext();
                var existingProduct = db.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.UnitPrice = product.UnitPrice;
                    existingProduct.UnitsInStock = product.UnitsInStock;
                    existingProduct.CategoryId = product.CategoryId;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using var db = new MyStoreContext();
                var existingProduct = db.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    db.Products.Remove(existingProduct);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static Product GetProductById(int id)
        {
            try
            {
                using var db = new MyStoreContext();
                return db.Products.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


        /*public ProductDAO()
        {
            Product chai = new Product(1, "Chai", 3, 12, 18);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23,10);
            listProducts = new List<Product> { chai, chang, aniseed };
        }
        public List<Product> GetProducts()
        {
            return listProducts;
        }
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var db = new MyStoreContext();
                listProducts = db.Product.ToList();
            }
            catch (Exception e) { }
            return listProducts;
        }

        public void SaveProduct(Product p)
        {
            listProducts.Add(p);
        }
        public void UpdateProduct(Product product)
        {
            foreach(Product p in listProducts.ToList())
            {
                if(p.ProductId == product.ProductId)
                {
                    p.ProductId=product.ProductId;
                    p.ProductName=product.ProductName;
                    p.UnitPrice=product.UnitPrice;
                    p.UnitsInStock=product.UnitsInStock;
                    p.CategoryId=product.CategoryId;
                }
            }
        }

        public void DeleteProduct(Product product)
        {
            foreach (Product p in listProducts.ToList())
            {
                if(p.ProductId == product.ProductId)
                {
                listProducts.Remove(p);
                }
            }
        }
        public Product GetProductById(int id)
        {
            foreach(Product p in listProducts.ToList())
            {
                if(p.ProductId == id)
                {
                    return p;
                }
            }
            return null;
        }*/
    }
}