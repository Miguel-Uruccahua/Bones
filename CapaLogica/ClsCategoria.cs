using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogica
{
    public class ClsCategoria
    {
        public String C_nom_cate { set; get; }

        ClsManejador C = new ClsManejador();


        

        //METODO PARA AGREGAR CATEGORIAS
        public String NuevaCategoria() {
            //CREAMOS UN OBJETO LISTA DE PARAMETROS PARA USARLOS EN EL PROCEDIMIENTO ALMACENADO
            List<ClsParametros> lst = new List<ClsParametros>();
            //USAMOS UN MANEJADOR DE ERRORES
            try {
                //parametro de entrada 
                lst.Add(new ClsParametros("@nom_cate", C_nom_cate));

                //parametro de salida
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                //EJECUTAMOS NUESTRO PROCEDIMIENTO ALMACENADO
                C.Ejecutar_SP("NuevoCategoria",lst);

                //CAPTURAMOS EL ERROR
            } catch (Exception ex) {
                //RETORNAMOS EL ERROR 
                throw ex;
            }
            //RETORNAMOS EL MENSAJE DE SALIDA
            return lst[1].Valor.ToString();
        }

        //METODO PARA ELIMINAR CATEGORIA
        public string EliminarCategoria() {
            List<ClsParametros> lst = new List<ClsParametros>();
            try {
                //PASAMOS LOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@nom_cate", C_nom_cate));
                //PASAMOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("Mensaje", SqlDbType.VarChar, 100));
                C.Ejecutar_SP("EliminarCategoria", lst);
            } catch (Exception ex) { throw ex; }

            return lst[1].Valor.ToString();
        }

        //METODO PARA LISTAR CATEGORIA

        public DataTable ListarCategoria() {
            return C.Listado("MostrarCategoria", null);
        }
    }
}
