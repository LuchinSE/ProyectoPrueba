using AppProductos.ViewModels;

namespace AppProductos.Vistas;

public partial class TrasladarProductoPage : ContentPage
{
    private readonly ProductoTrasladoVM _vm;

    public TrasladarProductoPage()
    {
        InitializeComponent();
        _vm = new ProductoTrasladoVM();
        BindingContext = _vm;

        _vm.OperacionCompletada += async (loExito, loMensaje) =>
        {
            await DisplayAlert(loExito ? "Éxito" : "Error", loMensaje, "OK");
            if (loExito) await Navigation.PopAsync();
        };
    }
}
