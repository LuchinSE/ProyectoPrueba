using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Transacciones
{
    public class TransaccionCN
    {
        private bool lbDisposed = false;

        public IDbConnection Conexion { get; private set; }
        public IDbTransaction Transaccion { get; private set; }

        public TransaccionCN(IDbConnection toConexion, IsolationLevel toNivel = IsolationLevel.ReadCommitted)
        {
            Conexion = toConexion;
            Conexion.Open();
            Transaccion = Conexion.BeginTransaction(toNivel);
        }

        public void mxCommit()
        {
            try
            {
                Transaccion?.Commit();
                Transaccion?.Dispose();
                Conexion?.Dispose();
            }
            catch
            {
                mxRollback();
                Transaccion?.Dispose();
                Conexion?.Dispose();
                throw;
            }
        }

        public void mxRollback()
        {
            try
            {
                Transaccion?.Rollback();
                Transaccion?.Dispose();
                Conexion?.Dispose();
            }
            catch
            {
                throw;
            }
        }
    }
}
