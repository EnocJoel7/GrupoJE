using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.M)
            {
                // Acción para CTRL + M (Ejemplo: Hacer clic en el botón btnCliente)
                btnCliente_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                // Acción para CTRL + P (Ejemplo: Hacer clic en el botón button2)
                button2_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                // Acción para CTRL + C (Ejemplo: Hacer clic en el botón btnContacto)
                btnContacto_Click(sender, e);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirFormHijo(object formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new GRUPOJEPresentacion());
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Cliente());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Proyecto());
        }
        private void btnContacto_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Contacto());
        }
    }
}
