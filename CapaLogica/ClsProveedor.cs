using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogica
{
    public class ClsProveedor
    {

        public String PR_nom_prov { get; set; }
        public String PR_dir_prov { get; set; }
        public String PR_telefono { get; set; }


        ClsManejador cls = new ClsManejador();

        //METODO PARA LISTAR EL PROVEDOR
        public DataTable ListarProveedor() {
            return cls.Listado("MostrarProveedor", null);
            }

        //metodo para AGREGAR PROVEDOR
        public String NuevoProveedor() {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@nom_prov", PR_nom_prov));
                lst.Add(new ClsParametros("@dir_prov", PR_dir_prov));
                lst.Add(new ClsParametros("@telefono", PR_telefono));

                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                cls.Ejecutar_SP("NuevoProveedor", lst);
            } catch (Exception ex) { throw ex; }
            return lst[3].Valor.ToString(); ;
        }

        //METODO PARA ELIMINAR PROVEDOR
        public String EliminarProveedor() {
            List<ClsParametros> lst = new List<ClsParametros>();
            try {
                lst.Add(new ClsParametros("@nom_prov", PR_nom_prov));

                lst.Add(new ClsParametros("Mensaje", SqlDbType.VarChar, 100));
                cls.Ejecutar_SP("EliminarProveedor", lst);
            } catch (Exception ex) { throw ex; }
            return lst[1].Valor.ToString() ;
        }
    }
}
