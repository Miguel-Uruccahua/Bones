using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogica
{
   public class ClsProducto
    {
        public String P_cod_pro { get; set; }
        public String P_cod_cate { get; set; }
        public String P_cod_prov { get; set; }
        public String P_nom_pro { get; set; }
        public String P_precio { get; set; }
        public String P_stock { get; set; }
        public String P_fecha_venc { get; set; }

        ClsManejador P = new ClsManejador();
        //METODO PARA BUSCAR PRODUCTO
        public DataTable BusquedaProducto(String busqueda)
        {

            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                lst.Add(new ClsParametros("@buscar", busqueda));
                return P.Listado("BuscarProducto", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //METODO PARA AGREGAR PRODUCTO
        public String NuevoProducto()
        {
            String msj = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de ENTRADA
                lst.Add(new ClsParametros("@cod_cate",Convert.ToInt32( P_cod_cate)));
                lst.Add(new ClsParametros("@cod_prov", Convert.ToInt32(P_cod_prov)));
                lst.Add(new ClsParametros("@nom_pro", P_nom_pro));
                lst.Add(new ClsParametros("@precio", Convert.ToDecimal(P_precio)));
                lst.Add(new ClsParametros("@stock", Convert.ToInt32(P_stock)));
                lst.Add(new ClsParametros("@fecha_venc",Convert.ToDateTime(P_fecha_venc).Date));


                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                P.Ejecutar_SP("NuevoProducto", lst);
                msj = lst[6].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msj;
        }
        //METODO PARA LISTAR PRODUCTO

        public DataTable ListarProducto()
        {

            return P.Listado("MostrarProducto", null);
        }

        //METODO PARA EDITAR PRODUCTO
        public String EditarProducto()
        {
            String msj = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de ENTRADA
                lst.Add(new ClsParametros("@cod_cate", Convert.ToInt32(P_cod_cate)));
                lst.Add(new ClsParametros("@cod_prov", Convert.ToInt32(P_cod_prov)));
                lst.Add(new ClsParametros("@nom_pro", P_nom_pro));
                lst.Add(new ClsParametros("@precio", Convert.ToDecimal(P_precio)));
                lst.Add(new ClsParametros("@stock", Convert.ToInt32(P_stock)));
                lst.Add(new ClsParametros("@fecha_venc", Convert.ToDateTime(P_fecha_venc).Date));


                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                P.Ejecutar_SP("EditarProducto", lst);
                msj = lst[6].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msj;
        }

        //METODO PARA ELIMINAR PRODUCTO
        public String EliminarProducto()
        {
            String msj = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de SALIDA.
                lst.Add(new ClsParametros("@nom_pro", P_nom_pro));
                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                P.Ejecutar_SP("EliminarProducto", lst);
                msj = lst[1].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msj;
        }
    }
}
