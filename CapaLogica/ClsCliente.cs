using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
    public class ClsCliente
    {
        public String C_cod_cli { get; set; }
        public String C_nom_cli { get; set; }
        public String C_direc_cli { get; set; }
        public String C_sexo { get; set; }
        public String C_DNI { get; set; }
        public String C_telefono { get; set; }

        ClsManejador C = new ClsManejador();

        //METODO PARA LISTAR CLIENTE

        public DataTable ListadoClientes()
        {

            return C.Listado("MostrarClientes", null);
        }

        //METODO PARA BUSCAR CLIENTES
        public DataTable BusquedaClientes(String busqueda)
        {
            
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@buscar", busqueda));
                return C.Listado("BuscarCliente", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO PARA BUSCAR CLIENTES POR NOMBREY OBTENER SU CODIGO
        public DataTable ClienteCodigo(String busqueda)
        {

            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@Buscar", busqueda));
                return C.Listado("NombreCliente", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BusquedaDNI(String busqueda)
        {

            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@buscar", busqueda));
                return C.Listado("BuscarDNI", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO PARA AGREGAR CLIENTES
        public String NuevoCliente()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de ENTRADA
                lst.Add(new ClsParametros("@nom_cli", C_nom_cli));
                lst.Add(new ClsParametros("@dir_cli", C_direc_cli));
                lst.Add(new ClsParametros("@sexo",Convert.ToChar( C_sexo)));
                lst.Add(new ClsParametros("@DNI",Convert.ToInt32(C_DNI)));
                lst.Add(new ClsParametros("@telefono", C_telefono));

                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                C.Ejecutar_SP("NuevoCliente", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst[5].Valor.ToString();
        }

        //METODO PARA ELIMINAR CLIENTES
        public String EliminarCliente()
        {
            String msj = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de SALIDA.
                lst.Add(new ClsParametros("@DNI", Convert.ToInt32(C_DNI)));
                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                C.Ejecutar_SP("EliminarCliente", lst);
                msj = lst[1].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msj;
        }

        //METODO PARA EDITAR CLIENTES
        public String EditarCliente()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de SALIDA.
                lst.Add(new ClsParametros("@nom_cli", C_nom_cli));
                lst.Add(new ClsParametros("@dir_cli", C_direc_cli));
                lst.Add(new ClsParametros("@sexo",Convert.ToChar( C_sexo)));
                lst.Add(new ClsParametros("@DNI", Convert.ToInt32(C_DNI)));
                lst.Add(new ClsParametros("@telefono", C_telefono));


                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                C.Ejecutar_SP("EditarCliente", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst[5].Valor.ToString();
        }
    }
}
