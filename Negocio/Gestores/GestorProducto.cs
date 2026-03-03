using Datos.Entidades;
using Datos.Repositorios;
using Negocio.Esquemas;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Transversal;


namespace Negocio.Gestores
{
    public class GestorProducto
    {
        
        public ProductosRPT mxObtenerProductos()
        {
            
            ProductosRPT loRespuesta = new ProductosRPT();
            ProductoCN loProducto = new ProductoCN();
            List<ProductoCN> laLstProductos = new List<ProductoCN>();
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            List<ProductoCD> loLstProductos;
            try
            {
                loLstProductos = loProductosCD.mxListarProducto();

                if (loLstProductos.Count == 0)
                {
                    loRespuesta.pcCodigo = "400";
                    loRespuesta.pcMensaje = Constantes._M_ERROR_LISTAR;
                    return loRespuesta;
                }

                foreach (ProductoCD loProduct in loLstProductos) 
                {
                    loProducto = new ProductoCN();
                    loProducto.pnIdePro = loProduct.nIdePro;
                    loProducto.pcNomPro = loProduct.cNomPro;
                    loProducto.pcDesPro = loProduct.cDesPro;
                    loProducto.pnPrePro = loProduct.nPrePro;
                    loProducto.pnStoPro = loProduct.nStoPro;
                    loProducto.ptFecPro = loProduct.tFecPro;
                    loProducto.pnIdeSed = loProduct.nIdeSed;
                    laLstProductos.Add(loProducto);
                }
                loRespuesta.paProductos = laLstProductos.ToArray();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al intentar obtener los registros: {ex.Message}");
                throw;

            }

            return loRespuesta;
        }

        public ProductoInsertarRPT mxInsertarProducto(ProductoInsertarRQT toProducto)
        {

            ProductoInsertarRPT loRespuesta;
            ProductoRepoCD loProductosCD = new  ProductoRepoCD();
            ProductoCD loProductoCD;
            try
            {
                    loProductoCD = new ProductoCD
                {
                    cNomPro = toProducto.pcNomPro,
                    cDesPro = toProducto.pcDesPro,
                    nPrePro = toProducto.pnPrePro,
                    nStoPro = toProducto.pnStoPro,
                    nIdeSed = toProducto.pnIdeSed
                };                        


                int nIdePro = loProductosCD.mxCrearProducto(loProductoCD);

                loRespuesta = new ProductoInsertarRPT
                {
                    pnIdePro = nIdePro,
                    pnPrePro = loProductoCD.nPrePro,
                    pcNomPro = loProductoCD.cNomPro,
                    pcDesPro = loProductoCD.cDesPro,
                    pnStoPro = loProductoCD.nStoPro,
                    ptFecPro = loProductoCD.tFecPro,
                    pnIdeSed = loProductoCD.nIdeSed
                };
                
            }
            catch (Exception ex) {

                System.Diagnostics.Debug.WriteLine("Error al insertar: " + ex.Message);
                loRespuesta = new ProductoInsertarRPT();
                loRespuesta.pcCodigo = "400";
                loRespuesta.pcMensaje = Constantes._M_NO_REGISTRO;
                return loRespuesta;

            }
            return loRespuesta;
        }
        public ProductoActualizarRPT mxActualizarProducto(ProductoActualizarRQT toProducto)
        {
            ProductoActualizarRPT loRespuesta;
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            ProductoCD loProductoCD;
            try {
                    loProductoCD = new ProductoCD
                {
                    nIdePro = toProducto.pnIdePro,
                    cNomPro = toProducto.pcNomPro,
                    cDesPro = toProducto.pcDesPro,
                    nPrePro = toProducto.pnPrePro,
                    nStoPro = toProducto.pnStoPro,
                    nIdeSed = toProducto.pnIdeSed
                };

                int nIdePro = loProductosCD.mxActualizarProducto(loProductoCD);

                loRespuesta = new ProductoActualizarRPT
                {
                    pnIdePro = toProducto.pnIdePro,
                    pnPrePro = loProductoCD.nPrePro,
                    pcNomPro = loProductoCD.cNomPro,
                    pcDesPro = loProductoCD.cDesPro,
                    pnStoPro = loProductoCD.nStoPro,
                    ptFecPro = loProductoCD.tFecPro,
                    pnIdeSed = loProductoCD.nIdeSed
                };

            }

            catch (Exception ex) {
                
                System.Diagnostics.Debug.WriteLine("Error al actualizar: " + ex.Message);
                loRespuesta = new ProductoActualizarRPT();
                loRespuesta.pcCodigo = "400";
                loRespuesta.pcMensaje = Constantes._M_ERROR_ACTUALIZAR;
                return loRespuesta;

            }
        
        return loRespuesta;
       
        }

        public ProductoMoverRPT mxTrazladarProducto(ProductoMoverRQT loProdMov)
        {
            ProductoMoverRPT loProRpt = new ProductoMoverRPT();
            ProductoRepoCD loProdCd = new ProductoRepoCD();
            ProductoMovimientoRQT loProductoMov;
            try
            {
                loProductoMov = new ProductoMovimientoRQT
                {
                    cNomPro = loProdMov.cNomPro,
                    cIdeOri = loProdMov.cIdeOri,
                    nIdeDes = loProdMov.nIdeDes,
                    nCanMov = loProdMov.nCanMov,

                };

                int confirmacion = loProdCd.mxRealizarTrazlado(loProductoMov);

                    loProRpt.cNomPro = loProductoMov.cNomPro;
                    loProRpt.cIdeOri = loProductoMov.cIdeOri;
                    loProRpt.nIdeDes = loProductoMov.nIdeDes;
                    loProRpt.nCanMov = loProductoMov.nCanMov;
                
            }
            catch (Exception ex)
            {
                loProRpt.pcCodigo = "404";
                loProRpt.pcMensaje = ex.Message;

            }
            return loProRpt;
        }


        public ProductoEliminarRPT mxEliminarRegistro(ProductoEliminarRQT loProductoEliminar)
        {
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            ProductoEliminarRPT loRespuesta;
            try
            {
                loRespuesta = new ProductoEliminarRPT();
                loRespuesta.pnIdePro = loProductosCD.mxEliminarProducto(loProductoEliminar.pnIdePro);
            }
            catch (Exception ex) {

                System.Diagnostics.Debug.WriteLine("Error al eliminar: " + ex.Message);
                loRespuesta = new ProductoEliminarRPT();
                loRespuesta.pcCodigo = "400";
                loRespuesta.pcMensaje =Constantes._M_ERROR_ELIMINAR;
                return loRespuesta;
            }

            return loRespuesta;
        }
    }
}
