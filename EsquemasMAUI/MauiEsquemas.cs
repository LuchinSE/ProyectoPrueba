using System;

namespace EsquemasMAUI.MauiEsquemas
{
        public class ProductosRQT
        {
            public ProductoCN[] paProductos { get; set; }
        }

        public class ProductosRPT : Error
        {
            public ProductoCN[] paProductos { get; set; }

        }



        public class ProductoCN
        {

            public int pnIdePro { get; set; }
            public string pcNomPro { get; set; }
            public string pcDesPro { get; set; }
            public decimal pnPrePro { get; set; }
            public int pnStoPro { get; set; }
            public DateTime ptFecPro { get; set; }
            public int pnIdeSed { get; set; }

        }
        public class ProductoInsertarRQT
        {

            public string pcNomPro { get; set; }
            public string pcDesPro { get; set; }

            public decimal pnPrePro { get; set; }


            public int pnStoPro { get; set; }
            public int pnIdeSed { get; set; }

        }

        public class ProductoInsertarRPT : Error
        {
            public int pnIdePro { get; set; }
            public string pcNomPro { get; set; }
            public string pcDesPro { get; set; }
            public decimal pnPrePro { get; set; }
            public int pnStoPro { get; set; }
            public DateTime ptFecPro { get; set; }
            public int pnIdeSed { get; set; }
        }


        public class ProductoActualizarRQT
        {
            public int pnIdePro { get; set; }

            public string pcNomPro { get; set; }
            public string pcDesPro { get; set; }
            public decimal pnPrePro { get; set; }

            public int pnStoPro { get; set; }

            public int pnIdeSed { get; set; }

        }

        public class Error
        {
            public string pcCodigo { get; set; }
            public string pcMensaje { get; set; }
        }



        public class ProductoActualizarRPT : Error
        {
            public int pnIdePro { get; set; }
            public string pcNomPro { get; set; }
            public string pcDesPro { get; set; }
            public decimal pnPrePro { get; set; }
            public int pnStoPro { get; set; }
            public DateTime ptFecPro { get; set; }
            public int pnIdeSed { get; set; }
        }

        public class ProductoEliminarRQT
        {
            public int pnIdePro { get; set; }

        }

        public class ProductoEliminarRPT : Error
        {
            public int pnIdePro { get; set; }
        }

        public class ProductoMoverRQT
        {
            public string pcNomPro { get; set; }
            public int pnIdeOri { get; set; }
            public int pnIdeDes { get; set; }
            public int pnCanMov { get; set; }
        }

        public class ProMovTrasladoRQT
        {
            public string cNomPro { get; set; }
            public int nIdeOri { get; set; }
            public int nIdeDes { get; set; }
            public int nCanMov { get; set; }
        }

        public class ProductoMoverRPT
        {
            public string pcCodigo { get; set; }
            public string pcMensaje { get; set; }
            public string pcNomPro { get; set; }
            public int pnIdeOri { get; set; }
            public int pnIdeDes { get; set; }
            public int pnCanMov { get; set; }
        }
}
