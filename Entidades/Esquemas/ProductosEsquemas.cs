using Negocio.Esquemas;
using System;
using System.ComponentModel.DataAnnotations;


namespace Negocio.Esquemas
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
        public int pnIdeSed { get; set;}

    }
    public class ProductoInsertarRQT
    {
        //[Required(ErrorMessage ="El nombre es obligatorio")]
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        //[Required(ErrorMessage = "El precio del producto es obligatorio")]
        //[Range(0.01, 9999.99, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal pnPrePro { get; set; }

        //[Required(ErrorMessage = "El # de existencias es obligatorio")]
        //[Range(0, 9999, ErrorMessage = "El # de existencias no puede ser negativo")]
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
        //[Required(ErrorMessage = "El nombre es obligatorio")]
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        //[Required(ErrorMessage = "El precio del producto es obligatorio")]
        //[Range(0.01, 9999.99, ErrorMessage ="El precio debe ser mayor a 0")]
        public decimal pnPrePro { get; set; }

        //[Required(ErrorMessage = "El # de existencias es obligatorio")]
        //[Range(0, 9999, ErrorMessage ="El # de existencias no puede ser negativo")]
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

   /* public class ProductoMoverRPT : Error
    {
        public string pcNomPro { get; set; }
        public int pnIdeOri { get; set; }
        public int pnIdeDes { get; set; }
        public int pnCanMov { get; set; }
    }*/

    // Único RQT que recibe el método de BLL con todo lo necesario
    public class ProMovTrasladoRQT
    {
        public string cNomPro { get; set; }
        public int nIdeOri { get; set; }
        public int nIdeDes { get; set; }
        public int nCanMov { get; set; }
    }

    // Respuesta que devuelve BLL a la capa superior
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

