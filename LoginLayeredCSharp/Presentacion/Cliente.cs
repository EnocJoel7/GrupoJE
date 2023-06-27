using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;


namespace Presentacion
{
    public partial class Cliente : Form
    {
        
        public Cliente()
        {
            InitializeComponent();
            
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            GridViewCliente.DataSource = Llenar_grid();
            GridViewEmpleado.DataSource = Llenar_gridempleado();
        }
        public DataTable Llenar_grid()
        {
            DataTable dt = new DataTable();
            string consulta = "select CodCli as 'CODIGO', CliDNI as 'DNI', CliNom as 'NOMBRE', CliApe as 'APELLIDO', CliTelef as 'TELÉFONO' from Cliente ";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void btnAgregarcliente_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "insert into cliente (CodCli, CliDNI, CliNom, CliApe, CliTelef)values(@CodCli, @CliDNI, @CliNom, @CliApe, @CliTelef)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CodCli", txtcodigocliente.Text);
            cmd1.Parameters.AddWithValue("@CliNom", txtnombrecliente.Text);
            cmd1.Parameters.AddWithValue("@CliApe", txtapellidocliente.Text);
            cmd1.Parameters.AddWithValue("@CliTelef", txttelefonocliente.Text);
            cmd1.Parameters.AddWithValue("@CliDNI", txtdnicliente.Text);
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Dato Agregado");

            GridViewCliente.DataSource = Llenar_grid();
        }

        private void GridViewCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtcodigocliente.Text = GridViewCliente.CurrentRow.Cells[0].Value.ToString();
                txtdnicliente.Text = GridViewCliente.CurrentRow.Cells[1].Value.ToString();
                txtnombrecliente.Text = GridViewCliente.CurrentRow.Cells[2].Value.ToString();
                txtapellidocliente.Text = GridViewCliente.CurrentRow.Cells[3].Value.ToString();
                txttelefonocliente.Text = GridViewCliente.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnModificarcliente_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "Update cliente set CliDNI = @CliDNI, CliNom = @CliNom, CliApe = @CliApe, CliTelef = @CliTelef WHERE CodCli = @CodCli";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@CodCli", txtcodigocliente.Text);
            cmd2.Parameters.AddWithValue("@CliDNI", txtdnicliente.Text);
            cmd2.Parameters.AddWithValue("@CliNom", txtnombrecliente.Text);
            cmd2.Parameters.AddWithValue("@CliApe", txtapellidocliente.Text);
            cmd2.Parameters.AddWithValue("@CliTelef", txttelefonocliente.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Dato Actualizado");

            GridViewCliente.DataSource = Llenar_grid();
        }

