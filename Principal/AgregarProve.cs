using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Principal
{
    public partial class AgregarProve : Form
    {
        public AgregarProve()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(228, 198);
            button1.Name = "button1";
            button1.Size = new Size(92, 32);
            button1.TabIndex = 0;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AgregarProve
            // 
            ClientSize = new Size(577, 451);
            Controls.Add(button1);
            Name = "AgregarProve";
            ResumeLayout(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private Button button1;
    }
}
