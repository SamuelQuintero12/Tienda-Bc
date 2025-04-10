namespace Principal
{
    partial class EditarUsuario
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
            btEditarP = new Button();
            label1 = new Label();
            tbNombre = new TextBox();
            tbCantidad = new TextBox();
            tbPrecio = new TextBox();
            tbDescripcion = new TextBox();
            Resultado1 = new Label();
            SuspendLayout();
            // 
            // btEditarP
            // 
            btEditarP.Location = new Point(209, 253);
            btEditarP.Name = "btEditarP";
            btEditarP.Size = new Size(131, 61);
            btEditarP.TabIndex = 40;
            btEditarP.Text = "editar productos";
            btEditarP.UseVisualStyleBackColor = true;
            btEditarP.Click += btEditarP_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 25);
            label1.Name = "label1";
            label1.Size = new Size(156, 30);
            label1.TabIndex = 39;
            label1.Text = "Editar producto";
            label1.Click += label1_Click;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(145, 83);
            tbNombre.Name = "tbNombre";
            tbNombre.PlaceholderText = "nombre";
            tbNombre.Size = new Size(278, 23);
            tbNombre.TabIndex = 38;
            tbNombre.TextChanged += tbNombre_TextChanged;
            // 
            // tbCantidad
            // 
            tbCantidad.Location = new Point(145, 224);
            tbCantidad.Name = "tbCantidad";
            tbCantidad.PlaceholderText = "cantidad";
            tbCantidad.Size = new Size(278, 23);
            tbCantidad.TabIndex = 33;
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(145, 178);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.PlaceholderText = "presio";
            tbPrecio.Size = new Size(278, 23);
            tbPrecio.TabIndex = 32;
            tbPrecio.TextChanged += tbPrecio_TextChanged;
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(145, 127);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.PlaceholderText = "descripcion";
            tbDescripcion.Size = new Size(278, 23);
            tbDescripcion.TabIndex = 31;
            // 
            // Resultado1
            // 
            Resultado1.AutoSize = true;
            Resultado1.Location = new Point(395, 109);
            Resultado1.Name = "Resultado1";
            Resultado1.Size = new Size(0, 15);
            Resultado1.TabIndex = 41;
            // 
            // EditarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 357);
            Controls.Add(Resultado1);
            Controls.Add(btEditarP);
            Controls.Add(label1);
            Controls.Add(tbNombre);
            Controls.Add(tbCantidad);
            Controls.Add(tbPrecio);
            Controls.Add(tbDescripcion);
            Name = "EditarUsuario";
            Text = "EditarUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btEditarP;
        private Label label1;
        private TextBox tbNombre;
        private TextBox tbCantidad;
        private TextBox tbPrecio;
        private TextBox tbDescripcion;
        private Label Resultado1;
    }
}