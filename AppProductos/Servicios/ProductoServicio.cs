using EsquemasMAUI.MauiEsquemas;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace AppProductos.Servicios
{
    public class ProductoServicio
    {
        private readonly HttpClient loCliente;
        private const string cUrl = "http://localhost/WAProductos/ApiProductos/";

        public ProductoServicio()
        {
            
            this.loCliente = new HttpClient();
        }

        
        // GET - Listar productos
        
        public async Task<ProductosRPT> mxObtenerProductos()
        {
            try
            {
                ProductosRPT loRespuesta = await loCliente.GetFromJsonAsync<ProductosRPT>(cUrl + "rmListar");
                return loRespuesta ?? new ProductosRPT();
            }
            catch (Exception ex)
            {
                return new ProductosRPT { pcCodigo = "400", pcMensaje = ex.Message };
            }
        }

        
        // POST - Insertar producto
        
        public async Task<ProductoInsertarRPT> mxInsertarProducto(ProductoInsertarRQT toRQT)
        {
            try
            {
                HttpResponseMessage loRespuesta = await loCliente.PostAsJsonAsync(cUrl + "rmInsertar", toRQT);
                loRespuesta.EnsureSuccessStatusCode();
                return await loRespuesta.Content.ReadFromJsonAsync<ProductoInsertarRPT>()
                       ?? new ProductoInsertarRPT();
            }
            catch (Exception ex)
            {
                return new ProductoInsertarRPT { pcCodigo = "ERR", pcMensaje = ex.Message };
            }
        }

       
        // PUT - Actualizar producto
        
        public async Task<ProductoActualizarRPT> mxActualizarProducto(ProductoActualizarRQT toRQT)
        {
            try
            {
               
                HttpResponseMessage loRespuesta = await loCliente.PutAsJsonAsync(cUrl + "rmActualizar", toRQT);
                loRespuesta.EnsureSuccessStatusCode();
                return await loRespuesta.Content.ReadFromJsonAsync<ProductoActualizarRPT>()
                       ?? new ProductoActualizarRPT();
            }
            catch (Exception ex)
            {
                return new ProductoActualizarRPT { pcCodigo = "ERR", pcMensaje = ex.Message };
            }
        }

       
        // DELETE - Eliminar producto (con body)
        
        public async Task<ProductoEliminarRPT> mxEliminarProducto(ProductoEliminarRQT toRQT)
        {
            try
            {
                // HttpClient.DeleteAsync no soporta body, se usa HttpRequestMessage
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, cUrl + "rmEliminar")
                {
                    Content = new StringContent(
                        JsonSerializer.Serialize(toRQT),
                        Encoding.UTF8,
                        "application/json")
                };

                HttpResponseMessage loRespuesta = await loCliente.SendAsync(request);
                loRespuesta.EnsureSuccessStatusCode();
                return await loRespuesta.Content.ReadFromJsonAsync<ProductoEliminarRPT>()
                       ?? new ProductoEliminarRPT();
            }
            catch (Exception ex)
            {
                return new ProductoEliminarRPT { pcCodigo = "ERR", pcMensaje = ex.Message };
            }
        }

        
        // POST - Trasladar producto
        
        public async Task<ProductoMoverRPT> mxTrasladarProducto(ProMovTrasladoRQT toRQT)
        {
            try
            {
                HttpResponseMessage loRespuesta = await loCliente.PostAsJsonAsync(cUrl + "rmTraslado", toRQT);
                loRespuesta.EnsureSuccessStatusCode();
                return await loRespuesta.Content.ReadFromJsonAsync<ProductoMoverRPT>()
                       ?? new ProductoMoverRPT();
            }
            catch (Exception ex)
            {
                return new ProductoMoverRPT { pcCodigo = "ERR", pcMensaje = ex.Message };
            }
        }



    }
}
