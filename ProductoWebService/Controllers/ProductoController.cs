using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductoWebService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductoWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly ProductoContext _contexto;
        //private CloudStorageAccount storageAccount;


        public ProductoController(ProductoContext contexto, IConfiguration config)
        {
            _contexto = contexto;
            this.configuration = config;

            /*storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
               "123459876", "X9XmzmV0xX6AG/WYCXSA8BrrrCF0M4j3X4zFDgJZ5g9hRwPafsIjAWk2kgjLZmj6YSxJGIikJDsLmvxgEfGWTQ=="), true); */

            string connectionString = configuration.GetConnectionString("connectString");

            if (_contexto.Productos.Count() == 0)
            {
                _contexto.Productos.Add(new Producto { Nombre = "Zapatos" });
                _contexto.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Producto>> GetProductos(int page, int size)
        {
            int skip = (page - 1) * size;
            return _contexto.Productos.Skip(skip).Take(size).ToList();
        }


        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetProducto")]
        public ActionResult<Producto> GetProductoById(long id)
        {
            var item = _contexto.Productos.Find(id);

            if (item == null) {
                return NotFound();
            }

            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _contexto.Productos.Add(producto);
            _contexto.SaveChanges();

            return CreatedAtRoute("GetProducto", new { id = producto.Id }, producto);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, Producto element)
        {
            var producto = _contexto.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Nombre = element.Nombre;
            producto.correo = element.correo;
            producto.pais = element.pais;
            producto.precio = element.precio;
            producto.undDisponibles = element.undDisponibles;
            producto.undVendidas = element.undVendidas;
            producto.descripcion = element.descripcion;

            _contexto.Productos.Update(producto);
            _contexto.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var producto = _contexto.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();

            return NoContent();
        }
    }
}
