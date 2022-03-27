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
            throw new NotImplementedException();
        }
    }
}