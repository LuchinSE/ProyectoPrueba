using ReferenciaServicios.WRGestionProductos;
using System.Web.Http;

namespace WAProdocutos.Controllers
{
    public class ValuesController : ApiController
    {
        /*
        [HttpGet]
        [Route("ApiProductos/Listar")]
        public ProductosRPT waListarProductos()
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return loReferencia.wmListarProductos();
            }
        }
        [HttpPut]
        [Route("ApiProductos/Actualizar")]
        public ProductoActualizarRPT waActualizarProducto(ProductoActualizarRQT toProductoActRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return loReferencia.wmActualizarProducto(toProductoActRQT);
            }
        }
        [HttpDelete]
        [Route("ApiProductos/Eliminar")]
        public ProductoEliminarRPT waEliminarProducto(ProductoEliminarRQT toProductoEliRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return loReferencia.wmEliminarProducto(toProductoEliRQT);
            }
        }
        [HttpPost]
        [Route("ApiProductos/Insertar")]
        public ProductoInsertarRPT waCrearProducto(ProductoInsertarRQT toProductoInsRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return loReferencia.wmCrearProducto(toProductoInsRQT);
            }
        }
        [HttpPost]
        [Route("ApiProductos/Traslado")]
        public ProductoMoverRPT waCrearProducto(ProMovTrasladoRQT toProductoTraRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return loReferencia.wmTrasladarProducto(toProductoTraRQT);
            }
        }
        */
        [HttpGet]
        [Route("ApiProductos/Listar")]
        public IHttpActionResult waListarProductos()
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return Ok(loReferencia.wmListarProductos());
            }
        }

        [HttpPut]
        [Route("ApiProductos/Actualizar")]
        public IHttpActionResult waActualizarProducto([FromBody] ProductoActualizarRQT toProductoActRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return Ok(loReferencia.wmActualizarProducto(toProductoActRQT));
            }
        }

        [HttpDelete]
        [Route("ApiProductos/Eliminar")]
        public IHttpActionResult waEliminarProducto([FromBody] ProductoEliminarRQT toProductoEliRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return Ok(loReferencia.wmEliminarProducto(toProductoEliRQT));
            }
        }

        [HttpPost]
        [Route("ApiProductos/Insertar")]
        public IHttpActionResult waCrearProducto([FromBody] ProductoInsertarRQT toProductoInsRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return Ok(loReferencia.wmCrearProducto(toProductoInsRQT));
            }
        }

        [HttpPost]
        [Route("ApiProductos/Traslado")]
        public IHttpActionResult waCrearTraslado([FromBody] ProMovTrasladoRQT toProductoTraRQT)
        {
            using (WSGestionProductos loReferencia = new WSGestionProductos())
            {
                return Ok(loReferencia.wmTrasladarProducto(toProductoTraRQT));
            }
        }

    }
}
