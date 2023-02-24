using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AsistenciaHuellaWeb.Models;

namespace AsistenciaHuellaWeb.Data
{
    public class ClsUsuarioData
    {

        ClsConexion conexion = new ClsConexion();

        public List<ClsUsuarioModel> LeerDatos()
        {
            var listUser = new List<ClsUsuarioModel>();
            string querySelect ="SELECT * FROM USUARIOS";

            SqlCommand commandSelect = new SqlCommand(querySelect, conexion.GetCadenaSql());

            var executeQuery =commandSelect.ExecuteReader();

            while (executeQuery.Read())
            {
                listUser.Add(new ClsUsuarioModel()
                {
                    Id_Usuario = Convert.ToInt32(executeQuery["Id_Usuario"]),
                    Cedula_Usuario = (string)executeQuery["Cedula_Usuario"],
                    Nombre_Usuario = (string)executeQuery["Nombre_Usuario"],
                    Apellido_Usuario = (string)executeQuery["Apellido_Usuario"],
                    Correo_Usuario = (string)executeQuery["Correo_Usuario"],
                    Password_Usuario = (string)executeQuery["Password_Usuario"],
                    Rol_Usuario = (string)executeQuery["Rol_Usuario"],
                    Estado_Usuario = (string)executeQuery["Estado_Usuario"],
                    //Photo_Usuario=(byte)executeQuery["Photo_Usuario"]
                });             
            }
            return listUser;
        }

        public List<ClsUsuarioModel> ObtenerUsuario(int Id_Usuario)
        {
            var listUser = new List<ClsUsuarioModel>();
            string querySelect = "SELECT * FROM USUARIOS WHERE Id_Usuario=@Id_Usuario";

            SqlCommand commandSelect = new SqlCommand(querySelect, conexion.GetCadenaSql());
            commandSelect.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
            var executeQuery = commandSelect.ExecuteReader();

            while (executeQuery.Read())
            {
                listUser.Add(new ClsUsuarioModel()
                {
                    Id_Usuario = Convert.ToInt32(executeQuery["Id_Usuario"]),
                    Cedula_Usuario = (string)executeQuery["Cedula_Usuario"],
                    Nombre_Usuario = (string)executeQuery["Nombre_Usuario"],
                    Apellido_Usuario = (string)executeQuery["Apellido_Usuario"],
                    Correo_Usuario = (string)executeQuery["Correo_Usuario"],
                    Password_Usuario = (string)executeQuery["Password_Usuario"],
                    Rol_Usuario = (string)executeQuery["Rol_Usuario"],
                    Estado_Usuario = (string)executeQuery["Estado_Usuario"],
                    //Photo_Usuario=(byte)executeQuery["Photo_Usuario"]
                });
            }
            return listUser;
        }


        public bool AgregarUsuario(ClsUsuarioModel usuario)
        {
            bool respuesta;

            try
            {
                string queryInsert = "INSERT INTO USUARIOS (Cedula_Usuario,Nombre_Usuario,Apellido_Usuario,Correo_Usuario,Celular_Usuario,Password_Usuario,Rol_Usuario,Estado_Usuario)VALUES(@Cedula_Usuario,@Nombre_Usuario,@Apellido_Usuario,@Correo_Usuario,@Celular_Usuario,@Password_Usuario,@Rol_Usuario,@Estado_Usuario)";
                SqlCommand commandInsert = new SqlCommand(queryInsert, conexion.GetCadenaSql());
                commandInsert.Parameters.AddWithValue("@Cedula_Usuario", usuario.Cedula_Usuario);
                commandInsert.Parameters.AddWithValue("@Nombre_Usuario", usuario.Nombre_Usuario);
                commandInsert.Parameters.AddWithValue("@Apellido_Usuario", usuario.Apellido_Usuario);
                commandInsert.Parameters.AddWithValue("@Correo_Usuario", usuario.Correo_Usuario);
                commandInsert.Parameters.AddWithValue("@Celular_Usuario", usuario.Celular_Usuario);
                commandInsert.Parameters.AddWithValue("@Password_Usuario", usuario.Password_Usuario);
                commandInsert.Parameters.AddWithValue("@Rol_Usuario", usuario.Rol_Usuario);
                commandInsert.Parameters.AddWithValue("@Estado_Usuario", usuario.Estado_Usuario);
                var queryExecute = commandInsert.ExecuteNonQuery();



                return respuesta = true;

            }
            catch (Exception e)
            {
                string messageError = e.Message;
                return respuesta = false;
            }

        }


        public bool EditarUsuario(ClsUsuarioModel usuario)
        {
            bool respuesta;
            try
            {
                string queryUpdate = "UPDATE USUARIOS SET Cedula_Usuario=@Cedula_Usuario,Nombre_Usuario=@Nombre_Usuario,Apellido_Usuario=@Apellido_Usuario,Correo_Usuario=@Correo_Usuario,Celular_Usuario=@Celular_Usuario,Password_Usuario=@Password_Usuario,Rol_Usuario=@Rol_Usuario,Estado_Usuario=@Estado_Usuario WHERE Id_Usuario=@Id_Usuario";
                SqlCommand command = new SqlCommand(queryUpdate,conexion.GetCadenaSql());
                command.Parameters.AddWithValue("Id_Usuario",usuario.Id_Usuario);
                command.Parameters.AddWithValue("@Cedula_Usuario", usuario.Cedula_Usuario);
                command.Parameters.AddWithValue("@Nombre_Usuario", usuario.Nombre_Usuario);
                command.Parameters.AddWithValue("@Apellido_Usuario", usuario.Apellido_Usuario);
                command.Parameters.AddWithValue("@Correo_Usuario", usuario.Correo_Usuario);
                command.Parameters.AddWithValue("@Celular_Usuario", usuario.Celular_Usuario);
                command.Parameters.AddWithValue("@Password_Usuario", usuario.Password_Usuario);
                command.Parameters.AddWithValue("@Rol_Usuario", usuario.Rol_Usuario);
                command.Parameters.AddWithValue("@Estado_Usuario", usuario.Estado_Usuario);
                command.ExecuteNonQuery();

                return respuesta = true;

            }
            catch(Exception e)
            {
                string messageError=e.Message;
                return respuesta = false;
            }

        }
    }
}
