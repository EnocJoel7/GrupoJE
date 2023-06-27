using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Presentacion
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Server=JOSE\\SQLEXPRESS;Database = BDGrupoJE; integrated security= true");
            cn.Open();
            return cn;
        }
    }
}
