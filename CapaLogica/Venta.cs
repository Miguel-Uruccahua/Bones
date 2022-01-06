using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaLogica
{
    public class Venta
    {
        public String V_cod_emp { get; set; }
        public String V_cod_cli { get; set; }
        public String V_fecha   { get; set; }
        public String V_tipo_comprovante { get; set; }
        public String V_total { get; set; }

        ClsManejador V = new ClsManejador();

        //funcion para INGRESAR NUEVA VENTA
        public String NuevaVenta()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de ENTRADA
                lst.Add(new ClsParametros("@cod_emp",Convert.ToInt32( V_cod_emp)));
                lst.Add(new ClsParametros("@cod_cli",Convert.ToInt32( V_cod_cli)));
                lst.Add(new ClsParametros("@fecha", Convert.ToDateTime(V_fecha).Date));
                lst.Add(new ClsParametros("@tipo_comprovante", V_tipo_comprovante));
                lst.Add(new ClsParametros("@total",Convert.ToDecimal( V_total)));

                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                V.Ejecutar_SP("NuevaVenta", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst[5].Valor.ToString();
        }

        //ultima venta 
        public DataTable UltimaVenta()
        {

            return V.Listado("UltimaVenta", null);
        }
        public DataTable ListadoPedido() {
            return V.Listado("ListadoPedido", null);
        }

    }
}
