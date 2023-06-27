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
    public partial class Proyecto : Form
    {
        public Proyecto()
        {
            InitializeComponent();
        }
        private void Proyecto_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            GridViewProyecto.DataSource = Llenar_gridproyecto();

            string consultaestadoproyecto = "SELECT * FROM Estado ORDER BY CASE WHEN EstadoNombre = 'Pendiente' THEN 1 WHEN EstadoNombre = 'En Progreso' THEN 2 WHEN EstadoNombre = 'Finalizado' THEN 3 ELSE 4 END;";
            SqlCommand cmdconsultaestadoproyecto = new SqlCommand(consultaestadoproyecto, Conexion.Conectar());
            SqlDataReader reader = cmdconsultaestadoproyecto.ExecuteReader();
            cmbestadoproyecto.Items.Clear();
            while (reader.Read())
            {
                string codigoProyecto= reader["EstadoNombre"].ToString();
                string estproyecto = codigoProyecto;
                cmbestadoproyecto.Items.Add(estproyecto);
            }
            //cmb categoria - cmbservicios
            string queryCategorias = "SELECT CategoriaNombre FROM Categoria";
            SqlCommand cmdCategorias = new SqlCommand(queryCategorias, Conexion.Conectar());

            SqlDataReader readerCategorias = cmdCategorias.ExecuteReader();

            while (readerCategorias.Read())
            {
                cmbcategoriaproyecto.Items.Add(readerCategorias["CategoriaNombre"].ToString());
            }

            string consultarangoproyecto = "select * from rango order by RangoNombre desc";
            SqlCommand cmdconsultarangoproyecto = new SqlCommand(consultarangoproyecto, Conexion.Conectar());
            SqlDataReader readerrangoproyecto = cmdconsultarangoproyecto.ExecuteReader();
            cmbrangoproyecto.Items.Clear();
            while (readerrangoproyecto.Read())
            {
                string codigoRango = readerrangoproyecto["RangoNombre"].ToString();
                string rangoproyecto= codigoRango;
                cmbrangoproyecto.Items.Add(rangoproyecto);
            }

            string consultaclienteproyecto = "select CodCli from Cliente";
            SqlCommand cmdconsultaclienteproyecto = new SqlCommand(consultaclienteproyecto, Conexion.Conectar());
            SqlDataReader readerclienteproyecto = cmdconsultaclienteproyecto.ExecuteReader();
            cmbclienteproyecto.Items.Clear();
            while (readerclienteproyecto.Read())
            {
                string codigocliente = readerclienteproyecto["CodCli"].ToString();
                string clienteproyecto = codigocliente;
                cmbclienteproyecto.Items.Add(clienteproyecto);
            }

            string consultaoperarioproyecto = "select CodigoEmpleado from Empleado";
            SqlCommand cmdconsultaoperarioproyecto = new SqlCommand(consultaoperarioproyecto, Conexion.Conectar());
            SqlDataReader readerempleadoproyecto = cmdconsultaoperarioproyecto.ExecuteReader();
            cmboperarioproyecto.Items.Clear();
            while (readerempleadoproyecto.Read())
            {
                string codigoempleado = readerempleadoproyecto["CodigoEmpleado"].ToString();
                string empleadoproyecto = codigoempleado;
                cmboperarioproyecto.Items.Add(empleadoproyecto);
            }

            string consultacontactoproyecto = "select CodigoProveedor from Proveedor";
            SqlCommand cmdconsultacontactoproyecto = new SqlCommand(consultacontactoproyecto, Conexion.Conectar());
            SqlDataReader readercontactoproyecto = cmdconsultacontactoproyecto.ExecuteReader();
            cmbcontactoproyecto.Items.Clear();
            while (readercontactoproyecto.Read())
            {
                string codigocontacto = readercontactoproyecto["CodigoProveedor"].ToString();
                string contactoproyecto = codigocontacto;
                cmbcontactoproyecto.Items.Add(contactoproyecto);
            }
        }
        public DataTable Llenar_gridproyecto()
        {
            DataTable dt = new DataTable();
            string consultaproyecto = "Select CodigoProyecto as 'CÓDIGO PROYECTO', ProyectoNombre as 'NOMBRE', ProyectoDescripcion as 'DESCRIPCIÓN', EstadoNombre as 'ESTADO', NombreServicio as 'SERVICIO', RangoNombre as 'RANGO', ProyectoPrecio as 'PRECIO', CodCli as 'CLIENTE', CodigoEmpleado as 'EMPLEADO', CodigoProveedor as 'PROVEEDOR' from Proyecto";
            SqlCommand cmdproyecto = new SqlCommand(consultaproyecto, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmdproyecto);

            da.Fill(dt);
            return dt;
        }

        private void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertarproyecto = "insert into Proyecto (CodigoProyecto, ProyectoNombre, ProyectoDescripcion, EstadoNombre, NombreServicio, RangoNombre, ProyectoPrecio, CodCli, CodigoEmpleado, CodigoProveedor) values (@CodigoProyecto, @ProyectoNombre, @ProyectoDescripcion, @EstadoNombre, @NombreServicio, @RangoNombre, @ProyectoPrecio, @CodCli, @CodigoEmpleado, @CodigoProveedor)";
            SqlCommand cmdproyecto1 = new SqlCommand(insertarproyecto, Conexion.Conectar());
            cmdproyecto1.Parameters.AddWithValue("@CodigoProyecto", txtcodigoproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@ProyectoNombre", txtnombreproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@ProyectoDescripcion", txtdescripcionproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@EstadoNombre", cmbestadoproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@NombreServicio", cmbservicioproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@RangoNombre", cmbrangoproyecto.Text);
            decimal precioservicio = decimal.Parse(txtcostoservicioproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@ProyectoPrecio", precioservicio);
            cmdproyecto1.Parameters.AddWithValue("@CodCli", cmbclienteproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@CodigoEmpleado", cmboperarioproyecto.Text);
            cmdproyecto1.Parameters.AddWithValue("@CodigoProveedor", cmbcontactoproyecto.Text);

            cmdproyecto1.ExecuteNonQuery();
            MessageBox.Show("Dato Agregado");
            GridViewProyecto.DataSource = Llenar_gridproyecto();
        }

        private void cmbcategoriaproyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcategoriaproyecto.SelectedItem != null)
            {
                string categoriaSeleccionada = cmbcategoriaproyecto.SelectedItem.ToString();

                cmbservicioproyecto.Items.Clear();

                string queryServicios = "SELECT NombreServicio FROM Servicio WHERE CategoriaNombre = @Categoria";
                SqlCommand cmdServicios = new SqlCommand(queryServicios, Conexion.Conectar());
                cmdServicios.Parameters.AddWithValue("@Categoria", categoriaSeleccionada);

                SqlDataReader readerServicios = cmdServicios.ExecuteReader();

                while (readerServicios.Read())
                {
                    cmbservicioproyecto.Items.Add(readerServicios["NombreServicio"].ToString());
                }
            }

        }

        private void GridViewProyecto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtcodigoproyecto.Text = GridViewProyecto.CurrentRow.Cells[0].Value.ToString();
                txtnombreproyecto.Text = GridViewProyecto.CurrentRow.Cells[1].Value.ToString();
                txtdescripcionproyecto.Text = GridViewProyecto.CurrentRow.Cells[2].Value.ToString();
                cmbestadoproyecto.Text = GridViewProyecto.CurrentRow.Cells[3].Value.ToString();
                cmbservicioproyecto.Text = GridViewProyecto.CurrentRow.Cells[4].Value.ToString();
                cmbrangoproyecto.Text = GridViewProyecto.CurrentRow.Cells[5].Value.ToString();
                txtcostoservicioproyecto.Text = GridViewProyecto.CurrentRow.Cells[6].Value.ToString();
                cmbclienteproyecto.Text = GridViewProyecto.CurrentRow.Cells[7].Value.ToString();
                cmboperarioproyecto.Text = GridViewProyecto.CurrentRow.Cells[8].Value.ToString();
                cmbcontactoproyecto.Text = GridViewProyecto.CurrentRow.Cells[9].Value.ToString();
            }
            catch { }

        }

        private void btnModificarProyecto_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizarproyecto = "Update Proyecto set ProyectoNombre = @ProyectoNombre, ProyectoDescripcion = @ProyectoDescripcion, EstadoNombre = @EstadoNombre, NombreServicio = @NombreServicio, RangoNombre = @RangoNombre, ProyectoPrecio = @ProyectoPrecio, CodCli = @CodCli, CodigoEmpleado = @CodigoEmpleado, CodigoProveedor = @CodigoProveedor WHERE CodigoProyecto= @CodigoProyecto";
            SqlCommand cmdproyecto2 = new SqlCommand(actualizarproyecto, Conexion.Conectar());
            cmdproyecto2.Parameters.AddWithValue("@CodigoProyecto", txtcodigoproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@ProyectoNombre", txtnombreproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@ProyectoDescripcion", txtdescripcionproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@EstadoNombre", cmbestadoproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@NombreServicio", cmbservicioproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@RangoNombre", cmbrangoproyecto.Text);
            decimal proyectoPrecio;
            if (decimal.TryParse(txtcostoservicioproyecto.Text, out proyectoPrecio))
            {
                cmdproyecto2.Parameters.AddWithValue("@ProyectoPrecio", proyectoPrecio);
            }
            else
            {
                MessageBox.Show("Error valor ingresado no valido");
            }


            cmdproyecto2.Parameters.AddWithValue("@CodCli", cmbclienteproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@CodigoEmpleado", cmboperarioproyecto.Text);
            cmdproyecto2.Parameters.AddWithValue("@CodigoProveedor", cmbcontactoproyecto.Text);

            cmdproyecto2.ExecuteNonQuery();
            MessageBox.Show("Dato Actualizado");

            GridViewProyecto.DataSource = Llenar_gridproyecto();
        }

        private void btnEliminarProyecto_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminarproyecto = "delete from Proyecto where CodigoProyecto = @CodigoProyecto";
            SqlCommand cmdproyecto3 = new SqlCommand(eliminarproyecto, Conexion.Conectar());
            cmdproyecto3.Parameters.AddWithValue("CodigoProyecto", txtcodigoproyecto.Text);

            cmdproyecto3.ExecuteNonQuery();

            MessageBox.Show("Dato Eliminado");

            GridViewProyecto.DataSource = Llenar_gridproyecto();
        }

        private void btnNuevoProyecto_Click(object sender, EventArgs e)
        {
            txtcodigoproyecto.Clear();
            txtnombreproyecto.Clear();
            txtdescripcionproyecto.Clear();
            cmbestadoproyecto.SelectedIndex = -1;
            cmbcategoriaproyecto.SelectedIndex = -1;
            cmbservicioproyecto.SelectedIndex = -1;
            cmbrangoproyecto.SelectedIndex = -1;
            txtcostoservicioproyecto.Clear();
            cmbclienteproyecto.SelectedIndex = -1;
            cmboperarioproyecto.SelectedIndex = -1;
            cmbcontactoproyecto.SelectedIndex = -1;
        }

        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener el panel seleccionado (puedes ajustar esto según tu implementación)
            Panel panelSeleccionado = panelproyecto;

            // Crear una imagen del contenido del panel seleccionado
            Bitmap panelBitmap = new Bitmap(panelSeleccionado.Width, panelSeleccionado.Height);
            panelSeleccionado.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panelSeleccionado.Width, panelSeleccionado.Height));

            // Dibujar la imagen en la página de impresión
            e.Graphics.DrawImage(panelBitmap, e.MarginBounds);
        }

        private void pictureboxproyecto_Click(object sender, EventArgs e)
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
    }
}
