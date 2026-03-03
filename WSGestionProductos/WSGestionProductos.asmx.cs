using Negocio.Esquemas;
using Negocio.Gestores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Services;

namespace WSGestionProductos
{
    /// <summary>
    /// Descripción breve de WSGestionProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSGestionProductos : System.Web.Services.WebService
    {

        private readonly GestorProducto gestorProducto;

        public WSGestionProductos()
        {
            gestorProducto = new GestorProducto();
        }

        [WebMethod(Description = "Obtiene la lista de todos los productos.")]
        public ProductosRPT wmListarProductos()
        {
            return gestorProducto.mxObtenerProductos();
        }

        [WebMethod(Description = "Crea un nuevo producto.")]
        public ProductoInsertarRPT wmCrearProducto(ProductoInsertarRQT toProductoRequest)
        {
            var contexto = new ValidationContext(toProductoRequest);
            var errores = new List<ValidationResult>();
            bool valido = Validator.TryValidateObject(toProductoRequest, contexto, errores, true);

            if (!valido)
            {
                HttpContext.Current.Response.StatusCode = 400;

                HttpContext.Current.Response.StatusDescription = errores[0].ErrorMessage;
                ProductoInsertarRPT r = new ProductoInsertarRPT();
                return r;
            }

            return gestorProducto.mxInsertarProducto(toProductoRequest);
        }

        [WebMethod(Description = "Actualiza un producto existente.")]
        public ProductoActualizarRPT wmActualizarProducto(ProductoActualizarRQT toProductoRequest)
        {
            return gestorProducto.mxActualizarProducto(toProductoRequest);
        }

        [WebMethod(Description = "Elimina un producto por su identificador.")]
        public ProductoEliminarRPT wmEliminarProducto(ProductoEliminarRQT toProductoEliminar)
        {
            return gestorProducto.mxEliminarRegistro(toProductoEliminar);
        }
        [WebMethod(Description = "Realiza un trazlado de mercadería")]
        public ProductoMoverRPT wmTrazladarProducto(ProductoMoverRQT toProductoMover)
        {
            return gestorProducto.mxTrazladarProducto(toProductoMover);
        }
    }
}
