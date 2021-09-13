using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;
using WebApplication1.repositories;
using WebApplication1.services;

namespace WebApplication1.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        // inyectando el servicio
        private IProductoColeccion productoColeccion = new ProductoColeccion();
        [HttpGet]
        public async Task <IActionResult> listarProductos()
        {
            return Ok(await productoColeccion.getAllProductos());
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> obtenerProductDetails(string id)
        {
            var producto = await productoColeccion.getProductoById(id);

            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> insertarProducto([FromBody] Producto producto)
        {
            await productoColeccion.createProducto(producto);
            return Created("Producto creado",true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> modificarProducto([FromBody] Producto producto, string id)
        {
            var productoDB = await productoColeccion.getProductoById(id);
            if (productoDB == null)
            {
                return NotFound();
            }
            producto.id = id;
            await productoColeccion.updateProducto(producto);
            return Created("Producto modificado", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> borrarProducto(string id)
        {

            var producto = await productoColeccion.getProductoById(id);

            if (producto == null)
            {
                return NotFound();
            }
            await productoColeccion.deleteProductoById(id);
            return NoContent();//succes
        }

    }
}