        private void btnEliminarcliente_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from cliente where CodCli = @CodCli";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("CodCli", txtcodigocliente.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Dato Eliminado");

            GridViewCliente.DataSource = Llenar_grid();
        }

        private void btnNuevocliente_Click(object sender, EventArgs e)
        {
            txtcodigocliente.Clear();
            txtdnicliente.Clear();
            txtnombrecliente.Clear();
            txtapellidocliente.Clear();
            txttelefonocliente.Clear();
            txtdireccioncliente.Clear();
            txtcodigocliente.Focus();
        }

        public DataTable Llenar_gridempleado()
        {
            DataTable dempleado= new DataTable();
            string consultaempleado = "Select CodigoEmpleado as 'CODIGO', EmpleadoDNI as 'DNI', EmpleadoNombre as 'NOMBRE', EmpleadoApellido as 'APELLIDO', EmpleadoCargo as 'CARGO' from Empleado ";
            SqlCommand cmdempleado = new SqlCommand(consultaempleado, Conexion.Conectar());

            SqlDataAdapter de = new SqlDataAdapter(cmdempleado);

            de.Fill(dempleado);
            return dempleado;
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            string insertarempleado = ("insert into Empleado(CodigoEmpleado, EmpleadoDNI, EmpleadoNombre, EmpleadoApellido, EmpleadoCargo) values (@CodigoEmpleado, @EmpleadoDNI, @EmpleadoNombre, @EmpleadoApellido, @EmpleadoCargo)");
            SqlCommand cmdempleado1 = new SqlCommand(insertarempleado, Conexion.Conectar());
            cmdempleado1.Parameters.AddWithValue("@CodigoEmpleado", txtcodigoempleado.Text);
            cmdempleado1.Parameters.AddWithValue("@EmpleadoDNI", txtdniempleado.Text);
            cmdempleado1.Parameters.AddWithValue("@EmpleadoNombre", txtnombreempleado.Text);
            cmdempleado1.Parameters.AddWithValue("@EmpleadoApellido", txtapellidoempleado.Text);
            cmdempleado1.Parameters.AddWithValue("@EmpleadoCargo", txtcargoempleado.Text);

            cmdempleado1.ExecuteNonQuery();
            MessageBox.Show("Dato Agregado");

            GridViewEmpleado.DataSource = Llenar_gridempleado();

        }

        private void GridViewEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtcodigoempleado.Text = GridViewEmpleado.CurrentRow.Cells[0].Value.ToString();
                txtdniempleado.Text = GridViewEmpleado.CurrentRow.Cells[1].Value.ToString();
                txtnombreempleado.Text = GridViewEmpleado.CurrentRow.Cells[2].Value.ToString();
                txtapellidoempleado.Text = GridViewEmpleado.CurrentRow.Cells[3].Value.ToString();
                txtcargoempleado.Text = GridViewEmpleado.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }


        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizarempleado = "Update Empleado set EmpleadoDNI = @EmpleadoDNI, EmpleadoNombre = @EmpleadoNombre, EmpleadoApellido = @EmpleadoApellido, EmpleadoCargo = @EmpleadoCargo where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand cmdempleado2 = new SqlCommand(actualizarempleado, Conexion.Conectar());
            cmdempleado2.Parameters.AddWithValue("@CodigoEmpleado", txtcodigoempleado.Text);
            cmdempleado2.Parameters.AddWithValue("@EmpleadoDNI", txtdniempleado.Text);
            cmdempleado2.Parameters.AddWithValue("@EmpleadoNombre", txtnombreempleado.Text);
            cmdempleado2.Parameters.AddWithValue("@EmpleadoApellido", txtapellidoempleado.Text);
            cmdempleado2.Parameters.AddWithValue("@EmpleadoCargo", txtcargoempleado.Text);

            cmdempleado2.ExecuteNonQuery();
            MessageBox.Show("Dato Actualizado");

            GridViewEmpleado.DataSource = Llenar_gridempleado();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminarempleado = "delete from empleado where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand cmdempleado3 = new SqlCommand(eliminarempleado, Conexion.Conectar());
            cmdempleado3.Parameters.AddWithValue("@CodigoEmpleado", txtcodigoempleado.Text);

            cmdempleado3.ExecuteNonQuery();
            MessageBox.Show("Dato Eliminado");

            GridViewEmpleado.DataSource = Llenar_gridempleado();
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            txtcodigoempleado.Clear();
            txtdniempleado.Clear();
            txtnombreempleado.Clear();
            txtapellidoempleado.Clear();
            txtcargoempleado.Clear();
            txtcodigoempleado.Focus();
        }



        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;


        private void pictureboxCliente_Click(object sender, EventArgs e)
        {
            // Configurar el PrintDocument
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true; // Establecer la orientación horizontal

            // Configurar el PrintPreviewDialog
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Mostrar el PrintPreviewDialog
            printPreviewDialog.ShowDialog();
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener el panel seleccionado (puedes ajustar esto según tu implementación)
            Panel panelSeleccionado = panelcliente;

            // Crear una imagen del contenido del panel seleccionado
            Bitmap panelBitmap = new Bitmap(panelSeleccionado.Width, panelSeleccionado.Height);
            panelSeleccionado.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panelSeleccionado.Width, panelSeleccionado.Height));

            // Dibujar la imagen en la página de impresión
            e.Graphics.DrawImage(panelBitmap, e.MarginBounds);
        }

        private void pictureboxEmpleado_Click(object sender, EventArgs e)
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocumentEmpleado_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true; // Establecer la orientación horizontal

            // Configurar el PrintPreviewDialog
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Mostrar el PrintPreviewDialog
            printPreviewDialog.ShowDialog();
        }
        private void PrintDocumentEmpleado_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener la imagen del PictureBox del empleado (puedes ajustar esto según tu implementación)
            Panel panelseleccionempleado = panelempleado;
            Bitmap panelbitmapempleado = new Bitmap(panelseleccionempleado.Width, panelseleccionempleado.Height);
            panelseleccionempleado.DrawToBitmap(panelbitmapempleado, new Rectangle(0, 0, panelseleccionempleado.Width, panelseleccionempleado.Height));
            e.Graphics.DrawImage(panelbitmapempleado, e.MarginBounds);
        }

    }
}
