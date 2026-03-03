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
        public int cIdeOri { get; set; }
        public int nIdeDes { get; set; }
        public int nCanMov { get; set; }
    }
}
