using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;
using WebApplication1.repositories;

namespace WebApplication1.services
{
    public class ProductoColeccion : IProductoColeccion
    {

        internal MongoDbRepository _repository = new MongoDbRepository(); // inyectando el repositorio
        private IMongoCollection<Producto> collection;

        public ProductoColeccion()
        {
            collection = _repository.db.GetCollection<Producto>("productos");
        }

        public async Task createProducto(Producto producto)
        {
            await collection.InsertOneAsync(producto);
        }

        public async Task deleteProductoById(string id)
        {
          
            var producto = Builders<Producto>.Filter.Eq(p => p.id, id);
            await collection.DeleteOneAsync(producto);
        }

        public async Task<List<Producto>> getAllProductos()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Producto> getProductoById(string id)
        {
             return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
             .Result.FirstOrDefaultAsync();

           
        }

        public async Task updateProducto(Producto producto) // task es el tipo void ,pero asincrono
        {
            var productoDB = Builders<Producto>.Filter.Eq(p => p.id, producto.id);
            await collection.ReplaceOneAsync(productoDB, producto);
        }
    }
}
