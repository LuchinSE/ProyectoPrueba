using Datos.Conexion;
using Datos.Entidades;
using Datos.Repositorios;
using Negocio.Esquemas;
using Negocio.Transacciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            SqlTransaction loTransaccion = null;
            IDbConnection loConexion = null;
            try
            {
                loTransaccion = (SqlTransaction)this.mxIniciarTransaccion();
                loConexion = loTransaccion.Connection;
                loLstProductos = loProductosCD.mxListarProducto(loConexion,loTransaccion);

                if (loLstProductos.Count == 0)
                {
                    loRespuesta.pcCodigo = "400";
                    loRespuesta.pcMensaje = Constantes._M_ERROR_LISTAR;
                    loTransaccion.Commit();
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
                loTransaccion.Commit();
            }
            catch (Exception ex)
            {
                if (loTransaccion !=null)
                {
                    try { 
                        loTransaccion.Rollback();
                    
                    }catch (Exception) { 
                    
                    }
                }

                Console.WriteLine($"Error al intentar obtener los registros: {ex.Message}");
                loRespuesta.pcCodigo = "400";
                loRespuesta.pcMensaje = Constantes._M_ERROR_LISTAR;
                throw;

            }
            finally
            {

                loTransaccion.Dispose();
                loConexion.Dispose();

            }

            return loRespuesta;
        }

        public ProductoActualizarRPT mxActualizarProducto(ProductoActualizarRQT toProducto)
        {
            ProductoActualizarRPT loRespuesta;
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            ProductoCD loProductoCD;
            SqlTransaction loTransaccion = null;
            IDbConnection loConexion = null;
            try {

                loTransaccion = (SqlTransaction)this.mxIniciarTransaccion();
                loConexion = loTransaccion.Connection;
                loProductoCD = new ProductoCD
                {
                    nIdePro = toProducto.pnIdePro,
                    cNomPro = toProducto.pcNomPro,
                    cDesPro = toProducto.pcDesPro,
                    nPrePro = toProducto.pnPrePro,
                    nStoPro = toProducto.pnStoPro,
                    nIdeSed = toProducto.pnIdeSed
                };

                int nIdePro = loProductosCD.mxActualizarProducto(loProductoCD, loConexion, loTransaccion);

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
                loTransaccion.Commit();

            }

            catch (Exception ex) {

                if (loTransaccion != null)
                {
                    try { loTransaccion.Rollback(); }
                    catch { }
                }

                System.Diagnostics.Debug.WriteLine("Error al actualizar: " + ex.Message);
                loRespuesta = new ProductoActualizarRPT();
                loRespuesta.pcCodigo = "400";
                loRespuesta.pcMensaje = Constantes._M_ERROR_ACTUALIZAR;
                return loRespuesta;

            }
            finally { 
                
                loTransaccion.Dispose();    
                loConexion.Dispose();
                
            }
        
        return loRespuesta;
       
        }

        public ProductoMoverRPT mxTrasladarProducto(ProMovTrasladoRQT toProducto)
        {
            ProductoMoverRPT loRespuesta;
            ProductoRepoCD loProdCd = new ProductoRepoCD();
            ProMovTraerRQT loConsulta;
            DbConexion loConexion = new DbConexion();
            TransaccionCN loTran = new TransaccionCN(loConexion.ObtenerConexion());
            try
            {
                loConsulta = new ProMovTraerRQT
                {
                    cNomPro = toProducto.cNomPro,
                    nIdeOri = toProducto.nIdeOri,
                    nIdeDes = toProducto.nIdeDes
                };

                // Validación 1: existe en origen y tiene stock
                ProMovStockRSP loStock = loProdCd.mxObtenerStockOri(loConsulta, loTran.Conexion, loTran.Transaccion); // ← mxObtenerStockOrigen no existe
                if (loStock == null)
                {
                    loRespuesta = new ProductoMoverRPT();
                    loRespuesta.pcCodigo = "404";
                    loRespuesta.pcMensaje = "Producto no encontrado en sede origen.";
                    loTran.mxRollback();
                    return loRespuesta;
                }

                // Validación 2: stock suficiente
                if (loStock.nStoPro < toProducto.nCanMov)
                {
                    loRespuesta = new ProductoMoverRPT();
                    loRespuesta.pcCodigo = "400";
                    loRespuesta.pcMensaje = "Stock insuficiente para el traslado.";
                    loTran.mxRollback();
                    return loRespuesta;
                }

                // Restar en origen
                loProdCd.mxActualizaStockOrigen(new ProMovActOriRQT
                {
                    cNomPro = toProducto.cNomPro,
                    nIdeOri = toProducto.nIdeOri,
                    nCanMov = toProducto.nCanMov
                }, loTran.Conexion, loTran.Transaccion);

                // Verificar si existe en destino
                if (loProdCd.mxExisteEnDestino(loConsulta, loTran.Conexion, loTran.Transaccion))
                {
                    loProdCd.mxActualizaStockDestino(new ProMovActDesRQT
                    {
                        cNomPro = toProducto.cNomPro,
                        nIdeDes = toProducto.nIdeDes,
                        nCanMov = toProducto.nCanMov
                    }, loTran.Conexion, loTran.Transaccion);
                }
                else
                {
                    ProMovNuevoRSP loDatos = loProdCd.mxObtenerNuevoProd(loConsulta, loTran.Conexion, loTran.Transaccion); // ← mxObtenerDatosProducto no existe
                    loProdCd.mxInsertaProductoDestino(new ProMovInsDesRQT
                    {
                        cNomPro = toProducto.cNomPro,
                        cDesPro = loDatos.cDesPro,
                        nPrePro = loDatos.nPrePro,
                        nCanMov = toProducto.nCanMov,
                        nIdeDes = toProducto.nIdeDes
                    }, loTran.Conexion, loTran.Transaccion);
                }

                loRespuesta = new ProductoMoverRPT();
                loRespuesta.pcCodigo = "200";
                loRespuesta.pcMensaje = "Traslado completado exitosamente.";
                loRespuesta.pcNomPro = toProducto.cNomPro;
                loRespuesta.pnIdeOri = toProducto.nIdeOri;
                loRespuesta.pnIdeDes = toProducto.nIdeDes;
                loRespuesta.pnCanMov = toProducto.nCanMov;
                loTran.mxCommit();
            }
            catch (Exception ex)
            {                
                loRespuesta = new ProductoMoverRPT();
                loRespuesta.pcCodigo = "500";
                loRespuesta.pcMensaje = ex.Message;
                loTran.mxRollback();
            }
            return loRespuesta;
        }

        //public ProductoMoverRPT mxTrazladarProducto(ProMovActOriRQT toProOri, ProMovActDesRQT toProDes)
        //{
        //  ProductoMoverRPT loRespuesta;


        /*ProductoMoverRPT loProRpt;
        ProductoRepoCD loProdCd = new ProductoRepoCD();
        ProductoMovimientoRQT loProductoMov;

        try
        {
            loProductoMov = new ProductoMovimientoRQT
            {
                cNomPro = loProdMov.pcNomPro,
                nIdeOri = loProdMov.pnIdeOri,
                nIdeDes = loProdMov.pnIdeDes,
                nCanMov = loProdMov.pnCanMov,

            };

            int confirmacion = loProdCd.mxRealizarTrazlado(loProductoMov);

            loProRpt = new ProductoMoverRPT();
            { 
            loProRpt.pcNomPro = loProductoMov.cNomPro;
            loProRpt.pnIdeOri = loProductoMov.nIdeOri;
            loProRpt.pnIdeDes = loProductoMov.nIdeDes;
            loProRpt.pnCanMov = loProductoMov.nCanMov;
            }
        }
        catch (Exception ex)
        {
            loProRpt = new ProductoMoverRPT();
            loProRpt.pcCodigo = "404";
            loProRpt.pcMensaje = ex.Message;

        }*/
        // return loProRpt;
        //}


        public ProductoEliminarRPT mxEliminarRegistro(ProductoEliminarRQT loProductoEliminar)
        {
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            ProductoEliminarRPT loRespuesta;
            SqlTransaction loTransaccion = null;
            IDbConnection loConexion = null;
            try
            {
                loTransaccion = (SqlTransaction)this.mxIniciarTransaccion();
                loConexion = loTransaccion.Connection;
                loRespuesta = new ProductoEliminarRPT();
                loRespuesta.pnIdePro = loProductosCD.mxEliminarProducto(loProductoEliminar.pnIdePro, loConexion, loTransaccion);
                loTransaccion.Commit();
            }
            catch (Exception ex)
            {
                if (loTransaccion != null)
                {
                    try
                    {
                        loTransaccion.Rollback();
                    }
                    catch { }
                }

                System.Diagnostics.Debug.WriteLine("Error al eliminar: " + ex.Message);
                loRespuesta = new ProductoEliminarRPT();
                loRespuesta.pcCodigo = "400";
                loRespuesta.pcMensaje = Constantes._M_ERROR_ELIMINAR;
                return loRespuesta;
            }
            finally { 
                
                loTransaccion.Dispose();
                loConexion.Dispose();
            }

            return loRespuesta;
        }

        public IDbTransaction mxIniciarTransaccion()
        {
            DbConexion loConCD = new DbConexion();
            IDbConnection loConexionBD = null;
            loConexionBD = loConCD.ObtenerConexion();
            loConexionBD.Open();
            return loConexionBD.BeginTransaction(IsolationLevel.RepeatableRead);
        }

 


        public ProductoInsertarRPT mxInsertarProducto(ProductoInsertarRQT toProducto)
        {
            ProductoInsertarRPT loRespuesta = new ProductoInsertarRPT();
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            SqlTransaction loTransaccion = null;
            IDbConnection loConexion = null;
    
       
                try
                {
                    loTransaccion = (SqlTransaction)this.mxIniciarTransaccion();
                    loConexion = loTransaccion.Connection;
                
                    ProductoCD loProductoCD = new ProductoCD
                    {
                        cNomPro = toProducto.pcNomPro,
                        cDesPro = toProducto.pcDesPro,
                        nPrePro = toProducto.pnPrePro,
                        nStoPro = toProducto.pnStoPro,
                        nIdeSed = toProducto.pnIdeSed
                    };

                    int nIdePro = loProductosCD.mxCrearProducto(loProductoCD, loConexion ,loTransaccion);

                    loRespuesta.pnIdePro = nIdePro;
                    loRespuesta.pnPrePro = loProductoCD.nPrePro;
                    loRespuesta.pcNomPro = loProductoCD.cNomPro;
                    loRespuesta.pcDesPro = loProductoCD.cDesPro;
                    loRespuesta.pnStoPro = loProductoCD.nStoPro;
                    loRespuesta.ptFecPro = loProductoCD.tFecPro;
                    loRespuesta.pnIdeSed = loProductoCD.nIdeSed;

                    loTransaccion.Commit();
                }
                catch (Exception ex)
                {
                    
                    if (loTransaccion != null)
                    {
                        try { loTransaccion.Rollback(); }
                        catch { /* la transacción ya fue cerrada por el motor */ }
                    }

                    System.Diagnostics.Debug.WriteLine("Error al insertar: " + ex.Message);
                    loRespuesta.pcCodigo = "400";
                    loRespuesta.pcMensaje = Constantes._M_NO_REGISTRO;
                }
                finally
                {
                    loTransaccion?.Dispose();
                    loConexion?.Dispose();
                }
            

            return loRespuesta;
        }
    }
}
