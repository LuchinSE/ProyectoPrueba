using Dapper;
using Datos.Conexion;
using Datos.Entidades;
using Microsoft.Win32.SafeHandles;
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

        public int mxCrearProducto(ProductoCD toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {

                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tcDesPro", toProducto.cDesPro);
                loParametros.Add("tnPrePro", toProducto.nPrePro);
                loParametros.Add("tnStoPro", toProducto.nStoPro);
                loParametros.Add("tnIdeSed", toProducto.nIdeSed);
                return conn.ExecuteScalar<int>(Constantes.SP_PRODUCTO_CREAR, loParametros, commandType: CommandType.StoredProcedure);

            }
        }

        public int mxEliminarProducto(int id)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", id);

                return conn.Execute(Constantes.SP_PRODUCTO_ELIMINAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
        public List<ProductoCD> mxListarProducto()
        {
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                return conn.Query<ProductoCD>(Constantes.SP_PRODUCTO_LISTAR, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int mxActualizarProducto(ProductoCD toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", toProducto.nIdePro);
                loParametros.Add("tcNomPro", toProducto.cNomPro);
                loParametros.Add("tcDesPro", toProducto.cDesPro);
                loParametros.Add("tnPrePro", toProducto.nPrePro);
                loParametros.Add("tnStoPro", toProducto.nStoPro);
                loParametros.Add("tnIdeSed", toProducto.nIdeSed);
                return conn.Execute(Constantes.SP_PRODUCTAR_EDITAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public int mxRealizarTrazlado(ProductoMovimientoRQT toProducto)
        {
            DynamicParameters loParametros;
            using (IDbConnection conn = loConexion.ObtenerConexion())
            { 
                loParametros = new DynamicParameters();
                loParametros.Add("tnNomPro", toProducto.cNomPro);
                loParametros.Add("tcIdeSedori", toProducto.cIdeOri);
                loParametros.Add("tnIdeSedDes", toProducto.nIdeDes);
                loParametros.Add("tnCantMov", toProducto.nCanMov);
                return conn.Execute(Constantes.SP_PRODUCTO_MOVER, loParametros, commandType: CommandType.StoredProcedure);
            }
        
        }

    }
}