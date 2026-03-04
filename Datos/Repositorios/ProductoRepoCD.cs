using Dapper;
using Datos.Conexion;
using Datos.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Transversal;

namespace Datos.Repositorios
{
    public class ProductoRepoCD
    {

        private readonly DbConexion loConexion;

        public ProductoRepoCD()
        {
            this.loConexion = new DbConexion();
        }

        public int mxCrearProducto(ProductoCD toProducto, IDbConnection toConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros;
 
            loParametros = new DynamicParameters();
            loParametros.Add("tcNomPro", toProducto.cNomPro);
            loParametros.Add("tcDesPro", toProducto.cDesPro);
            loParametros.Add("tnPrePro", toProducto.nPrePro);
            loParametros.Add("tnStoPro", toProducto.nStoPro);
            loParametros.Add("tnIdeSed", toProducto.nIdeSed);
            return toConexion.ExecuteScalar<int>(Constantes.SP_PRODUCTO_CREAR, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
   
        }

        public int mxEliminarProducto(int id, IDbConnection toConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros;
     
                loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", id);

                return toConexion.Execute(Constantes.SP_PRODUCTO_ELIMINAR, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
            
        }
        public List<ProductoCD> mxListarProducto(IDbConnection toConexion, IDbTransaction toTransaccion)
        {
    
                return toConexion.Query<ProductoCD>(Constantes.SP_PRODUCTO_LISTAR, transaction: toTransaccion, commandType: CommandType.StoredProcedure).ToList();
            
        }

        public int mxActualizarProducto(ProductoCD toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
            DynamicParameters loParametros;

                loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", toProducto.nIdePro);
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tcDesPro", toProducto.cDesPro);
                loParametros.Add("tnPrePro", toProducto.nPrePro);
                loParametros.Add("tnStoPro", toProducto.nStoPro);
                loParametros.Add("tnIdeSed", toProducto.nIdeSed);
                return toConexion.Execute(Constantes.SP_PRODUCTAR_EDITAR, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure);
            
        }

        public int mxRealizarTrazlado(ProductoMovimientoRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            { 
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedOri", toProducto.nIdeOri);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                return conn.Execute(Constantes.SP_PRODUCTO_MOVER, loParametros, commandType: CommandType.StoredProcedure);
            }
        
        }

        public int mxActualizaStockOrigen(ProMovActOriRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedOri", toProducto.nIdeOri);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                return conn.Execute(Constantes.SP_U_PRODUCTO_ORIGEN, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
        public int mxActualizaStockDestino(ProMovActDesRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                return conn.Execute(Constantes.SP_U_PRODUCTO_DESTINO, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
        /*public int mxObtenerNuevoProd(ProMovTraerRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                return conn.Execute(Constantes.SP_S_PRODUCTO_NUEVO, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
        public int mxObtenerStockOri(ProStoOriRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedOri", toProducto.nIdeSed);
                return conn.Execute(Constantes.SP_S_STOCK_ORIGEN, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public int mxObtenerStockDes(ProStoDesRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeSed);
                return conn.Execute(Constantes.SP_S_STOCK_ORIGEN, loParametros, commandType: CommandType.StoredProcedure);
            }
        }*/

        public ProMovNuevoRSP mxObtenerNuevoProd(ProMovTraerRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                return conn.QueryFirstOrDefault<ProMovNuevoRSP>(Constantes.SP_S_PRODUCTO_NUEVO, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public ProMovStockRSP mxObtenerStockOri(ProMovTraerRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedOri", toProducto.nIdeOri);
                return conn.QueryFirstOrDefault<ProMovStockRSP>(Constantes.SP_S_STOCK_ORIGEN, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public bool mxExisteEnDestino(ProMovTraerRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                return conn.QueryFirstOrDefault<int>(Constantes.SP_S_STOCK_DESTINO, loParametros, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public int mxInsertaProductoDestino(ProMovInsDesRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tcDesPro", toProducto.cDesPro);
                loParametros.Add("tnPrePro", toProducto.nPrePro);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                return conn.Execute(Constantes.SP_I_PRODUCTO_RESTOCK, loParametros, commandType: CommandType.StoredProcedure);
            }
        }



    }
}