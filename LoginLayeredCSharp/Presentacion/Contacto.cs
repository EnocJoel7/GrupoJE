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
    public partial class Contacto : Form
    {
        public Contacto()
        {
            InitializeComponent();
        }
        private void Contacto_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            GridViewContacto.DataSource = Llenar_gridcontacto();
            GridViewMaterial.DataSource = Llenar_gridmaterial();

            string consultacontactosregistrados = "Select CodigoProveedor from Proveedor";
            SqlCommand cmdconsultacontactosregistrados = new SqlCommand(consultacontactosregistrados, Conexion.Conectar());
            SqlDataReader reader = cmdconsultacontactosregistrados.ExecuteReader();
            comboboxproveedormaterial.Items.Clear();
            while (reader.Read())
            {
                string CodigoProveedor = reader["CodigoProveedor"].ToString();
                string Proveedor = CodigoProveedor;
                comboboxproveedormaterial.Items.Add(Proveedor);
            }


            
        }
        public DataTable Llenar_gridcontacto() //Comando de consulta en la BD, y que se pueda visualizar en el gridcontacto
        {
            DataTable dt = new DataTable();
            string consultacontacto = "select CodigoProveedor as 'CODIGO', ProveedorRUC as 'RUC', ProveedorNombre as 'NOMBRE', ProveedorApellido as 'APELLIDO', ProveedorDireccion as 'DIRECCIÓN', ProveedorTelefono as 'TELÉFONO', ProveedorEmail as 'E-MAIL' from Proveedor ";
            SqlCommand cmdcontacto = new SqlCommand(consultacontacto, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmdcontacto);

            da.Fill(dt);
            return dt;
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e) //Boton agregar contacto
        {
            Conexion.Conectar();
            string insertarcontacto = ("insert into Proveedor (CodigoProveedor, ProveedorRUC, ProveedorNombre, ProveedorApellido, ProveedorDireccion, ProveedorTelefono, ProveedorEmail)values(@CodigoProveedor, @ProveedorRUC, @ProveedorNombre, @ProveedorApellido, @ProveedorDireccion, @ProveedorTelefono, @ProveedorEmail)");
            SqlCommand cmdcontacto1 = new SqlCommand(insertarcontacto, Conexion.Conectar());
            cmdcontacto1.Parameters.AddWithValue("@CodigoProveedor", txtcodigocontacto.Text);
            cmdcontacto1.Parameters.AddWithValue("@ProveedorRUC", txtruccontacto.Text);
            cmdcontacto1.Parameters.AddWithValue("@ProveedorNombre", txtnombrecontacto.Text);
            cmdcontacto1.Parameters.AddWithValue("@ProveedorApellido", txtapellidocontacto.Text);
            cmdcontacto1.Parameters.AddWithValue("@ProveedorDireccion", txtdireccioncontacto.Text);
            cmdcontacto1.Parameters.AddWithValue("@ProveedorTelefono", txttelefonocontacto.Text);
            cmdcontacto1.Parameters.AddWithValue("@ProveedorEmail", txtemailcontacto.Text);

            cmdcontacto1.ExecuteNonQuery();
            MessageBox.Show("Dato Agregado");

            GridViewContacto.DataSource = Llenar_gridcontacto();
        }

        private void GridViewContacto_CellContentClick(object sender, DataGridViewCellEventArgs e) //Al momento de seleccionar, se agreguen en los textbox lo campos del grid.
        {
            try
            {
                txtcodigocontacto.Text = GridViewContacto.CurrentRow.Cells[0].Value.ToString();
                txtruccontacto.Text = GridViewContacto.CurrentRow.Cells[1].Value.ToString();
                txtnombrecontacto.Text = GridViewContacto.CurrentRow.Cells[2].Value.ToString();
                txtapellidocontacto.Text = GridViewContacto.CurrentRow.Cells[3].Value.ToString();
                txtdireccioncontacto.Text = GridViewContacto.CurrentRow.Cells[4].Value.ToString();
                txttelefonocontacto.Text = GridViewContacto.CurrentRow.Cells[5].Value.ToString();
                txtemailcontacto.Text = GridViewContacto.CurrentRow.Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btnModificarContacto_Click(object sender, EventArgs e) //Boton Actualizar contacto
        {
            Conexion.Conectar();
            string actualizarcontacto = "Update Proveedor set ProveedorRUC = @ProveedorRUC, ProveedorNombre= @ProveedorNombre, ProveedorApellido = @ProveedorApellido, ProveedorDireccion= @ProveedorDireccion, ProveedorTelefono= @ProveedorTelefono, ProveedorEmail = @ProveedorEmail WHERE CodigoProveedor = @CodigoProveedor";
            SqlCommand cmdcontacto2 = new SqlCommand(actualizarcontacto, Conexion.Conectar());
            cmdcontacto2.Parameters.AddWithValue("@CodigoProveedor", txtcodigocontacto.Text);
            cmdcontacto2.Parameters.AddWithValue("@ProveedorRUC", txtruccontacto.Text);
            cmdcontacto2.Parameters.AddWithValue("@ProveedorNombre", txtnombrecontacto.Text);
            cmdcontacto2.Parameters.AddWithValue("@ProveedorApellido", txtapellidocontacto.Text);
            cmdcontacto2.Parameters.AddWithValue("@ProveedorDireccion", txtdireccioncontacto.Text);
            cmdcontacto2.Parameters.AddWithValue("@ProveedorTelefono", txttelefonocontacto.Text);
            cmdcontacto2.Parameters.AddWithValue("@ProveedorEmail", txtemailcontacto.Text);

            cmdcontacto2.ExecuteNonQuery();

            MessageBox.Show("Dato actualizado");

            GridViewContacto.DataSource = Llenar_gridcontacto();
        }

        private void btnEliminarContacto_Click(object sender, EventArgs e) //Boton Eliminar Contacto
        {
            Conexion.Conectar();
            string eliminarcontacto = "delete from Proveedor where CodigoProveedor = @CodigoProveedor";
            SqlCommand cmdcontacto3 = new SqlCommand(eliminarcontacto, Conexion.Conectar());
            cmdcontacto3.Parameters.AddWithValue("CodigoProveedor", txtcodigocontacto.Text);

            cmdcontacto3.ExecuteNonQuery();

            MessageBox.Show("Dato eliminado");

            GridViewContacto.DataSource = Llenar_gridcontacto();
        }

        private void txtNuevoContacto_Click(object sender, EventArgs e)
        {
            txtcodigocontacto.Clear();
            txtruccontacto.Clear();
            txtnombrecontacto.Clear();
            txtapellidocontacto.Clear();
            txtdireccioncontacto.Clear();
            txttelefonocontacto.Clear();
            txtemailcontacto.Clear();
            txtcodigocontacto.Focus();
        }


        public DataTable Llenar_gridmaterial()
        {
            DataTable dtmaterial = new DataTable();
            string consultamaterial = "Select Material.CodigoMaterial AS 'CODIGO MATERIAL', Proveedor.ProveedorNombre AS 'CONTACTO', Material.MaterialNombre AS 'NOMBRE', Material.MaterialPrecio AS 'PRECIO', Material.MaterialCantidad AS 'CANTIDAD', TOTAL = MaterialPrecio * MaterialCantidad FROM Material INNER JOIN Proveedor ON Material.CodigoProveedor = Proveedor.CodigoProveedor";
            SqlCommand cmdmaterial = new SqlCommand(consultamaterial, Conexion.Conectar());

            SqlDataAdapter de = new SqlDataAdapter(cmdmaterial);

            de.Fill(dtmaterial);
            return dtmaterial;
        }

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertarmaterial = "insert into Material (CodigoMaterial, CodigoProveedor, MaterialNombre, MaterialPrecio, MaterialCantidad) values (@CodigoMaterial, @CodigoProveedor, @MaterialNombre, @MaterialPrecio, @MaterialCantidad)";
            SqlCommand cmdmaterial1 = new SqlCommand(insertarmaterial, Conexion.Conectar());
            cmdmaterial1.Parameters.AddWithValue("@CodigoMaterial", txtcodigomaterial.Text);
            cmdmaterial1.Parameters.AddWithValue("@CodigoProveedor", comboboxproveedormaterial.Text);
            cmdmaterial1.Parameters.AddWithValue("@MaterialNombre", txtnombrematerial.Text);
            decimal precioMaterial = decimal.Parse(txtpreciomaterial.Text);
            cmdmaterial1.Parameters.AddWithValue("@MaterialPrecio", precioMaterial);
            int cantidadMaterial = int.Parse(txtcantidadmaterial.Text);
            cmdmaterial1.Parameters.AddWithValue("@MaterialCantidad", cantidadMaterial);

            cmdmaterial1.ExecuteNonQuery();
            MessageBox.Show("Dato Agregado");
            GridViewMaterial.DataSource = Llenar_gridmaterial();
        }

        private void GridViewMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtcodigomaterial.Text = GridViewMaterial.CurrentRow.Cells[0].Value.ToString();
                comboboxproveedormaterial.Text = GridViewMaterial.CurrentRow.Cells[1].Value.ToString();
                txtnombrematerial.Text = GridViewMaterial.CurrentRow.Cells[2].Value.ToString();
                txtpreciomaterial.Text = GridViewMaterial.CurrentRow.Cells[3].Value.ToString();
                txtcantidadmaterial.Text = GridViewMaterial.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnModificarMaterial_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizarmaterial = "Update Material set CodigoProveedor= @CodigoProveedor, MaterialNombre= @MaterialNombre, MaterialPrecio= @MaterialPrecio, MaterialCantidad= @MaterialCantidad WHERE CodigoMaterial = @CodigoMaterial";
            SqlCommand cmdmaterial2 = new SqlCommand(actualizarmaterial, Conexion.Conectar());
            cmdmaterial2.Parameters.AddWithValue("@CodigoMaterial", txtcodigomaterial.Text);
            cmdmaterial2.Parameters.AddWithValue("@CodigoProveedor", comboboxproveedormaterial.Text);
            cmdmaterial2.Parameters.AddWithValue("@MaterialNombre", txtnombrematerial.Text);
            cmdmaterial2.Parameters.AddWithValue("@MaterialPrecio", txtpreciomaterial.Text);
            cmdmaterial2.Parameters.AddWithValue("@MaterialCantidad", txtcantidadmaterial.Text);

            cmdmaterial2.ExecuteNonQuery();

            MessageBox.Show("Dato Actualizado");

            GridViewMaterial.DataSource = Llenar_gridmaterial();
        }

        private void btnEliminarMaterial_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminarmaterial = "delete from Material where CodigoMaterial = @CodigoMaterial";
            SqlCommand cmdmaterial3 = new SqlCommand(eliminarmaterial, Conexion.Conectar());
            cmdmaterial3.Parameters.AddWithValue("CodigoMaterial", txtcodigomaterial.Text);

            cmdmaterial3.ExecuteNonQuery();

            MessageBox.Show("Dato Eliminado");

            GridViewMaterial.DataSource = Llenar_gridmaterial();
        }

        private void btnNuevoMaterial_Click(object sender, EventArgs e)
        {
            txtcodigomaterial.Clear();
            txtnombrematerial.Clear();
            txtpreciomaterial.Clear();
            txtcantidadmaterial.Clear();
            txtcodigomaterial.Focus();
        }
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener el panel seleccionado (puedes ajustar esto según tu implementación)
            Panel panelSeleccionado = panelcontacto;

            // Crear una imagen del contenido del panel seleccionado
            Bitmap panelBitmap = new Bitmap(panelSeleccionado.Width, panelSeleccionado.Height);
            panelSeleccionado.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panelSeleccionado.Width, panelSeleccionado.Height));

            // Dibujar la imagen en la página de impresión
            e.Graphics.DrawImage(panelBitmap, e.MarginBounds);
        }
        private void pictureboxContacto_Click(object sender, EventArgs e)
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true; // Establecer la orientación horizontal

            // Configurar el PrintPreviewDialog
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Mostrar el PrintPreviewDialog
            printPreviewDialog.ShowDialog();
        }
        private void PrintDocumentMaterial_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener la imagen del PictureBox del empleado (puedes ajustar esto según tu implementación)
            Panel panelseleccionmaterial = panelmaterial;
            Bitmap panelbitmapmaterial = new Bitmap(panelseleccionmaterial.Width, panelseleccionmaterial.Height);
            panelseleccionmaterial.DrawToBitmap(panelbitmapmaterial, new Rectangle(0, 0, panelseleccionmaterial.Width, panelseleccionmaterial.Height));
            e.Graphics.DrawImage(panelbitmapmaterial, e.MarginBounds);
        }

        private void pictureboxmaterial_Click(object sender, EventArgs e)
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocumentMaterial_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true; // Establecer la orientación horizontal

            // Configurar el PrintPreviewDialog
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Mostrar el PrintPreviewDialog
            printPreviewDialog.ShowDialog();
        }
    }
    
}