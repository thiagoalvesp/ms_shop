using System;
using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProcuct = productCollection.Find(p=>true).Any();
            if (!existProcuct)
                productCollection.InsertManyAsync(GetMyProducts());

        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>(){
                new Product(){
                    Id = "e994c33cf0a14f3d9ed96131",
                    Name = "Caderno Espiral Pequeno",
                    Description = "Caderno espiral com 100 folhas pequeno",
                    Image = "caderno.png",
                    Price = 7.65M,
                    Category = "MaterialEscolar"
                },
                new Product(){
                    Id = "e994c33cf0a14f3d9ed96132",
                    Name = "Borracha branca pequena",
                    Description = "Borracha branca pequena para lápis",
                    Image = "borracha.png",
                    Price = 4.65M,
                    Category = "MaterialEscolar"
                }
            };
        }
    }
}