namespace Transversal
{
    public static class Constantes
    {
        //CONFIRMACIONES
        public const string _M_REGISTRO_EXITOSO = "El registro se guardó correctamente.";
        public const string _M_CARGA_REGISTRO = "Los registros se obtuvieron correctamente.";
        //ERRORES
        public const string _M_ERROR_ACTUALIZAR = "No se pudieron guardar los cambios realizados.";
        public const string _M_ERROR_ELIMINAR = "No se pudo eliminar el registro con identificador: ";
        public const string _M_ERROR_LISTAR = "No se obtuvieron los registros o no existen";
        public const string _M_ERROR_VALIDACION = "Los datos proporcionados no son válidos.";
        public const string _M_ERROR_BASE_DATOS = "Error de conexión con el servidor de datos.";
        public static string _M_NO_REGISTRO = "No se guardó el registro con nombre: ";
        public const string _M_REGISTRO_NO_ENCONTRADO = "El elemento solicitado no existe.";
        public const string _M_RECURSO_NO_EXISTENTE = "El recurso solicitado se encuentra vacío o no existe.";
        //PROCEDIMIENTOS ALMACENADOS
        public const string SP_PRODUCTO_CREAR = "PROC_I_INVMPRO";
        public const string SP_PRODUCTO_LISTAR = "PROC_S_INVMPRO_TraerTodo";
        public const string SP_PRODUCTO_ELIMINAR = "PROC_D_INVMPRO_nIdePro";
        public const string SP_PRODUCTAR_EDITAR = "PROC_U_INVMPRO";
        public const string SP_PRODUCTO_MOVER = "PROC_U_INVMPROSED";
        //PROCEDIMIENTOS ALMACENADOS TRAZLADO   
        public const string SP_S_STOCK_ORIGEN = "PROC_S_STOCK_ORIGEN";
        public const string SP_S_STOCK_DESTINO = "PROC_S_EXISTE_DESTINO";
        public const string SP_U_PRODUCTO_ORIGEN = "PROC_U_INVMPROSED_ORIGEN";
        public const string SP_U_PRODUCTO_DESTINO = "PROC_U_INVMPROSED_DESTINO";
        public const string SP_S_PRODUCTO_NUEVO = "PROC_S_INVMPROSED_PRO";
        public const string SP_I_PRODUCTO_RESTOCK = "PROC_I_INVMPROSED_DESTINO";
        //FORMATOS
        public const string FECHA_ESTANDAR = "dd/MM/yyyy";
        public const string MONEDA_CULTURA = "es-PE";
        public const string FORMATO_DECIMAL = "0.00";
    }
}
