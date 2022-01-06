using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace CapaDatos
{
    public class ClsParametros
    {
        //PARAMETROS DE LOS DATOS
        public String Nombre { get; set; }
        public Object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamaño { get; set; }
        public ParameterDirection Direccion { get; set; }

        //CONSTRUCTORES
        //CONSTRUCTOR DE ENTRADA
        public ClsParametros(String objNombre, Object objValor)
        {

            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        }

        //CONSTRUCTOR DE SALIDA
        public ClsParametros(String objNombre, SqlDbType objTipoDato, Int32 objTamaño)
        {
            Nombre = objNombre;
            TipoDato = objTipoDato;
            Tamaño = objTamaño;
            Direccion = ParameterDirection.Output;

        }
    }
}
