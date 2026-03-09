using AppProductos.Servicios;
using EsquemasMAUI.MauiEsquemas;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppProductos.ViewModels
{
    // ══════════════════════════════════════════════════════
    //  BASE ViewModel
    // ══════════════════════════════════════════════════════
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));

        protected bool SetProperty<T>(ref T campo, T valor, [CallerMemberName] string nombre = null)
        {
            if (EqualityComparer<T>.Default.Equals(campo, valor)) return false;
            campo = valor;
            OnPropertyChanged(nombre);
            return true;
        }

        private bool _estaOcupado;
        public bool EstaOcupado
        {
            get => _estaOcupado;
            set => SetProperty(ref _estaOcupado, value);
        }

        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
            set => SetProperty(ref _mensaje, value);
        }
    }


    // ══════════════════════════════════════════════════════
    //  LISTAR
    // ══════════════════════════════════════════════════════
    public class ProductoListarVM : BaseViewModel
    {
        private readonly ProductoServicio _servicio = new ProductoServicio();

        public ObservableCollection<ProductoCN> Productos { get; set; } = new();

        private ProductoCN _productoSeleccionado;
        public ProductoCN ProductoSeleccionado
        {
            get => _productoSeleccionado;
            set => SetProperty(ref _productoSeleccionado, value);
        }

        public ICommand CargarCommand { get; }

        public ProductoListarVM()
        {
            CargarCommand = new Command(async () => await CargarProductos());
        }

        public async Task CargarProductos()
        {
            EstaOcupado = true;
            Mensaje = string.Empty;
            try
            {
                ProductosRPT loRpt = await _servicio.mxObtenerProductos();
                Productos.Clear();
                if (loRpt?.paProductos != null)
                    foreach (var p in loRpt.paProductos)
                        Productos.Add(p);
                else
                    Mensaje = loRpt?.pcMensaje ?? "Sin resultados";
            }
            finally
            {
                EstaOcupado = false;
            }
        }
    }



    //  INSERTAR
    public class ProductoInsertarVM : BaseViewModel
    {
        private readonly ProductoServicio _servicio = new ProductoServicio();

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        private string _descripcion;
        public string Descripcion
        {
            get => _descripcion;
            set => SetProperty(ref _descripcion, value);
        }

        private string _precio;
        public string Precio
        {
            get => _precio;
            set => SetProperty(ref _precio, value);
        }

        private string _stock;
        public string Stock
        {
            get => _stock;
            set => SetProperty(ref _stock, value);
        }

        private string _ideSede;
        public string IdeSede
        {
            get => _ideSede;
            set => SetProperty(ref _ideSede, value);
        }

        private ProductoInsertarRPT _resultado;
        public ProductoInsertarRPT Resultado
        {
            get => _resultado;
            set => SetProperty(ref _resultado, value);
        }

        public event Action<bool, string> OperacionCompletada;

        public ICommand InsertarCommand { get; }

        public ProductoInsertarVM()
        {
            InsertarCommand = new Command(async () => await Insertar());
        }

        private async Task Insertar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                !decimal.TryParse(Precio, out decimal lnPrecio) ||
                !int.TryParse(Stock, out int lnStock) ||
                !int.TryParse(IdeSede, out int lnIdeSede))
            {
                OperacionCompletada?.Invoke(false, "Completa todos los campos correctamente");
                return;
            }

            EstaOcupado = true;
            try
            {
                Resultado = await _servicio.mxInsertarProducto(new ProductoInsertarRQT
                {
                    pcNomPro = Nombre,
                    pcDesPro = Descripcion,
                    pnPrePro = lnPrecio,
                    pnStoPro = lnStock,
                    pnIdeSed = lnIdeSede
                });
                bool loExito = Resultado?.pcCodigo != "ERR";
                string loMensaje = Resultado?.pcMensaje ?? (loExito ? "Producto insertado correctamente" : "Error al insertar");
                OperacionCompletada?.Invoke(loExito, loMensaje);
            }
            catch (Exception ex)
            {
                OperacionCompletada?.Invoke(false, ex.Message);
            }
            finally
            {
                EstaOcupado = false;
            }
        }
    }


    
    //  ACTUALIZAR
   
    public class ProductoActualizarVM : BaseViewModel
    {
        private readonly ProductoServicio _servicio = new ProductoServicio();

        private int _idProducto;
        public int IdProducto
        {
            get => _idProducto;
            set => SetProperty(ref _idProducto, value);
        }

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        private string _descripcion;
        public string Descripcion
        {
            get => _descripcion;
            set => SetProperty(ref _descripcion, value);
        }

        private string _precio;
        public string Precio
        {
            get => _precio;
            set => SetProperty(ref _precio, value);
        }

        private string _stock;
        public string Stock
        {
            get => _stock;
            set => SetProperty(ref _stock, value);
        }

        private string _ideSede;
        public string IdeSede
        {
            get => _ideSede;
            set => SetProperty(ref _ideSede, value);
        }

        private ProductoActualizarRPT _resultado;
        public ProductoActualizarRPT Resultado
        {
            get => _resultado;
            set => SetProperty(ref _resultado, value);
        }

        public event Action<bool, string> OperacionCompletada;

        public ICommand ActualizarCommand { get; }

        public ProductoActualizarVM()
        {
            ActualizarCommand = new Command(async () => await Actualizar());
        }

        public void CargarProducto(ProductoCN toProducto)
        {
            IdProducto = toProducto.pnIdePro;
            Nombre = toProducto.pcNomPro;
            Descripcion = toProducto.pcDesPro;
            Precio = toProducto.pnPrePro.ToString();
            Stock = toProducto.pnStoPro.ToString();
            IdeSede = toProducto.pnIdeSed.ToString();
        }

        private async Task Actualizar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                !decimal.TryParse(Precio, out decimal lnPrecio) ||
                !int.TryParse(Stock, out int lnStock) ||
                !int.TryParse(IdeSede, out int lnIdeSede))
            {
                OperacionCompletada?.Invoke(false, "Completa todos los campos correctamente");
                return;
            }

            EstaOcupado = true;
            try
            {
                Resultado = await _servicio.mxActualizarProducto(new ProductoActualizarRQT
                {
                    pnIdePro = IdProducto,
                    pcNomPro = Nombre,
                    pcDesPro = Descripcion,
                    pnPrePro = lnPrecio,
                    pnStoPro = lnStock,
                    pnIdeSed = lnIdeSede
                });
                bool loExito = Resultado?.pcCodigo != "ERR";
                string loMensaje = Resultado?.pcMensaje ?? (loExito ? "Producto actualizado correctamente" : "Error al actualizar");
                OperacionCompletada?.Invoke(loExito, loMensaje);
            }
            catch (Exception ex)
            {
                OperacionCompletada?.Invoke(false, ex.Message);
            }
            finally
            {
                EstaOcupado = false;
            }
        }
    }


 
    //  ELIMINAR
  
    public class ProductoEliminarVM : BaseViewModel
    {
        private readonly ProductoServicio _servicio = new ProductoServicio();

        private int _idProducto;
        public int IdProducto
        {
            get => _idProducto;
            set => SetProperty(ref _idProducto, value);
        }

        private string _nombreProducto;
        public string NombreProducto
        {
            get => _nombreProducto;
            set => SetProperty(ref _nombreProducto, value);
        }

        private ProductoEliminarRPT _resultado;
        public ProductoEliminarRPT Resultado
        {
            get => _resultado;
            set => SetProperty(ref _resultado, value);
        }

        public event Action<bool, string> OperacionCompletada;

        public ICommand EliminarCommand { get; }

        public ProductoEliminarVM()
        {
            EliminarCommand = new Command(async () => await Eliminar());
        }

        public void CargarProducto(ProductoCN toProducto)
        {
            IdProducto = toProducto.pnIdePro;
            NombreProducto = toProducto.pcNomPro;
        }

        private async Task Eliminar()
        {
            EstaOcupado = true;
            try
            {
                Resultado = await _servicio.mxEliminarProducto(new ProductoEliminarRQT
                {
                    pnIdePro = IdProducto
                });
                System.Diagnostics.Debug.WriteLine($"ELIMINAR - pcCodigo: '{Resultado?.pcCodigo}' | pcMensaje: '{Resultado?.pcMensaje}'");
                bool loExito = Resultado?.pcCodigo != "ERR";
                string loMensaje = Resultado?.pcMensaje ?? (loExito ? "Producto eliminado correctamente" : "Error al eliminar");
                OperacionCompletada?.Invoke(loExito, loMensaje);
            }
            catch (Exception ex)
            {
                OperacionCompletada?.Invoke(false, ex.Message);
            }
            finally
            {
                EstaOcupado = false;
            }
        }
    }



    //  TRASLADAR 
    
    public class ProductoTrasladoVM : BaseViewModel
    {
        private readonly ProductoServicio _servicio = new ProductoServicio();

        private string _nombreProducto;
        public string NombreProducto
        {
            get => _nombreProducto;
            set => SetProperty(ref _nombreProducto, value);
        }

        private string _sedeOrigen;
        public string SedeOrigen
        {
            get => _sedeOrigen;
            set => SetProperty(ref _sedeOrigen, value);
        }

        private string _sedeDestino;
        public string SedeDestino
        {
            get => _sedeDestino;
            set => SetProperty(ref _sedeDestino, value);
        }

        private string _cantidad;
        public string Cantidad
        {
            get => _cantidad;
            set => SetProperty(ref _cantidad, value);
        }

        private ProductoMoverRPT _resultado;
        public ProductoMoverRPT Resultado
        {
            get => _resultado;
            set => SetProperty(ref _resultado, value);
        }

        // ✅ Agregado
        public event Action<bool, string> OperacionCompletada;

        public ICommand TrasladarCommand { get; }

        public ProductoTrasladoVM()
        {
            TrasladarCommand = new Command(async () => await Trasladar());
        }

        private async Task Trasladar()
        {
            if (string.IsNullOrWhiteSpace(NombreProducto) ||
                !int.TryParse(SedeOrigen, out int lnOrigen) ||
                !int.TryParse(SedeDestino, out int lnDestino) ||
                !int.TryParse(Cantidad, out int lnCantidad))
            {
                OperacionCompletada?.Invoke(false, "Completa todos los campos correctamente");
                return;
            }

            if (lnOrigen == lnDestino)
            {
                OperacionCompletada?.Invoke(false, "La sede origen y destino no pueden ser iguales");
                return;
            }

            if (lnCantidad <= 0)
            {
                OperacionCompletada?.Invoke(false, "La cantidad debe ser mayor a 0");
                return;
            }

            EstaOcupado = true;
            try
            {
                Resultado = await _servicio.mxTrasladarProducto(new ProMovTrasladoRQT
                {
                    cNomPro = NombreProducto,
                    nIdeOri = lnOrigen,
                    nIdeDes = lnDestino,
                    nCanMov = lnCantidad
                });
                System.Diagnostics.Debug.WriteLine($"TRASLADAR - pcCodigo: '{Resultado?.pcCodigo}' | pcMensaje: '{Resultado?.pcMensaje}'");

                bool loExito = Resultado?.pcCodigo != "ERR";
                string loMensaje = Resultado?.pcMensaje ?? (loExito ? "Traslado realizado correctamente" : "Error al trasladar");
                // ✅ Agregado
                OperacionCompletada?.Invoke(loExito, loMensaje);
            }
            catch (Exception ex)
            {
                // ✅ Agregado
                OperacionCompletada?.Invoke(false, ex.Message);
            }
            finally
            {
                EstaOcupado = false;
            }
        }
    }
}
