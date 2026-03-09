using AppProductos.ViewModels;

namespace AppProductos.Vistas;

public partial class ListarProductosPage : ContentPage
{
    private readonly ProductoListarVM _vm;

    public ListarProductosPage()
    {
        InitializeComponent();

        _vm = new ProductoListarVM();
        BindingContext = _vm;          
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _vm.ProductoSeleccionado = null; 
        await _vm.CargarProductos();
    }

    private async void OnInsertarClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new InsertarProductoPage());

    private async void OnActualizarClicked(object sender, EventArgs e)
    {
        if (_vm.ProductoSeleccionado == null) return;
        await Navigation.PushAsync(new ActualizarProductoPage(_vm.ProductoSeleccionado));
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        if (_vm.ProductoSeleccionado == null) return;

        bool lbConfirmar = await DisplayAlert(
            "Eliminar producto",
            $"¿Deseas eliminar '{_vm.ProductoSeleccionado.pcNomPro}'?",
            "Sí, eliminar", "Cancelar");

        if (lbConfirmar)
            await Navigation.PushAsync(new EliminarProductoPage(_vm.ProductoSeleccionado));
    }

    private async void OnTrasladarClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new TrasladarProductoPage());
}
