using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Context
{
    public class EcommerceDBContext : DbContext
    {
        public EcommerceDBContext(DbContextOptions<EcommerceDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Home & Kitchen" },
                new Category { Id = 5, Name = "Sports & Outdoors" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // Seed Customers
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Alice", Email = "alice@example.com", PasswordHash = "Password123" },
                new Customer { Id = 2, Name = "Bob", Email = "bob@example.com", PasswordHash = "Password123" },
                new Customer { Id = 3, Name = "Charlie", Email = "charlie@example.com", PasswordHash = "Password123" },
                new Customer { Id = 4, Name = "Dave", Email = "dave@example.com", PasswordHash = "Password123" },
                new Customer { Id = 5, Name = "Eve", Email = "eve@example.com", PasswordHash = "Password123" }
            };
            modelBuilder.Entity<Customer>().HasData(customers);

            // Seed Products
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Smartphone", Description = "Latest model with all the features", Price = 699.99M, Stock = 50, CategoryId = 1, ImageUrl = "/../../pics/1.jpg" },
                new Product { Id = 2, Name = "Laptop", Description = "Powerful and portable", Price = 999.99M, Stock = 30, CategoryId = 1, ImageUrl = "/../../pics/2.jpg" },
                new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling over-ear headphones", Price = 199.99M, Stock = 100, CategoryId = 1, ImageUrl = "/../../pics/4.jpg" },
                new Product { Id = 4, Name = "Smartwatch", Description = "Track your fitness and stay connected", Price = 149.99M, Stock = 75, CategoryId = 1, ImageUrl = "/../../pics/4.jpg" },
                new Product { Id = 5, Name = "Bluetooth Speaker", Description = "Portable and powerful sound", Price = 99.99M, Stock = 150, CategoryId = 1, ImageUrl = "/../../pics/5.jpg" },
                new Product { Id = 6, Name = "T-shirt", Description = "Comfortable cotton t-shirt", Price = 19.99M, Stock = 200, CategoryId = 2, ImageUrl = "/../../pics/6.jpg" },
                new Product { Id = 7, Name = "Jeans", Description = "Stylish and durable", Price = 49.99M, Stock = 100, CategoryId = 2, ImageUrl = "/../../pics/7.jpg" },
                new Product { Id = 8, Name = "Jacket", Description = "Warm and fashionable", Price = 89.99M, Stock = 60, CategoryId = 2, ImageUrl = "/../../pics/8.jpg" },
                new Product { Id = 9, Name = "Sneakers", Description = "Comfortable and trendy", Price = 69.99M, Stock = 120, CategoryId = 2, ImageUrl = "/../../pics/9.jpg" },
                new Product { Id = 10, Name = "Hat", Description = "Stylish and protective", Price = 14.99M, Stock = 180, CategoryId = 2, ImageUrl = "/../../pics/10.jpg" },
                new Product { Id = 11, Name = "Fiction Book", Description = "A thrilling novel", Price = 14.99M, Stock = 150, CategoryId = 3, ImageUrl = "/../../pics/11.jpg"},
                new Product { Id = 12, Name = "Non-Fiction Book", Description = "Informative and engaging", Price = 19.99M, Stock = 130, CategoryId = 3, ImageUrl = "/../../pics/12.jpg" },
                new Product { Id = 13, Name = "Cookbook", Description = "Delicious recipes from around the world", Price = 24.99M, Stock = 90, CategoryId = 3, ImageUrl = "/../../pics/13.jpg" },
                new Product { Id = 14, Name = "Children's Book", Description = "Fun and educational", Price = 9.99M, Stock = 170, CategoryId = 3, ImageUrl = "/../../pics/14.jpg" },
                new Product { Id = 15, Name = "Textbook", Description = "Essential for students", Price = 59.99M, Stock = 80, CategoryId = 3, ImageUrl = "/../../pics/15.jpg" },
                new Product { Id = 16, Name = "Blender", Description = "High-speed for smoothies", Price = 49.99M, Stock = 110, CategoryId = 4, ImageUrl = "/../../pics/16.jpg" },
                new Product { Id = 17, Name = "Vacuum Cleaner", Description = "Powerful and efficient", Price = 149.99M, Stock = 50, CategoryId = 4, ImageUrl = "/../../pics/17.jpg" },
                new Product { Id = 18, Name = "Coffee Maker", Description = "Brew the perfect cup", Price = 79.99M, Stock = 70, CategoryId = 4, ImageUrl = "/../../pics/18.jpg" },
                new Product { Id = 19, Name = "Cookware Set", Description = "Non-stick and durable", Price = 99.99M, Stock = 90, CategoryId = 4, ImageUrl = "/../../pics/19.jpg" },
                new Product { Id = 20, Name = "Cutlery Set", Description = "Stainless steel and elegant", Price = 29.99M, Stock = 140, CategoryId = 4, ImageUrl = "/../pics/20.jpg" },
                new Product { Id = 21, Name = "Yoga Mat", Description = "Non-slip and comfortable", Price = 29.99M, Stock = 120, CategoryId = 5, ImageUrl = "/../../pics/21.jpg" },
                new Product { Id = 22, Name = "Dumbbells", Description = "Perfect for strength training", Price = 49.99M, Stock = 80, CategoryId = 5, ImageUrl = "/../../pics/22.jpg" },
                new Product { Id = 23, Name = "Running Shoes", Description = "Lightweight and comfortable", Price = 79.99M, Stock = 110, CategoryId = 5, ImageUrl = "/../../pics/23.jpg" },
                new Product { Id = 24, Name = "Tent", Description = "Perfect for camping", Price = 99.99M, Stock = 60, CategoryId = 5, ImageUrl = "/../../pics/24.jpg" },
                new Product { Id = 25, Name = "Fitness Tracker", Description = "Track your health and activity", Price = 59.99M, Stock = 100, CategoryId = 5, ImageUrl = "/../../pics/25.jpg" }
            };
            modelBuilder.Entity<Product>().HasData(products);

            // Seed Carts
            var carts = new List<Cart>
            {
                new Cart { Id = 1, CustomerId = 1 },
                new Cart { Id = 2, CustomerId = 2 },
                new Cart { Id = 3, CustomerId = 3 },
                new Cart { Id = 4, CustomerId = 4 },
                new Cart { Id = 5, CustomerId = 5 }
            };
            modelBuilder.Entity<Cart>().HasData(carts);

            // Seed CartItems
            var cartItems = new List<CartItem>
            {
                new CartItem { Id = 1, CartId = 1, ProductId = 1, Quantity = 1 },
                new CartItem { Id = 2, CartId = 1, ProductId = 2, Quantity = 1 },
                new CartItem { Id = 3, CartId = 2, ProductId = 3, Quantity = 1 },
                new CartItem { Id = 4, CartId = 2, ProductId = 4, Quantity = 1 },
                new CartItem { Id = 5, CartId = 3, ProductId = 5, Quantity = 1 },
                new CartItem { Id = 6, CartId = 3, ProductId = 6, Quantity = 1 },
                new CartItem { Id = 7, CartId = 4, ProductId = 7, Quantity = 1 },
                new CartItem { Id = 8, CartId = 4, ProductId = 8, Quantity = 1 },
                new CartItem { Id = 9, CartId = 5, ProductId = 9, Quantity = 1 },
                new CartItem { Id = 10, CartId = 5, ProductId = 10, Quantity = 1 }
            };
            modelBuilder.Entity<CartItem>().HasData(cartItems);

            // Seed Orders
            var orders = new List<Order>
            {
                new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.UtcNow },
                new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.UtcNow },
                new Order { Id = 3, CustomerId = 3, OrderDate = DateTime.UtcNow },
                new Order { Id = 4, CustomerId = 4, OrderDate = DateTime.UtcNow },
                new Order { Id = 5, CustomerId = 5, OrderDate = DateTime.UtcNow }
            };
            modelBuilder.Entity<Order>().HasData(orders);

            // Seed OrderItems
            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
                new OrderItem { Id = 2, OrderId = 2, ProductId = 2, Quantity = 2 },
                new OrderItem { Id = 3, OrderId = 3, ProductId = 3, Quantity = 3 },
                new OrderItem { Id = 4, OrderId = 4, ProductId = 4, Quantity = 4 },
                new OrderItem { Id = 5, OrderId = 5, ProductId = 5, Quantity = 5 }
            };
            modelBuilder.Entity<OrderItem>().HasData(orderItems);

            // Seed Reviews
            var reviews = new List<Review>
            {
                new Review { Id = 1, ProductId = 1, CustomerId = 1, Rating = 4, Comment = "Great product!" },
                new Review { Id = 2, ProductId = 2, CustomerId = 2, Rating = 5, Comment = "Excellent quality!" },
                new Review { Id = 3, ProductId = 3, CustomerId = 3, Rating = 3, Comment = "Good value for money." },
               
                new Review { Id = 4, ProductId = 4, CustomerId = 4, Rating = 4, Comment = "Very useful." },
                new Review { Id = 5, ProductId = 5, CustomerId = 5, Rating = 5, Comment = "Highly recommended!" },
                new Review { Id = 6, ProductId = 3, CustomerId = 1, Rating = 2, Comment = "avg value for money." },

            };
            modelBuilder.Entity<Review>().HasData(reviews);

            // Seed Wishlists
            var wishlists = new List<Wishlist>
            {
                new Wishlist { Id = 1, CustomerId = 1 },
                new Wishlist { Id = 2, CustomerId = 2 },
                new Wishlist { Id = 3, CustomerId = 3 },
                new Wishlist { Id = 4, CustomerId = 4 },
                new Wishlist { Id = 5, CustomerId = 5 }
            };
            modelBuilder.Entity<Wishlist>().HasData(wishlists);

            // Seed WishlistItems
            var wishlistItems = new List<WishlistItem>
            {
                new WishlistItem { Id = 1, WishlistId = 1, ProductId = 1 },
                new WishlistItem { Id = 2, WishlistId = 2, ProductId = 2 },
                new WishlistItem { Id = 3, WishlistId = 3, ProductId = 3 },
                new WishlistItem { Id = 4, WishlistId = 4, ProductId = 4 },
                new WishlistItem { Id = 5, WishlistId = 5, ProductId = 5 }
            };
            modelBuilder.Entity<WishlistItem>().HasData(wishlistItems);

            // Seed Promotions
            var promotions = new List<Promotion>
            {
                new Promotion { Id = 1, Code = "SUMMER2024", Description = "Summer sale 2024", DiscountPercentage = 10, StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 31) },
                new Promotion { Id = 2, Code = "WINTER2024", Description = "Winter sale 2024", DiscountPercentage = 15, StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2024, 12, 31) }
            };
            modelBuilder.Entity<Promotion>().HasData(promotions);

            // Seed Notifications
            var notifications = new List<Notification>
            {
                new Notification { Id = 1, CustomerId = 1, Message = "Your order has been shipped.", Date = DateTime.UtcNow },
                new Notification { Id = 2, CustomerId = 2, Message = "Your order has been delivered.", Date = DateTime.UtcNow }
            };
            modelBuilder.Entity<Notification>().HasData(notifications);
        }
    }
}
