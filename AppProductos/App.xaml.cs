namespace AppProductos
{
    public partial class App : Application
    {
        /*public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppProductos.Vistas.ListarProductosPage());
        }*/

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new AppProductos.Vistas.ListarProductosPage())
            {
                BarBackgroundColor = Color.FromArgb("#1565C0"),
                BarTextColor = Colors.White
            });
        }
    }
}