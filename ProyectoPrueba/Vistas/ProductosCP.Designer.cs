namespace ProyectoPrueba.Vistas
{
    partial class ProductosCP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbEditar = new System.Windows.Forms.Button();
            this.cmbListar = new System.Windows.Forms.Button();
            this.cmbElimin = new System.Windows.Forms.Button();
            this.txcNombre = new System.Windows.Forms.TextBox();
            this.txcDescrip = new System.Windows.Forms.TextBox();
            this.txnPrecio = new System.Windows.Forms.TextBox();
            this.txnStock = new System.Windows.Forms.TextBox();
            this.txntId = new System.Windows.Forms.TextBox();
            this.cmbInsert = new System.Windows.Forms.Button();
            this.grdProd = new System.Windows.Forms.DataGridView();
            this.lblIdePro = new System.Windows.Forms.Label();
            this.lblNomPro = new System.Windows.Forms.Label();
            this.lblDesPro = new System.Windows.Forms.Label();
            this.lblPrePro = new System.Windows.Forms.Label();
            this.lblStoPro = new System.Windows.Forms.Label();
            this.cmbLimpiar = new System.Windows.Forms.Button();
            this.lblSedPro = new System.Windows.Forms.Label();
            this.txnSede = new System.Windows.Forms.TextBox();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.cmbIniMov = new System.Windows.Forms.Button();
            this.lblProMov = new System.Windows.Forms.Label();
            this.lblIdeOri = new System.Windows.Forms.Label();
            this.lblIdeDes = new System.Windows.Forms.Label();
            this.lblCanMov = new System.Windows.Forms.Label();
            this.txcProMov = new System.Windows.Forms.TextBox();
            this.txnIdeOri = new System.Windows.Forms.TextBox();
            this.txnIdeDes = new System.Windows.Forms.TextBox();
            this.txnCanMov = new System.Windows.Forms.TextBox();
            this.cmbMovPro = new System.Windows.Forms.Button();
            this.txnColIdePro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txcColNomPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txcColDesPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnColPrePro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnColStoPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtColFecPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnColIdeSed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCancelMov = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEditar
            // 
            this.cmbEditar.Location = new System.Drawing.Point(353, 57);
            this.cmbEditar.Name = "cmbEditar";
            this.cmbEditar.Size = new System.Drawing.Size(75, 23);
            this.cmbEditar.TabIndex = 1;
            this.cmbEditar.Text = "Actualizar";
            this.cmbEditar.UseVisualStyleBackColor = true;
            this.cmbEditar.Click += new System.EventHandler(this.cmbEditar_Click);
            // 
            // cmbListar
            // 
            this.cmbListar.Location = new System.Drawing.Point(353, 86);
            this.cmbListar.Name = "cmbListar";
            this.cmbListar.Size = new System.Drawing.Size(75, 23);
            this.cmbListar.TabIndex = 2;
            this.cmbListar.Text = "Mostrar";
            this.cmbListar.UseVisualStyleBackColor = true;
            this.cmbListar.Click += new System.EventHandler(this.cmbListar_Click);
            // 
            // cmbElimin
            // 
            this.cmbElimin.Location = new System.Drawing.Point(353, 115);
            this.cmbElimin.Name = "cmbElimin";
            this.cmbElimin.Size = new System.Drawing.Size(75, 23);
            this.cmbElimin.TabIndex = 3;
            this.cmbElimin.Text = "Eliminar";
            this.cmbElimin.UseVisualStyleBackColor = true;
            this.cmbElimin.Click += new System.EventHandler(this.cmbElimin_Click);
            // 
            // txcNombre
            // 
            this.txcNombre.Location = new System.Drawing.Point(104, 65);
            this.txcNombre.Name = "txcNombre";
            this.txcNombre.Size = new System.Drawing.Size(220, 20);
            this.txcNombre.TabIndex = 4;
            // 
            // txcDescrip
            // 
            this.txcDescrip.Location = new System.Drawing.Point(104, 91);
            this.txcDescrip.Name = "txcDescrip";
            this.txcDescrip.Size = new System.Drawing.Size(220, 20);
            this.txcDescrip.TabIndex = 5;
            // 
            // txnPrecio
            // 
            this.txnPrecio.Location = new System.Drawing.Point(104, 117);
            this.txnPrecio.Name = "txnPrecio";
            this.txnPrecio.Size = new System.Drawing.Size(220, 20);
            this.txnPrecio.TabIndex = 6;
            // 
            // txnStock
            // 
            this.txnStock.Location = new System.Drawing.Point(104, 141);
            this.txnStock.Name = "txnStock";
            this.txnStock.Size = new System.Drawing.Size(220, 20);
            this.txnStock.TabIndex = 7;
            // 
            // txntId
            // 
            this.txntId.Enabled = false;
            this.txntId.Location = new System.Drawing.Point(104, 39);
            this.txntId.Name = "txntId";
            this.txntId.Size = new System.Drawing.Size(220, 20);
            this.txntId.TabIndex = 9;
            // 
            // cmbInsert
            // 
            this.cmbInsert.Location = new System.Drawing.Point(249, 196);
            this.cmbInsert.Name = "cmbInsert";
            this.cmbInsert.Size = new System.Drawing.Size(75, 23);
            this.cmbInsert.TabIndex = 11;
            this.cmbInsert.Text = "Insertar";
            this.cmbInsert.UseVisualStyleBackColor = true;
            this.cmbInsert.Click += new System.EventHandler(this.cmbInsert_Click);
            // 
            // grdProd
            // 
            this.grdProd.AllowUserToResizeColumns = false;
            this.grdProd.AllowUserToResizeRows = false;
            this.grdProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txnColIdePro,
            this.txcColNomPro,
            this.txcColDesPro,
            this.txnColPrePro,
            this.txnColStoPro,
            this.txtColFecPro,
            this.txnColIdeSed});
            this.grdProd.Location = new System.Drawing.Point(481, 42);
            this.grdProd.MultiSelect = false;
            this.grdProd.Name = "grdProd";
            this.grdProd.ReadOnly = true;
            this.grdProd.RowHeadersVisible = false;
            this.grdProd.Size = new System.Drawing.Size(702, 397);
            this.grdProd.TabIndex = 12;
            this.grdProd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProd_CellContentClick);
            // 
            // lblIdePro
            // 
            this.lblIdePro.AutoSize = true;
            this.lblIdePro.Location = new System.Drawing.Point(63, 42);
            this.lblIdePro.Name = "lblIdePro";
            this.lblIdePro.Size = new System.Drawing.Size(16, 13);
            this.lblIdePro.TabIndex = 13;
            this.lblIdePro.Text = "Id";
            // 
            // lblNomPro
            // 
            this.lblNomPro.AutoSize = true;
            this.lblNomPro.Location = new System.Drawing.Point(43, 71);
            this.lblNomPro.Name = "lblNomPro";
            this.lblNomPro.Size = new System.Drawing.Size(44, 13);
            this.lblNomPro.TabIndex = 14;
            this.lblNomPro.Text = "Nombre";
            // 
            // lblDesPro
            // 
            this.lblDesPro.AutoSize = true;
            this.lblDesPro.Location = new System.Drawing.Point(24, 98);
            this.lblDesPro.Name = "lblDesPro";
            this.lblDesPro.Size = new System.Drawing.Size(63, 13);
            this.lblDesPro.TabIndex = 15;
            this.lblDesPro.Text = "Descripcion";
            // 
            // lblPrePro
            // 
            this.lblPrePro.AutoSize = true;
            this.lblPrePro.Location = new System.Drawing.Point(41, 120);
            this.lblPrePro.Name = "lblPrePro";
            this.lblPrePro.Size = new System.Drawing.Size(37, 13);
            this.lblPrePro.TabIndex = 16;
            this.lblPrePro.Text = "Precio";
            // 
            // lblStoPro
            // 
            this.lblStoPro.AutoSize = true;
            this.lblStoPro.Location = new System.Drawing.Point(41, 144);
            this.lblStoPro.Name = "lblStoPro";
            this.lblStoPro.Size = new System.Drawing.Size(35, 13);
            this.lblStoPro.TabIndex = 17;
            this.lblStoPro.Text = "Stock";
            // 
            // cmbLimpiar
            // 
            this.cmbLimpiar.Location = new System.Drawing.Point(353, 144);
            this.cmbLimpiar.Name = "cmbLimpiar";
            this.cmbLimpiar.Size = new System.Drawing.Size(75, 23);
            this.cmbLimpiar.TabIndex = 18;
            this.cmbLimpiar.Text = "Limpiar";
            this.cmbLimpiar.UseVisualStyleBackColor = true;
            this.cmbLimpiar.Click += new System.EventHandler(this.cmbLimpiar_Click);
            // 
            // lblSedPro
            // 
            this.lblSedPro.AutoSize = true;
            this.lblSedPro.Location = new System.Drawing.Point(41, 170);
            this.lblSedPro.Name = "lblSedPro";
            this.lblSedPro.Size = new System.Drawing.Size(32, 13);
            this.lblSedPro.TabIndex = 20;
            this.lblSedPro.Text = "Sede";
            this.lblSedPro.Click += new System.EventHandler(this.label6_Click);
            // 
            // txnSede
            // 
            this.txnSede.Location = new System.Drawing.Point(104, 170);
            this.txnSede.Name = "txnSede";
            this.txnSede.Size = new System.Drawing.Size(220, 20);
            this.txnSede.TabIndex = 21;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // cmbIniMov
            // 
            this.cmbIniMov.Location = new System.Drawing.Point(104, 223);
            this.cmbIniMov.Name = "cmbIniMov";
            this.cmbIniMov.Size = new System.Drawing.Size(129, 46);
            this.cmbIniMov.TabIndex = 22;
            this.cmbIniMov.Text = "Iniciar Movimiento";
            this.cmbIniMov.UseVisualStyleBackColor = true;
            this.cmbIniMov.Click += new System.EventHandler(this.cmbIniMov_Click);
            // 
            // lblProMov
            // 
            this.lblProMov.AutoSize = true;
            this.lblProMov.Location = new System.Drawing.Point(14, 301);
            this.lblProMov.Name = "lblProMov";
            this.lblProMov.Size = new System.Drawing.Size(95, 13);
            this.lblProMov.TabIndex = 23;
            this.lblProMov.Text = "Nombre producto: ";
            this.lblProMov.Visible = false;
            // 
            // lblIdeOri
            // 
            this.lblIdeOri.AutoSize = true;
            this.lblIdeOri.Location = new System.Drawing.Point(195, 324);
            this.lblIdeOri.Name = "lblIdeOri";
            this.lblIdeOri.Size = new System.Drawing.Size(86, 13);
            this.lblIdeOri.TabIndex = 24;
            this.lblIdeOri.Text = "ID Sede Origen: ";
            this.lblIdeOri.Visible = false;
            // 
            // lblIdeDes
            // 
            this.lblIdeDes.AutoSize = true;
            this.lblIdeDes.Location = new System.Drawing.Point(190, 353);
            this.lblIdeDes.Name = "lblIdeDes";
            this.lblIdeDes.Size = new System.Drawing.Size(88, 13);
            this.lblIdeDes.TabIndex = 25;
            this.lblIdeDes.Text = "ID Sede Destino:";
            this.lblIdeDes.Visible = false;
            // 
            // lblCanMov
            // 
            this.lblCanMov.AutoSize = true;
            this.lblCanMov.Location = new System.Drawing.Point(226, 379);
            this.lblCanMov.Name = "lblCanMov";
            this.lblCanMov.Size = new System.Drawing.Size(52, 13);
            this.lblCanMov.TabIndex = 26;
            this.lblCanMov.Text = "Cantidad:";
            this.lblCanMov.Visible = false;
            // 
            // txcProMov
            // 
            this.txcProMov.Enabled = false;
            this.txcProMov.Location = new System.Drawing.Point(104, 298);
            this.txcProMov.Name = "txcProMov";
            this.txcProMov.Size = new System.Drawing.Size(220, 20);
            this.txcProMov.TabIndex = 27;
            this.txcProMov.Visible = false;
            // 
            // txnIdeOri
            // 
            this.txnIdeOri.Enabled = false;
            this.txnIdeOri.Location = new System.Drawing.Point(284, 324);
            this.txnIdeOri.Name = "txnIdeOri";
            this.txnIdeOri.Size = new System.Drawing.Size(40, 20);
            this.txnIdeOri.TabIndex = 28;
            this.txnIdeOri.Visible = false;
            // 
            // txnIdeDes
            // 
            this.txnIdeDes.Enabled = false;
            this.txnIdeDes.Location = new System.Drawing.Point(284, 350);
            this.txnIdeDes.Name = "txnIdeDes";
            this.txnIdeDes.Size = new System.Drawing.Size(40, 20);
            this.txnIdeDes.TabIndex = 29;
            this.txnIdeDes.Visible = false;
            // 
            // txnCanMov
            // 
            this.txnCanMov.Enabled = false;
            this.txnCanMov.Location = new System.Drawing.Point(284, 376);
            this.txnCanMov.Name = "txnCanMov";
            this.txnCanMov.Size = new System.Drawing.Size(40, 20);
            this.txnCanMov.TabIndex = 30;
            this.txnCanMov.Visible = false;
            // 
            // cmbMovPro
            // 
            this.cmbMovPro.Location = new System.Drawing.Point(215, 402);
            this.cmbMovPro.Name = "cmbMovPro";
            this.cmbMovPro.Size = new System.Drawing.Size(109, 37);
            this.cmbMovPro.TabIndex = 31;
            this.cmbMovPro.Text = "Realizar Trazlado";
            this.cmbMovPro.UseVisualStyleBackColor = true;
            this.cmbMovPro.Visible = false;
            this.cmbMovPro.Click += new System.EventHandler(this.cmbMovPro_Click);
            // 
            // txnColIdePro
            // 
            this.txnColIdePro.DataPropertyName = "pnIdePro";
            this.txnColIdePro.HeaderText = "ID";
            this.txnColIdePro.Name = "txnColIdePro";
            // 
            // txcColNomPro
            // 
            this.txcColNomPro.DataPropertyName = "pcNomPro";
            this.txcColNomPro.HeaderText = "NOMBRE";
            this.txcColNomPro.Name = "txcColNomPro";
            // 
            // txcColDesPro
            // 
            this.txcColDesPro.DataPropertyName = "pcDesPro";
            this.txcColDesPro.HeaderText = "DESCRIPCION";
            this.txcColDesPro.Name = "txcColDesPro";
            // 
            // txnColPrePro
            // 
            this.txnColPrePro.DataPropertyName = "pnPrePro";
            this.txnColPrePro.HeaderText = "PRECIO";
            this.txnColPrePro.Name = "txnColPrePro";
            // 
            // txnColStoPro
            // 
            this.txnColStoPro.DataPropertyName = "pnStoPro";
            this.txnColStoPro.HeaderText = "STOCK";
            this.txnColStoPro.Name = "txnColStoPro";
            // 
            // txtColFecPro
            // 
            this.txtColFecPro.DataPropertyName = "ptFecPro";
            this.txtColFecPro.HeaderText = "FECHA";
            this.txtColFecPro.Name = "txtColFecPro";
            // 
            // txnColIdeSed
            // 
            this.txnColIdeSed.DataPropertyName = "pnIdeSed";
            this.txnColIdeSed.HeaderText = "ID_SEDE";
            this.txnColIdeSed.Name = "txnColIdeSed";
            // 
            // cmbCancelMov
            // 
            this.cmbCancelMov.Location = new System.Drawing.Point(249, 223);
            this.cmbCancelMov.Name = "cmbCancelMov";
            this.cmbCancelMov.Size = new System.Drawing.Size(75, 46);
            this.cmbCancelMov.TabIndex = 32;
            this.cmbCancelMov.Text = "Cancelar Movimiento";
            this.cmbCancelMov.UseVisualStyleBackColor = true;
            this.cmbCancelMov.Click += new System.EventHandler(this.cmbCancelMov_Click);
            // 
            // ProductosCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 468);
            this.Controls.Add(this.cmbCancelMov);
            this.Controls.Add(this.cmbMovPro);
            this.Controls.Add(this.txnCanMov);
            this.Controls.Add(this.txnIdeDes);
            this.Controls.Add(this.txnIdeOri);
            this.Controls.Add(this.txcProMov);
            this.Controls.Add(this.lblCanMov);
            this.Controls.Add(this.lblIdeDes);
            this.Controls.Add(this.lblIdeOri);
            this.Controls.Add(this.lblProMov);
            this.Controls.Add(this.cmbIniMov);
            this.Controls.Add(this.txnSede);
            this.Controls.Add(this.lblSedPro);
            this.Controls.Add(this.cmbLimpiar);
            this.Controls.Add(this.lblStoPro);
            this.Controls.Add(this.lblPrePro);
            this.Controls.Add(this.lblDesPro);
            this.Controls.Add(this.lblNomPro);
            this.Controls.Add(this.lblIdePro);
            this.Controls.Add(this.grdProd);
            this.Controls.Add(this.cmbInsert);
            this.Controls.Add(this.txntId);
            this.Controls.Add(this.txnStock);
            this.Controls.Add(this.txnPrecio);
            this.Controls.Add(this.txcDescrip);
            this.Controls.Add(this.txcNombre);
            this.Controls.Add(this.cmbElimin);
            this.Controls.Add(this.cmbListar);
            this.Controls.Add(this.cmbEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProductosCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmbEditar;
        private System.Windows.Forms.Button cmbListar;
        private System.Windows.Forms.Button cmbElimin;
        private System.Windows.Forms.TextBox txcNombre;
        private System.Windows.Forms.TextBox txcDescrip;
        private System.Windows.Forms.TextBox txnPrecio;
        private System.Windows.Forms.TextBox txnStock;
        private System.Windows.Forms.TextBox txntId;
        private System.Windows.Forms.Button cmbInsert;
        private System.Windows.Forms.DataGridView grdProd;
        private System.Windows.Forms.Label lblIdePro;
        private System.Windows.Forms.Label lblNomPro;
        private System.Windows.Forms.Label lblDesPro;
        private System.Windows.Forms.Label lblPrePro;
        private System.Windows.Forms.Label lblStoPro;
        private System.Windows.Forms.Button cmbLimpiar;
        private System.Windows.Forms.Label lblSedPro;
        private System.Windows.Forms.TextBox txnSede;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Button cmbIniMov;
        private System.Windows.Forms.Label lblProMov;
        private System.Windows.Forms.Label lblIdeOri;
        private System.Windows.Forms.Label lblIdeDes;
        private System.Windows.Forms.Label lblCanMov;
        private System.Windows.Forms.TextBox txcProMov;
        private System.Windows.Forms.TextBox txnIdeOri;
        private System.Windows.Forms.TextBox txnIdeDes;
        private System.Windows.Forms.TextBox txnCanMov;
        private System.Windows.Forms.Button cmbMovPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColIdePro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txcColNomPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txcColDesPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColPrePro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColStoPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtColFecPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColIdeSed;
        private System.Windows.Forms.Button cmbCancelMov;
    }
}