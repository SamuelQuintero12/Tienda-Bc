namespace Principal
{
    partial class AgregarP
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
            label1 = new Label();
            btAgregar = new Button();
            tbResultado = new Label();
            tbNombre = new TextBox();
            tbCantidad = new TextBox();
            tbPrecio = new TextBox();
            tbDescripcion = new TextBox();
            tbImagen = new TextBox();
            tbProovedor = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(309, 39);
            label1.Name = "label1";
            label1.Size = new Size(177, 30);
            label1.TabIndex = 5;
            label1.Text = "Agregar producto";
            // 
            // btAgregar
            // 
            btAgregar.Location = new Point(277, 366);
            btAgregar.Name = "btAgregar";
            btAgregar.Size = new Size(278, 56);
            btAgregar.TabIndex = 6;
            btAgregar.Text = "Agregar";
            btAgregar.UseVisualStyleBackColor = true;
            btAgregar.Click += btAgregar_Click;
            // 
            // tbResultado
            // 
            tbResultado.AutoSize = true;
            tbResultado.Location = new Point(555, 187);
            tbResultado.Name = "tbResultado";
            tbResultado.Size = new Size(0, 15);
            tbResultado.TabIndex = 7;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(277, 88);
            tbNombre.Name = "tbNombre";
            tbNombre.PlaceholderText = "nombre";
            tbNombre.Size = new Size(278, 23);
            tbNombre.TabIndex = 42;
            // 
            // tbCantidad
            // 
            tbCantidad.Location = new Point(277, 229);
            tbCantidad.Name = "tbCantidad";
            tbCantidad.PlaceholderText = "cantidad";
            tbCantidad.Size = new Size(278, 23);
            tbCantidad.TabIndex = 41;
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(277, 179);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.PlaceholderText = "precio";
            tbPrecio.Size = new Size(278, 23);
            tbPrecio.TabIndex = 40;
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(277, 137);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.PlaceholderText = "descripcion";
            tbDescripcion.Size = new Size(278, 23);
            tbDescripcion.TabIndex = 39;
            // 
            // tbImagen
            // 
            tbImagen.Location = new Point(277, 283);
            tbImagen.Name = "tbImagen";
            tbImagen.PlaceholderText = "imagen";
            tbImagen.Size = new Size(278, 23);
            tbImagen.TabIndex = 4;
            // 
            // tbProovedor
            // 
            tbProovedor.Location = new Point(277, 327);
            tbProovedor.Name = "tbProovedor";
            tbProovedor.PlaceholderText = "proveedor";
            tbProovedor.Size = new Size(278, 23);
            tbProovedor.TabIndex = 43;
            // 
            // AgregarP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbProovedor);
            Controls.Add(tbNombre);
            Controls.Add(tbCantidad);
            Controls.Add(tbPrecio);
            Controls.Add(tbDescripcion);
            Controls.Add(tbResultado);
            Controls.Add(btAgregar);
            Controls.Add(label1);
            Controls.Add(tbImagen);
            Name = "AgregarP";
            Text = "AgregarP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btAgregar;
        private Label tbResultado;
        private TextBox tbNombre;
        private TextBox tbCantidad;
        private TextBox tbPrecio;
        private TextBox tbDescripcion;
        private TextBox tbImagen;
        private TextBox tbProovedor;
    }
}