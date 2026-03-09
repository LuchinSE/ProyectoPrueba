using AppProductos.ViewModels;

namespace AppProductos.Vistas;

public partial class InsertarProductoPage : ContentPage
{
    private readonly ProductoInsertarVM _vm;

    public InsertarProductoPage()
    {
        InitializeComponent();
        _vm = new ProductoInsertarVM();
        BindingContext = _vm;

        _vm.OperacionCompletada += async (loExito, loMensaje) =>
        {
            await DisplayAlert(loExito ? "Éxito" : "Error", loMensaje, "OK");
            if (loExito) await Navigation.PopAsync();
        };
    }
}
