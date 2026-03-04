using System;

namespace Datos.Entidades
{
    public class ProductoCD
    {
        public int nIdePro { get; set; }
        public string cNomPro { get; set; }
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
        public int nStoPro { get; set; }
        public DateTime tFecPro { get; set; }
        public int nIdeSed { get; set; }
    }

    public class ProductoMovimientoRQT
    {
        public string cNomPro { get; set; }
        public int nIdeOri { get; set; }
        public int nIdeDes { get; set; }
        public int nCanMov { get; set; }
    }

    /*public class ProMovActOriRQT
    {
        public string cNomPro { get; set; }
        public int nIdeOri { get; set; }
        public int nCanMov { get; set; }

    }

    public class ProMovActDesRQT
    {
        public string cNomPro { get; set; }
        public int nIdeDes { get; set; }
        public int nCanMov { get; set; }

    }

    public class ProMovTraerRQT
    {
        public string cNomPro { get; set; }
    }

    public class ProMovInsRQT
    {
        public int nIdePro { get; set; }
        public string cNomPro { get; set; }
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
        public int nStoPro { get; set; }
        public DateTime tFecPro { get; set; }
        public int nIdeSed { get; set; }

    }

    public class ProStoOriRQT   
    {
        public string cNomPro { get; set; }
        public int nIdeSed { get; set; }

    }

    public class ProStoDesRQT
    {
        public string cNomPro { get; set; }
        public int nIdeSed { get; set; }

    }

    public class ProMovTraerRQT
    {
        public string cNomPro { get; set; }
        public int nIdeOri { get; set; }
        public int nIdeDes { get; set; }
    }
    */
    // Para restar stock en origen
    public class ProMovActOriRQT
    {
        public string cNomPro { get; set; }
        public int nIdeOri { get; set; }
        public int nCanMov { get; set; }
    }

    // Para sumar stock en destino
    public class ProMovActDesRQT
    {
        public string cNomPro { get; set; }
        public int nIdeDes { get; set; }
        public int nCanMov { get; set; }
    }

    // Para insertar producto en destino
    public class ProMovInsDesRQT
    {
        public string cNomPro { get; set; }
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
        public int nCanMov { get; set; }
        public int nIdeDes { get; set; }
    }

    // Respuesta de stock en origen
    public class ProMovStockRSP
    {
        public int nStoPro { get; set; }
    }

    // Respuesta de datos del producto
    public class ProMovNuevoRSP
    {
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
    }

    // Para consultas de verificación (stock origen y existencia destino)
    public class ProMovTraerRQT
    {
        public string cNomPro { get; set; }
        public int nIdeOri { get; set; }
        public int nIdeDes { get; set; }
    }


}
