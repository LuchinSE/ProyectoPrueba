using AppProductos.ViewModels;
using EsquemasMAUI.MauiEsquemas;

namespace AppProductos.Vistas;

public partial class ActualizarProductoPage : ContentPage
{
    private readonly ProductoActualizarVM _vm;

    public ActualizarProductoPage(ProductoCN toProducto)
    {
        InitializeComponent();
        _vm = new ProductoActualizarVM();
        BindingContext = _vm;
        _vm.CargarProducto(toProducto);

        _vm.OperacionCompletada += async (loExito, loMensaje) =>
        {
            await DisplayAlert(loExito ? "Éxito" : "Error", loMensaje, "OK");
            if (loExito) await Navigation.PopAsync();
        };
    }
}