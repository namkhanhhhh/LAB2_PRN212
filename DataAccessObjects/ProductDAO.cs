using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
            using var db = new MyStoreContext();
                products=db.Products.ToList();
            }catch (Exception ex) { }

            
            return products;
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
    }
}