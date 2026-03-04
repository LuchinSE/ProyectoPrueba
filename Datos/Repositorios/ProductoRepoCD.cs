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

        public int mxActualizaStockOrigen(ProMovActOriRQT toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
            DynamicParameters loParametros;

                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedOri", toProducto.nIdeOri);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                return toConexion.Execute(Constantes.SP_U_PRODUCTO_ORIGEN, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure);
            
        }
        public int mxActualizaStockDestino(ProMovActDesRQT toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
            DynamicParameters loParametros;
      
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                return toConexion.Execute(Constantes.SP_U_PRODUCTO_DESTINO, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure);
            
        }

        public ProMovNuevoRSP mxObtenerNuevoProd(ProMovTraerRQT toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
            DynamicParameters loParametros;
           
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                return toConexion.QueryFirstOrDefault<ProMovNuevoRSP>(Constantes.SP_S_PRODUCTO_NUEVO, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure);
            
        }

        public ProMovStockRSP mxObtenerStockOri(ProMovTraerRQT toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
            DynamicParameters loParametros;
 
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedOri", toProducto.nIdeOri);
                return toConexion.QueryFirstOrDefault<ProMovStockRSP>(Constantes.SP_S_STOCK_ORIGEN, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure);
            
        }

        public bool mxExisteEnDestino(ProMovTraerRQT toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
            DynamicParameters loParametros;
           
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                return toConexion.QueryFirstOrDefault<int>(Constantes.SP_S_STOCK_DESTINO, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure) > 0;
            
        }

        public int mxInsertaProductoDestino(ProMovInsDesRQT toProducto, IDbConnection toConexion, IDbTransaction toTransaccio)
        {
                DynamicParameters loParametros;
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tcDesPro", toProducto.cDesPro);
                loParametros.Add("tnPrePro", toProducto.nPrePro);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                return toConexion.Execute(Constantes.SP_I_PRODUCTO_RESTOCK, loParametros, transaction: toTransaccio, commandType: CommandType.StoredProcedure);
            
        }



    }
}