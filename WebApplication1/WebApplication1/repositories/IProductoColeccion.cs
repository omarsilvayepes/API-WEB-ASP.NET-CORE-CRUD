using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;

namespace WebApplication1.repositories
{
    interface IProductoColeccion
    {
        Task createProducto(Producto producto);// Task  es para que el flujo sea asincrono
        Task<Producto> getProductoById(String id);
        Task updateProducto(Producto producto);
       
        Task deleteProductoById(String id);
        Task<List<Producto>> getAllProductos();
    }
}
