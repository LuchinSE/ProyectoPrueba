using Datos.Conexion;
using Datos.Entidades;
using Datos.Repositorios;
using Negocio.Esquemas;
using Negocio.Transacciones;
using System;
using System.Collections.Generic;
using System.Data;
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
            DbConexion loConexion = new DbConexion();
            TransaccionCN loTran = new TransaccionCN(loConexion.ObtenerConexion());
            try
            {

                loLstProductos = loProductosCD.mxListarProducto(loTran.Conexion,loTran.Transaccion);

                if (loLstProductos.Count == 0)
                {
                    loRespuesta.pcCodigo = Constantes._M_CODIGO_VALIDACION;
                    loRespuesta.pcMensaje = Constantes._M_ERROR_LISTAR;
                    loTran.mxCommit();
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
                loTran.mxCommit();
            }
            catch (Exception ex)
            {
                if (loTran !=null)
                {
                    try { 
                        loTran.mxRollback();
                    
                    }catch (Exception) { 
                    
                    }
                }

                Console.WriteLine( Constantes._M_ERROR_C_LISTAR + ex.Message);
                loRespuesta.pcCodigo = Constantes._M_CODIGO_VALIDACION;
                loRespuesta.pcMensaje = Constantes._M_ERROR_LISTAR;
                throw;

            }

            return loRespuesta;
        }

        public ProductoActualizarRPT mxActualizarProducto(ProductoActualizarRQT toProducto)
        {
            ProductoActualizarRPT loRespuesta;
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            ProductoCD loProductoCD;
            DbConexion loConexion = new DbConexion();
            TransaccionCN loTran = new TransaccionCN(loConexion.ObtenerConexion());
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

                int nIdePro = loProductosCD.mxActualizarProducto(loProductoCD, loTran.Conexion, loTran.Transaccion);

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
                loTran.mxCommit();

            }

            catch (Exception ex) {

                if (loTran != null)
                {
                    try { loTran.mxRollback(); }
                    catch { }
                }

                System.Diagnostics.Debug.WriteLine(Constantes._M_ERROR_C_ACTUALIZAR + ex.Message);
                loRespuesta = new ProductoActualizarRPT();
                loRespuesta.pcCodigo = Constantes._M_CODIGO_VALIDACION;
                loRespuesta.pcMensaje = Constantes._M_ERROR_ACTUALIZAR;
                return loRespuesta;

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
                ProMovStockRSP loStock = loProdCd.mxObtenerStockOri(loConsulta, loTran.Conexion, loTran.Transaccion); 
                if (loStock == null)
                {
                    loRespuesta = new ProductoMoverRPT();
                    loRespuesta.pcCodigo = Constantes._M_CODIGO_NO_ENCONTRADO;
                    loRespuesta.pcMensaje = Constantes._M_ERROR_PRODUCTO_NULL;
                    loTran.mxRollback();
                    return loRespuesta;
                }

                // Validación 2: stock insuficiente
                if (loStock.nStoPro < toProducto.nCanMov)
                {
                    loRespuesta = new ProductoMoverRPT();
                    loRespuesta.pcCodigo = Constantes._M_CODIGO_VALIDACION;
                    loRespuesta.pcMensaje = Constantes._M_ERROR_STOCK_INSUFICIENTE;
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
                    ProMovNuevoRSP loDatos = loProdCd.mxObtenerNuevoProd(loConsulta, loTran.Conexion, loTran.Transaccion); 
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
                loRespuesta.pcCodigo = Constantes._M_CODIGO_EXITOSO;
                loRespuesta.pcMensaje = Constantes._M_TRASLADO_EXITOSO;
                loRespuesta.pcNomPro = toProducto.cNomPro;
                loRespuesta.pnIdeOri = toProducto.nIdeOri;
                loRespuesta.pnIdeDes = toProducto.nIdeDes;
                loRespuesta.pnCanMov = toProducto.nCanMov;
                loTran.mxCommit();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(Constantes._M_ERROR_C_TRASLADO + ex.Message);
                loRespuesta = new ProductoMoverRPT();
                loRespuesta.pcCodigo = Constantes._M_CODIGO_ERROR;
                loRespuesta.pcMensaje = ex.Message;
                loTran.mxRollback();
            }
            return loRespuesta;
        }
        public ProductoEliminarRPT mxEliminarRegistro(ProductoEliminarRQT loProductoEliminar)
        {
            ProductoRepoCD loProductosCD = new ProductoRepoCD();
            ProductoEliminarRPT loRespuesta;
            DbConexion loConexion = new DbConexion();
            TransaccionCN loTran = new TransaccionCN(loConexion.ObtenerConexion());
            try
            {
                
                loRespuesta = new ProductoEliminarRPT();
                loRespuesta.pnIdePro = loProductosCD.mxEliminarProducto(loProductoEliminar.pnIdePro, loTran.Conexion, loTran.Transaccion);
                loTran.mxCommit();
            }
            catch (Exception ex)
            {
                if (loTran != null)
                {
                    try
                    {
                        loTran.mxRollback();
                    }
                    catch { }
                }

                System.Diagnostics.Debug.WriteLine(Constantes._M_ERROR_C_ELIMINAR + ex.Message);
                loRespuesta = new ProductoEliminarRPT();
                loRespuesta.pcCodigo = Constantes._M_CODIGO_VALIDACION;
                loRespuesta.pcMensaje = Constantes._M_ERROR_ELIMINAR;
                return loRespuesta;
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
            DbConexion loConexion = new DbConexion();
            TransaccionCN loTran = new TransaccionCN(loConexion.ObtenerConexion());
            try
                {

                    ProductoCD loProductoCD = new ProductoCD
                    {
                        cNomPro = toProducto.pcNomPro,
                        cDesPro = toProducto.pcDesPro,
                        nPrePro = toProducto.pnPrePro,
                        nStoPro = toProducto.pnStoPro,
                        nIdeSed = toProducto.pnIdeSed
                    };

                    int nIdePro = loProductosCD.mxCrearProducto(loProductoCD, loTran.Conexion ,loTran.Transaccion);

                    loRespuesta.pnIdePro = nIdePro;
                    loRespuesta.pnPrePro = loProductoCD.nPrePro;
                    loRespuesta.pcNomPro = loProductoCD.cNomPro;
                    loRespuesta.pcDesPro = loProductoCD.cDesPro;
                    loRespuesta.pnStoPro = loProductoCD.nStoPro;
                    loRespuesta.ptFecPro = loProductoCD.tFecPro;
                    loRespuesta.pnIdeSed = loProductoCD.nIdeSed;

                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    
                    if (loTran != null)
                    {
                        try { loTran.mxRollback(); }
                        catch { }
                    }

                    System.Diagnostics.Debug.WriteLine(Constantes._M_ERROR_C_INSERTAR + ex.Message);
                    loRespuesta.pcCodigo = Constantes._M_CODIGO_VALIDACION;
                    loRespuesta.pcMensaje = Constantes._M_NO_REGISTRO;
                }

            return loRespuesta;
        }
    }
}
