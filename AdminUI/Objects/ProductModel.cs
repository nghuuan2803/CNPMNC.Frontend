﻿using Faker;

namespace AdminUI.Objects
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public ProductModel(int id, string name, string? description, int quantity, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }

        public ProductModel()
        {
        }

        public static List<ProductModel> GenData()
        {
            var list = new List<ProductModel>();
            for (int i = 1; i < 50; i++)
            {
                
                list.Add(new ProductModel(i,"product "+((char)(i+64)).ToString(),Lorem.Paragraph(),100+(i*10),1000000+(i*500000)));
            }
            return list;
        }
    }
}
