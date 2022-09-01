using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace ClinicaVeterinaria.Repositories
{
    public class TipoAnimalRepository
    {
        public TipoAnimal GetById(int id)
        {
            TipoAnimal entity = new TipoAnimal();

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM TIPOANIMAIS WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity.id = (int)reader["ID"];
                            entity.tipo = (string)reader["TIPO"];
                            entity.imagem = (reader["IMAGEM"] == DBNull.Value ? "" : (string)reader["IMAGEM"]);
                        }
                    }
                }
            }

            return entity;
        }

        public List<TipoAnimal> GetAll()
        {
            List<TipoAnimal> lista = new List<TipoAnimal>();

            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM TIPOANIMAIS";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TipoAnimal { 
                                        id = (int)reader["ID"],
                                        tipo = (string)reader["TIPO"],
                                        imagem = (reader["IMAGEM"] == DBNull.Value ? "": (string)reader["IMAGEM"])
                        }) ;
                        }
                    }
                }
            }

            return lista;

        }

        public TipoAnimal Insert([FromForm] TipoAnimal entity)
        {
            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "INSERT INTO TIPOANIMAIS (TIPO, IMAGEM) VALUES (@TIPO, @IMAGEM)";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("TIPO", SqlDbType.NVarChar).Value = entity.tipo;
                    cmd.Parameters.Add("IMAGEM", SqlDbType.NVarChar).Value = entity.imagem;

                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public TipoAnimal Update(int id, TipoAnimal entity)
        {
            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "UPDATE TIPOANIMAIS " +
                                "SET TIPO = @TIPO, " +
                                    "IMAGEM = @IMAGEM " +
                                "WHERE ID = @ID";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("TIPO", SqlDbType.NVarChar).Value = entity.tipo;
                    cmd.Parameters.Add("IMAGEM", SqlDbType.NVarChar).Value = entity.imagem;

                    cmd.ExecuteNonQuery();
                }
            }

            entity.id = id;

            return entity;
        }

        public bool Delete(int id)
        {
            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "DELETE TIPOANIMAIS " +
                             "WHERE ID = @ID";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
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
