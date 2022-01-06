using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClsManejador
    {
        //crear un objeto conexion con la  base de datos
        SqlConnection conexion = new SqlConnection("Server= DESKTOP-Q9NR13E\\SQLEXPRESS;Database =FarmaciaFinal;Integrated Security = True");

        //METODO PARA ABRIR CONEXION
        public void Abrir_Conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        //MEOTODO PARA CERRAR CONEXION
        public void Cerrar_Conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }

        //METODO PARA CONSULTAS TIPO SELECT
        public DataTable Listado(String NombreSP, List<ClsParametros> lst)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da;

            try
            {
                da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }

                }
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        
        //METODO PARA CONSULTAS TIPO INSERT, UPDATE Y DELETE
        public void Ejecutar_SP(String NombreSP, List<ClsParametros> lst)
        {
            SqlCommand cmd;
            try
            {
                Abrir_Conexion();
                cmd = new SqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                        }
                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamaño).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            lst[i].Valor = cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Cerrar_Conexion();

        }
    }
}
