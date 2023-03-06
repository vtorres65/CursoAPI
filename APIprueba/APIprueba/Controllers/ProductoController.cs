using APIprueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace APIprueba.Controllers
{
    public class ProductoController : ApiController
    {
        static Dictionary<int, Producto> productos = new Dictionary<int, Producto>();

        //GET api/Producto
        public IEnumerable<Producto> Get()
        {
            return new List<Producto>(productos.Values);
        }

        //GET api/Producto/5
        public Producto Get(int id)
        {
            Producto encontrado;
            productos.TryGetValue(id, out encontrado);
            return encontrado;
        }

        //POST api/Producto
        public bool Post([FromBody] Producto producto)
        {
            Producto encontrado;
            productos.TryGetValue(producto.IdProducto, out encontrado);
            if (encontrado == null)
            {
                productos.Add(producto.IdProducto, producto);
                return true;
            } else
            {
                return false;
            }
        }

        //DELETE api/Producto/1
        public bool Delete(int id)
        {
            return productos.Remove(id);
        }
    }
}
