using EsquemaApi.EsquemasAPI;
using System.Web.Http;
using System.Linq;
using WR = ReferenciaServicios.WRGestionProductos;
using System;


namespace WAProdocutos.Controllers
{
    [RoutePrefix("ApiProductos")]
    public class ValuesController : ApiController
    {

      
        [HttpGet]
        [Route("rmListar")]
        public IHttpActionResult rmListarProductos()
        {
            try
            {
                WR.WSGestionProductos loWSGestor = new WR.WSGestionProductos();
                WR.ProductosRPT loProductoRPT = loWSGestor.wmListarProductos();

                ProductosRPT loRespuesta = new ProductosRPT()
                {

                    paProductos = loProductoRPT.paProductos?.Select(p => new ProductoCN
                    {

                        pnIdePro = p.pnIdePro,
                        pcNomPro = p.pcNomPro,
                        pcDesPro = p.pcDesPro,
                        pnPrePro = p.pnPrePro,
                        pnStoPro = p.pnStoPro,
                        ptFecPro = p.ptFecPro,
                        pnIdeSed = p.pnIdeSed

                    }).ToArray()

                };
                return Ok(loRespuesta);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("rmInsertar")]
        public IHttpActionResult rmCrearProducto([FromBody] ProductoInsertarRQT toProductoInsRQT)
        {
            try
            {
                WR.WSGestionProductos loWSGestor = new WR.WSGestionProductos();
                WR.ProductoInsertarRPT loProductoRPT = loWSGestor.wmCrearProducto(new WR.ProductoInsertarRQT
                {
                    pcNomPro = toProductoInsRQT.pcNomPro,
                    pcDesPro = toProductoInsRQT.pcDesPro,
                    pnPrePro = toProductoInsRQT.pnPrePro,
                    pnStoPro = toProductoInsRQT.pnStoPro,
                    pnIdeSed = toProductoInsRQT.pnIdeSed
                });

                ProductoInsertarRPT loRespuesta = new ProductoInsertarRPT
                { 
                    pnIdePro = loProductoRPT.pnIdePro,
                    pcNomPro = loProductoRPT.pcNomPro,
                    pcDesPro = loProductoRPT.pcDesPro,
                    pnPrePro = loProductoRPT.pnPrePro,
                    pnStoPro = loProductoRPT.pnStoPro,
                    pnIdeSed = loProductoRPT.pnIdeSed
                };
                return Ok(loRespuesta);


            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("rmActualizar")]
        public IHttpActionResult rmActualizarProducto([FromBody] ProductoActualizarRQT toProductoActRQT)
        {
            try
            {
                WR.WSGestionProductos loWSGestor = new WR.WSGestionProductos();
                WR.ProductoActualizarRPT loProductoRPT = loWSGestor.wmActualizarProducto(new WR.ProductoActualizarRQT
                {
                    pnIdePro = toProductoActRQT.pnIdePro,
                    pcNomPro = toProductoActRQT.pcNomPro,
                    pcDesPro = toProductoActRQT.pcDesPro,
                    pnPrePro = toProductoActRQT.pnPrePro,
                    pnStoPro = toProductoActRQT.pnStoPro,
                    pnIdeSed = toProductoActRQT.pnIdeSed

                });
                
                ProductoActualizarRPT loRespuesta = new ProductoActualizarRPT
                { 
                    pnIdePro = loProductoRPT.pnIdePro, 
                    pcNomPro = loProductoRPT.pcNomPro,
                    pcDesPro = loProductoRPT.pcDesPro,
                    pnPrePro = loProductoRPT.pnPrePro,
                    pnStoPro = loProductoRPT.pnStoPro,
                    ptFecPro = loProductoRPT.ptFecPro,
                    pnIdeSed = loProductoRPT.pnIdeSed
                
                };
                return Ok(loRespuesta);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("rmEliminar")]
        public IHttpActionResult rmEliminarProducto([FromBody] ProductoEliminarRQT toProductoEliRQT)
        {
            try
            {
                WR.WSGestionProductos loWSGestor = new WR.WSGestionProductos();
                WR.ProductoEliminarRPT loProductoRPT = loWSGestor.wmEliminarProducto(new WR.ProductoEliminarRQT
                {
                    pnIdePro = toProductoEliRQT.pnIdePro
                });

                ProductoEliminarRPT loRespuesta = new ProductoEliminarRPT
                {
                    pnIdePro = loProductoRPT.pnIdePro
                };

                return Ok(loRespuesta);
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("rmTraslado")]
        public IHttpActionResult rmCrearTraslado([FromBody] ProMovTrasladoRQT toProductoTraRQT)
        {
            try
            {
                WR.WSGestionProductos loWSGestor = new WR.WSGestionProductos();
                WR.ProductoMoverRPT loProductoRPT = loWSGestor.wmTrasladarProducto(new WR.ProMovTrasladoRQT
                {
                    cNomPro = toProductoTraRQT.cNomPro,
                    nIdeOri = toProductoTraRQT.nIdeOri,
                    nIdeDes = toProductoTraRQT.nIdeDes,
                    nCanMov = toProductoTraRQT.nCanMov
                });

                ProductoMoverRPT loRespuesta = new ProductoMoverRPT
                {
                    pcNomPro = loProductoRPT.pcNomPro,
                    pnIdeOri = loProductoRPT.pnIdeOri,
                    pnIdeDes = loProductoRPT.pnIdeDes,
                    pnCanMov = loProductoRPT.pnCanMov
                };

                return Ok(loRespuesta);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
