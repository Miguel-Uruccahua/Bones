using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaLogica
{
    public class ClsUsuario
    {
        public String U_cod_emp { get; set; }
        public String U_nivel_usu { get; set; }
        public String U_id_usu { get; set; }
        public String U_pass     { get; set; }
        public String U_estado { get; set; }

        ClsManejador cls = new ClsManejador();

        //METODO PARA LISTAR USUARIOS EN UNA TABLA
        public DataTable ListarUsuario()
        {
            return cls.Listado("MostrarUsuario", null);
        }
        //Metodo para listar Empleados
        public DataTable ListarEmpleado() {
            return cls.Listado("MostrarEmpleado", null);
        }

        //metodo para AGREGAR Usuario
        public String NuevoUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@cod_emp",Convert.ToInt32( U_cod_emp)));
                lst.Add(new ClsParametros("@nivel_usu", U_nivel_usu));
                lst.Add(new ClsParametros("@id_usu", U_id_usu));
                lst.Add(new ClsParametros("@pass", U_pass));
                lst.Add(new ClsParametros("@estado", U_estado));

                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                cls.Ejecutar_SP("NuevoUsuario", lst);
            }
            catch (Exception ex) { throw ex; }
            return lst[5].Valor.ToString(); ;
        }

        //METODO PARA ELIMINAR Usuario
        public String EliminarUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@id_usu", U_id_usu));

                lst.Add(new ClsParametros("Mensaje", SqlDbType.VarChar, 100));
                cls.Ejecutar_SP("EliminarUsuario", lst);
            }
            catch (Exception ex) { throw ex; }
            return lst[1].Valor.ToString();
        }

        public String ValidarUsuario() {

            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@id_usu", U_id_usu));
                lst.Add(new ClsParametros("@pass", U_pass));

                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                cls.Ejecutar_SP("ValidarUsuario", lst);
            }
            catch (Exception ex) { throw ex; }
            return lst[2].Valor.ToString();
        }

        public DataTable CapturarUsuario() {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@id_usu", U_id_usu));
                lst.Add(new ClsParametros("@pass", U_pass));
            }
            catch (Exception ex) { throw ex; }
            return cls.Listado("CapturarUsuario", lst);
        }

    }
}
