using System.Collections.Generic;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.Services.xUTest.Infrastructure
{
    class TestPreparation
    {
        public static IEnumerable<User> CreateUsers()
        {
            return new[] {
                new User {UserId = 1, Name = "Rania", UserName = "rania",Password="koko"},
                new User {UserId = 2, Name = "Lara Radwan", UserName = "lara",Password="koko"},
                new User {UserId = 3, Name = "Seif Radwan", UserName = "Seif",Password="koko"},
                new User {UserId = 4, Name = "Mohamed Radwan", UserName = "mradwan",Password="koko"}
            };
        }

        public static IEnumerable<Product> CreateProducts()
        {
            return new[] {
                new Product {ProductId = 1,Code="Code 1", Title = "Product 1", Description = "Description 1",Category="Category 1"},
                new Product {ProductId = 2,Code="Code 2", Title = "Product 2", Description = "Description 2",Category="Category 2"},
                new Product {ProductId = 3,Code="Code 3", Title = "Product 3", Description = "Description 3",Category="Category 3"},
                new Product {ProductId = 4,Code="Code 4", Title = "Product 4", Description = "Description 4",Category="Category 4"}
            };
        }


    }
}
