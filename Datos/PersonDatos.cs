using CRUDPractica.Models;
using MySql.Data.MySqlClient;
using System.Data;
namespace CRUDPractica.Datos
{
    public class PersonDatos
    {
        public List<PersonModel> Listar()
        {
            var oLista = new List<PersonModel>();
            var cn = new Conexion();
            using (var conexion = new MySqlConnection(cn.getCadenaMySql()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_person",conexion);
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@first_name", null);
                cmd.Parameters.AddWithValue("@last_name", null);
                cmd.Parameters.AddWithValue("@birth_date", null);
                cmd.Parameters.AddWithValue("@gender", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@edit_date", null);
                cmd.Parameters.AddWithValue("@option_control", 1);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PersonModel()
                        {
                            id = Convert.ToInt32(dr["id"].ToString()),
                            first_name = dr["first_name"].ToString(),
                            last_name = dr["last_name"].ToString(),
                            gender = Convert.ToInt32(dr["gender"]),
                            status = Convert.ToInt32(dr["status"].ToString()),
                            create_date = dr["create_date"].ToString(),
                            edit_date = dr["edit_date"].ToString()
                        }) ;
                    }
                }
            }

            return oLista;
        }


        public PersonModel Obtener(int persona)
        {
            var oPersona = new PersonModel();
            var cn = new Conexion();
            using (var conexion = new MySqlConnection(cn.getCadenaMySql()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_person", conexion);
                cmd.Parameters.AddWithValue("@id", persona);
                cmd.Parameters.AddWithValue("@first_name", null);
                cmd.Parameters.AddWithValue("@last_name", null);
                cmd.Parameters.AddWithValue("@birth_date", null);
                cmd.Parameters.AddWithValue("@gender", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@edit_date", null);
                cmd.Parameters.AddWithValue("@option_control", 3);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {


                    dr.Read();
                    oPersona.id = int.Parse(dr["id"].ToString());
                    oPersona.first_name = dr["first_name"].ToString();
                    oPersona.last_name = dr["last_name"].ToString();
                    oPersona.gender = Convert.ToInt32(dr["gender"]);
                    oPersona.status = Convert.ToInt32(dr["status"].ToString());
                    oPersona.create_date = dr["create_date"].ToString();
                    oPersona.edit_date = dr["edit_date"].ToString();
                       
                
                }
            }

            return oPersona;
        }


        public bool Guardar(PersonModel persona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new MySqlConnection(cn.getCadenaMySql()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_person", conexion);
                    cmd.Parameters.AddWithValue("@id", null);
                    cmd.Parameters.AddWithValue("@first_name", persona.first_name);
                    cmd.Parameters.AddWithValue("@last_name", persona.last_name);
                    cmd.Parameters.AddWithValue("@birth_date", null);
                    cmd.Parameters.AddWithValue("@gender", persona.gender);
                    cmd.Parameters.AddWithValue("@status", null);
                    cmd.Parameters.AddWithValue("@edit_date", null);
                    cmd.Parameters.AddWithValue("@option_control", 2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta=false;
                throw;
            }
            return rpta;
        }


        public bool Editar(PersonModel persona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new MySqlConnection(cn.getCadenaMySql()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_person", conexion);
                    cmd.Parameters.AddWithValue("@id", persona.id);
                    cmd.Parameters.AddWithValue("@first_name", persona.first_name);
                    cmd.Parameters.AddWithValue("@last_name", persona.last_name);
                    cmd.Parameters.AddWithValue("@birth_date", persona.birth_date);
                    cmd.Parameters.AddWithValue("@gender", persona.gender);
                    cmd.Parameters.AddWithValue("@status", null);
                    cmd.Parameters.AddWithValue("@edit_date", null);
                    cmd.Parameters.AddWithValue("@option_control", 4);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
                throw;
            }
            return rpta;
        }


        public bool Eliminar(int persona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new MySqlConnection(cn.getCadenaMySql()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_person", conexion);
                    cmd.Parameters.AddWithValue("@id", persona);
                    cmd.Parameters.AddWithValue("@first_name", null);
                    cmd.Parameters.AddWithValue("@last_name", null);
                    cmd.Parameters.AddWithValue("@birth_date", null);
                    cmd.Parameters.AddWithValue("@gender", null);
                    cmd.Parameters.AddWithValue("@status", null);
                    cmd.Parameters.AddWithValue("@edit_date", null);
                    cmd.Parameters.AddWithValue("@option_control", 5);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
                throw;
            }
            return rpta;
        }
    }
}
