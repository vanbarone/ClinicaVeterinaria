using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaVeterinaria.Repositories
{
    public class VeterinarioRepository
    {
        public Veterinario GetById(int id)
        {
            Veterinario entity = new Veterinario();

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM VETERINARIOS WHERE ID = @ID";

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
                            entity.email = (string)reader["EMAIL"];
                            entity.celular = (string)reader["CELULAR"];
                            entity.crv = (string)reader["CRV"];
                        }
                    }
                }
            }

            return entity;
        }

        public List<Veterinario> GetAll()
        {
            List<Veterinario> lista = new List<Veterinario>();

            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM VETERINARIOS";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Veterinario
                            {
                                id = (int)reader["ID"],
                                nome = (string)reader["NOME"],
                                cpf = (string)reader["CPF"],
                                email = (string)reader["EMAIL"],
                                celular = (string)reader?["CELULAR"],
                                crv = (string)reader["CRV"]
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Veterinario Insert(Veterinario entity)
        {
            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "INSERT INTO VETERINARIOS (NOME, CPF, EMAIL, CELULAR, CRV) " +
                             "VALUES (@NOME, @CPF, @EMAIL, @CELULAR, @CRV)";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("NOME", SqlDbType.NVarChar).Value = entity.nome;
                    cmd.Parameters.Add("CPF", SqlDbType.NVarChar).Value = entity.cpf;
                    cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = (entity.email == null ? DBNull.Value : entity.email);
                    cmd.Parameters.Add("CELULAR", SqlDbType.NVarChar).Value = (entity.celular == null ? DBNull.Value : entity.celular);
                    cmd.Parameters.Add("CRV", SqlDbType.NVarChar).Value = entity.crv;

                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public Veterinario Update(int id, Veterinario entity)
        {
            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "UPDATE VETERINARIOS " +
                             "SET NOME = @NOME, " +
                                 "CPF = @CPF, " +
                                 "EMAIL = @EMAIL, " + 
                                 "CELULAR = @CELULAR, " +
                                 "CRV = @CRV " +
                             "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.NVarChar).Value = id;
                    cmd.Parameters.Add("NOME", SqlDbType.NVarChar).Value = entity.nome;
                    cmd.Parameters.Add("CPF", SqlDbType.NVarChar).Value = entity.cpf;
                    cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = (entity.email == null ? DBNull.Value : entity.email); ;
                    cmd.Parameters.Add("CELULAR", SqlDbType.NVarChar).Value = (entity.celular == null ? DBNull.Value : entity.celular); ;
                    cmd.Parameters.Add("CRV", SqlDbType.NVarChar).Value = entity.crv;

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

                string sql = "DELETE VETERINARIOS " +
                             "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.NVarChar).Value = id;
                    
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                }
            }

            return true;
        }

    }
}
