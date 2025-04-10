namespace Principal
{
    partial class EliminarP
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
            btElimninar = new Button();
            resultado = new Label();
            tbId = new TextBox();
            SuspendLayout();
            // 
            // btElimninar
            // 
            btElimninar.Location = new Point(332, 100);
            btElimninar.Name = "btElimninar";
            btElimninar.Size = new Size(121, 43);
            btElimninar.TabIndex = 0;
            btElimninar.Text = "eliminar producto";
            btElimninar.UseVisualStyleBackColor = true;
            btElimninar.Click += btElimninar_Click;
            // 
            // resultado
            // 
            resultado.AutoSize = true;
            resultado.Location = new Point(125, 200);
            resultado.Name = "resultado";
            resultado.Size = new Size(0, 15);
            resultado.TabIndex = 1;
            // 
            // tbId
            // 
            tbId.Location = new Point(277, 259);
            tbId.Name = "tbId";
            tbId.PlaceholderText = "nombre Producto";
            tbId.Size = new Size(243, 23);
            tbId.TabIndex = 2;
            // 
            // EliminarP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbId);
            Controls.Add(resultado);
            Controls.Add(btElimninar);
            Name = "EliminarP";
            Text = "EliminarP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btElimninar;
        private Label resultado;
        private TextBox tbId;
    }
}