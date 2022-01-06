using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaLogica
{
    public class Detalles
    {
        public String D_cod_pedido { set; get; }
        public String D_cod_pro { set; get; }
        public String D_cantidad { set; get; }
        public String D_precio_unitario { set; get; }
        public String D_importe { set; get; }

        ClsManejador D = new ClsManejador();

        //FUNCION´PARA NUEVO DETALLE
        public String NuevoDetalle()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de ENTRADA
                lst.Add(new ClsParametros("@cod_pedido",Convert.ToInt32(D_cod_pedido)));
                lst.Add(new ClsParametros("@cod_pro",Convert.ToInt32(D_cod_pro)));
                lst.Add(new ClsParametros("@cantidad",Convert.ToInt32( D_cantidad)));
                lst.Add(new ClsParametros("@precio_unitario",Convert.ToDecimal( D_precio_unitario)));
                lst.Add(new ClsParametros("@importe",Convert.ToDecimal( D_importe)));

                //pasamos los parametros de SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));
                D.Ejecutar_SP("NuevoDetalle", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst[5].Valor.ToString();
        }
    }
}
