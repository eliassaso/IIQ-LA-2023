using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using WebApplication4NetFrame.Models.DTO;

namespace WebApplication4NetFrame.Models.DAO
{
    public class UserDAO
    {
        public string InsertUser(UserDTO user)
        {
            string response = "Failed";
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Users (name, email) VALUES (@name, @email)";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", user.Name);
                        command.Parameters.AddWithValue("@email", user.Email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            response = "Success";
                            Console.WriteLine("Registro insertado correctamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al insertar el registro: " + ex.Message);
            }
            return response;
        }

        public List<UserDTO> ReadUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Users";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDTO user = new UserDTO();
                                user.Id = reader.GetInt32("id");
                                user.Name = reader.GetString("name");
                                user.Email = reader.GetString("email");
                                users.Add(user);
                                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al leer los registros: " + ex.Message);
            }
            return users;
        }

        public void UpdateUser(UserDTO user)
        {
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string updateQuery = "UPDATE Users SET email = @email WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.Parameters.AddWithValue("@email", user.Email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Registro actualizado correctamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al actualizar el registro: " + ex.Message);
            }
        }

    }
}





    