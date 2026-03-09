using AppProductos.ViewModels;
using EsquemasMAUI.MauiEsquemas;

namespace AppProductos.Vistas;

public partial class EliminarProductoPage : ContentPage
{
    private readonly ProductoEliminarVM _vm;

    public EliminarProductoPage(ProductoCN toProducto)
    {
        InitializeComponent();
        _vm = new ProductoEliminarVM();
        BindingContext = _vm;
        _vm.CargarProducto(toProducto);

        _vm.OperacionCompletada += async (loExito, loMensaje) =>
        {
            await DisplayAlert(loExito ? "Éxito" : "Error", loMensaje, "OK");
            if (loExito) await Navigation.PopAsync();
        };
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
        => await Navigation.PopAsync();
}
