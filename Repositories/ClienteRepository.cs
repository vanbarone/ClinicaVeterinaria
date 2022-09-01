using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaVeterinaria.Repositories
{
    public class ClienteRepository
    {
        public Cliente GetById(int id)
        {
            Cliente entity = new Cliente();

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM CLIENTES WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity.id = (int)reader["ID"];
                            entity.nome = (string)reader["NOME"];
                            entity.cpf = (string)reader["CPF"];
                            entity.email = (reader["EMAIL"] == DBNull.Value ? "": (string)reader["EMAIL"]);
                            entity.celular = (reader["CELULAR"] == DBNull.Value ? "" : (string)reader["CELULAR"]);
                        }
                    }
                }
            }

            return entity;
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> lista = new List<Cliente>();

            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM CLIENTES";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente
                            {
                                id = (int)reader["ID"],
                                nome = (string)reader["NOME"],
                                cpf = (string)reader["CPF"],
                                email = (reader["EMAIL"] == DBNull.Value ? "" : (string)reader["EMAIL"]),
                                celular = (reader["CELULAR"] == DBNull.Value ? "" : (string)reader["CELULAR"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public int GetMaxId()
        {
            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT MAX(ID) FROM CLIENTES";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (int)reader[0];
                        }
                    }
                }
            }

            return 0;
        }

        public Cliente Insert(Cliente entity)
        {
            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "INSERT INTO CLIENTES (NOME, CPF, EMAIL, CELULAR) " +
                             "VALUES (@NOME, @CPF, @EMAIL, @CELULAR)";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("NOME", SqlDbType.NVarChar).Value = entity.nome;
                    cmd.Parameters.Add("CPF", SqlDbType.NVarChar).Value = entity.cpf;
                    cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = (entity.email == null ? DBNull.Value : entity.email); 
                    cmd.Parameters.Add("CELULAR", SqlDbType.NVarChar).Value = (entity.celular == null ? DBNull.Value : entity.celular);

                    cmd.ExecuteNonQuery();

                    entity.id = GetMaxId();
                }
            }

            return entity;
        }

        public Cliente Update(int id, Cliente entity)
        {
            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "UPDATE CLIENTES " +
                             "SET NOME = @NOME, " +
                                 "CPF = @CPF, " +
                                 "EMAIL = @EMAIL, " + 
                                 "CELULAR = @CELULAR " +
                             "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("NOME", SqlDbType.NVarChar).Value = entity.nome;
                    cmd.Parameters.Add("CPF", SqlDbType.NVarChar).Value = entity.cpf;
                    cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = (entity.email == null ? DBNull.Value : entity.email);
                    cmd.Parameters.Add("CELULAR", SqlDbType.NVarChar).Value = (entity.celular == null ? DBNull.Value : entity.celular);

                    cmd.ExecuteNonQuery();
                }
            }

            entity.id = id;

            return entity;
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "DELETE CLIENTES " +
                             "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
                    
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                }
            }

            return true;
        }

    }
}
