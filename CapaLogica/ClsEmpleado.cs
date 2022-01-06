using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaLogica
{
    public class ClsEmpleado
    {
        public String C_nom_emp { get; set; }
        public String C_direc_emp { get; set; }
        public String C_celular { get; set; }

        ClsManejador E = new ClsManejador();

        public DataTable BusquedaEmpleado(String busqueda)
        {

            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@buscar", busqueda));
                return E.Listado("BuscarEmpleado", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CLASE PARA AGREGAR EMPLEADOS
        public DataTable ListarEmpleado()
        {
            return E.Listado("MostrarEmpleado", null);
        }

        //metodo para AGREGAR Empleado
        public String NuevoEmpleado()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@nom_emp", C_nom_emp));
                lst.Add(new ClsParametros("@direc_emp", C_direc_emp));
                lst.Add(new ClsParametros("@celular", Convert.ToInt32(C_celular)));

                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                E.Ejecutar_SP("NuevoEmpleado", lst);
            }
            catch (Exception ex) { throw ex; }
            return lst[3].Valor.ToString(); ;
        }

        //metodo para Editar Empleado
        public String EditarEmpleado()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@nom_emp", C_nom_emp));
                lst.Add(new ClsParametros("@direc_emp", C_direc_emp));
                lst.Add(new ClsParametros("@celular", Convert.ToInt32(C_celular)));

                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                E.Ejecutar_SP("EditarEmpleado", lst);
            }
            catch (Exception ex) { throw ex; }
            return lst[3].Valor.ToString(); ;
        }

        //METODO PARA ELIMINAR EMpleado
        public String EliminarEmpleado()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@nom_emp", C_nom_emp));

                lst.Add(new ClsParametros("Mensaje", SqlDbType.VarChar, 100));
                E.Ejecutar_SP("EliminarEmpleado", lst);
            }
            catch (Exception ex) { throw ex; }
            return lst[1].Valor.ToString();
        }

    }
}
