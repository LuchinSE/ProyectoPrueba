using System;
using Transversal;
using System.Windows.Forms;
using ReferenciaServicios.WRGestionProductos;
using System.Drawing;
namespace ProyectoPrueba.Vistas
{
    public partial class ProductosCP : Form
    {

        public ProductosCP()
        {
            this.InitializeComponent();
        }

        private void cmbElimin_Click(object sender, EventArgs e)
        {
            WSGestionProductos loRefGestProd = new WSGestionProductos();
            ProductoEliminarRQT loProductoEliminar = new ProductoEliminarRQT();
            if (string.IsNullOrWhiteSpace(txntId.Text))
            {
                MessageBox.Show("El id es obligatorio");
                txcNombre.Focus();
                return;
            }

            loProductoEliminar.pnIdePro = Convert.ToInt32(txntId.Text);
            
            loRefGestProd.wmEliminarProducto(loProductoEliminar);
            this.Form1_Load(this, EventArgs.Empty);


        }

        private void cmbInsert_Click(object sender, EventArgs e)
        {
            WSGestionProductos loRefGestProd = new WSGestionProductos();
            int lnStoPro, lnIdeSed;
            decimal lnPrePro;
            string lcNomPro, lcDesPro;
            if (!this.ValidarFormulario())
                return;

            lcNomPro = this.txcNombre.Text;
            lcDesPro = this.txcDescrip.Text;
            lnPrePro = Convert.ToDecimal(txnPrecio.Text);
            lnStoPro = Convert.ToInt32(txnStock.Text);
            lnIdeSed = Convert.ToInt32(txnSede.Text);

            ProductoInsertarRQT producto = new ProductoInsertarRQT();
            {
                producto.pcNomPro = lcNomPro;
                producto.pcDesPro = lcDesPro;
                producto.pnPrePro = lnPrePro;
                producto.pnStoPro = lnStoPro;
                producto.pnIdeSed = lnIdeSed;
            };

            
            loRefGestProd.wmCrearProducto(producto);
            this.Form1_Load(this, EventArgs.Empty);
        }

        private void cmbListar_Click(object sender, EventArgs e)
        {

            this.Form1_Load(this, EventArgs.Empty); 
            MessageBox.Show(Constantes._M_CARGA_REGISTRO);
        }
        private void cmbEditar_Click(object sender, EventArgs e)
        {
            WSGestionProductos loRefGestProd = new WSGestionProductos();
            int lnIdePro,lnStoPro, lnIdeSed;
            decimal lnPrePro;
            string lcNomPro, lcDesPro;
            if (!this.ValidarFormulario())
                return;

            lnIdePro = Convert.ToInt32(this.txntId.Text);
            lcNomPro = this.txcNombre.Text;
            lcDesPro = this.txcDescrip.Text;
            lnPrePro = Convert.ToDecimal(txnPrecio.Text);
            lnStoPro = Convert.ToInt32(txnStock.Text);
            lnIdeSed = Convert.ToInt32(txnSede.Text);

            ProductoActualizarRQT producto = new ProductoActualizarRQT
            {
                pnIdePro = lnIdePro,
                pcNomPro = lcNomPro,
                pcDesPro = lcDesPro,
                pnPrePro = lnPrePro,
                pnStoPro = lnStoPro,
                pnIdeSed = lnIdeSed
            };

            
            loRefGestProd.wmActualizarProducto(producto);
            this.Form1_Load(this, EventArgs.Empty);

        }

        private void grdProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.LimpiarCampos();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = grdProd.Rows[e.RowIndex];

                this.txntId.Text = fila.Cells["txnColIdePro"].Value.ToString();
                this.txcNombre.Text = fila.Cells["txcColNomPro"].Value.ToString();
                this.txcDescrip.Text = fila.Cells["txcColDesPro"].Value.ToString();
                this.txnPrecio.Text = fila.Cells["txnColPrePro"].Value.ToString();
                this.txnStock.Text = fila.Cells["txnColStoPro"].Value.ToString();
                this.txnSede.Text = fila.Cells["txnColIdeSed"].Value.ToString();
            }
        }


        private void LimpiarCampos()
        {
            txntId.Clear();
            txcNombre.Clear();
            txcDescrip.Clear();
            txnPrecio.Clear();
            txnStock.Clear();
            txcNombre.Focus();
            txnSede.Clear();
        }

        private void mxCargarDatos()
        {
            WSGestionProductos loRefGestProd = new WSGestionProductos();
            ProductosRPT listaLlena = loRefGestProd.wmListarProductos();
            grdProd.DataSource = listaLlena.paProductos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.mxCargarDatos();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txcNombre.Text))
            {
                MessageBox.Show(Constantes._M_ERROR_CAMPO, "Nombre");
                this.txcNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txcDescrip.Text))
            {
                MessageBox.Show(Constantes._M_ERROR_CAMPO, "Descripcion");
                this.txcDescrip.Focus();
                return false;
            }

            if (!decimal.TryParse(txnPrecio.Text, out decimal precio))
            {
                MessageBox.Show(Constantes._M_ERROR_CAMPO, "Precio");
                this.txnPrecio.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show(Constantes._M_ERROR_PRECIO);
                this.txnPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txnStock.Text, out int stock))
            {
                MessageBox.Show(Constantes._M_STOCK_INVALIDO);
                this.txnStock.Focus();
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show(Constantes._M_STOCK_NEGATIVO);
                this.txnStock.Focus();
                return false;
            }
            return true;
        }

        private void cmbIniMov_Click(object sender, EventArgs e)
        {
            this.mxHabilitarControles();
        }

        private void mxHabilitarControles() 
        {
            this.lblProMov.Visible = true;
            this.lblIdeOri.Visible = true;
            this.lblIdeDes.Visible = true;
            this.lblCanMov.Visible = true;
            this.txcProMov.Visible = true;
            this.txnIdeOri.Visible = true;
            this.txnIdeDes.Visible = true;
            this.txnCanMov.Visible = true;
            this.cmbMovPro.Visible = true;
            this.txcProMov.Enabled = true;
            this.txnIdeOri.Enabled = true;
            this.txnIdeDes.Enabled = true;
            this.txnCanMov.Enabled = true;
            
        }

        private void cmbMovPro_Click(object sender, EventArgs e)
        {
            string lcNomPro;
            int lnIdeOri, lnIdeDes, lnCanMov;
            WSGestionProductos loRefGestProd = new WSGestionProductos();

            lcNomPro = txcProMov.Text;
            lnIdeOri = Convert.ToInt32(this.txnIdeOri.Text);
            lnIdeDes = Convert.ToInt32(this.txnIdeDes.Text);
            lnCanMov = Convert.ToInt32(this.txnCanMov.Text);

            ProMovTrasladoRQT loProductoRqt = new ProMovTrasladoRQT()
            {
                cNomPro = lcNomPro,
                nIdeOri = lnIdeOri,
                nIdeDes = lnIdeDes,
                nCanMov = lnCanMov
            };

            ProductoMoverRPT loRespuesta = loRefGestProd.wmTrasladarProducto(loProductoRqt);

            if (loRespuesta.pcCodigo == "200")
            {
                MessageBox.Show(loRespuesta.pcMensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Form1_Load(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(loRespuesta.pcMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
