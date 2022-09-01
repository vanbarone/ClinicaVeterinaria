using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace ClinicaVeterinaria.Repositories
{
    public class ConsultaRepository
    {
        public Consulta GetById(int id)
        {
            Consulta entity = new Consulta();

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM CONSULTAS WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity.id = (int)reader["ID"];
                            entity.data = (DateTime)reader["DTCONSULTA"];
                            entity.peso = (reader["PESO"] == DBNull.Value ? 0 : (double)reader["PESO"]);
                            entity.sintomas = (reader["SINTOMAS"] == DBNull.Value ? "" : (string)reader["SINTOMAS"]);
                            entity.diagnostico = (reader["DIAGNOSTICO"] == DBNull.Value ? "" : (string)reader["DIAGNOSTICO"]);
                            entity.valor = (reader["VALOR"] == DBNull.Value ? 0 : (decimal)reader["VALOR"]);
                            entity.animalId = (int)reader["IDANIMAL"];
                            entity.veterinarioId = (int)reader["IDVETERINARIO"];
                        }
                    }
                }
            }

            return entity;
        }

        public List<Consulta> GetAll()
        {
            List<Consulta> lista = new List<Consulta>();

            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM CONSULTAS";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Consulta
                            {
                                id = (int)reader["ID"],
                                data = (DateTime)reader["DTCONSULTA"],
                                peso = (reader["PESO"] == DBNull.Value ? 0 : (double)reader["PESO"]),
                                sintomas = (reader["SINTOMAS"] == DBNull.Value ? "" : (string)reader["SINTOMAS"]),
                                diagnostico = (reader["DIAGNOSTICO"] == DBNull.Value ? "" : (string)reader["DIAGNOSTICO"]),
                                valor = (reader["VALOR"] == DBNull.Value ? 0 : (decimal)reader["VALOR"]),
                                animalId = (int)reader["IDANIMAL"],
                                veterinarioId = (int)reader["IDVETERINARIO"]
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

                string sql = "SELECT MAX(ID) FROM CONSULTAS";

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

        public Consulta Insert(Consulta entity)
        {
            if (entity.animalId == 0)
                throw new Exception("Id do animal não informado");

            if (entity.veterinarioId == 0)
                throw new Exception("Id do veterinário não informado");

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "INSERT INTO CONSULTAS (IDANIMAL, IDVETERINARIO, DTCONSULTA, PESO, SINTOMAS, DIAGNOSTICO, VALOR) " +
                             "VALUES (@IDANIMAL, @IDVETERINARIO, @DTCONSULTA, @PESO, @SINTOMAS, @DIAGNOSTICO, @VALOR)";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("IDANIMAL", SqlDbType.Int).Value = entity.animal.id;
                    cmd.Parameters.Add("IDVETERINARIO", SqlDbType.Int).Value = entity.veterinario.id;
                    cmd.Parameters.Add("DTCONSULTA", SqlDbType.DateTime).Value = entity.data;
                    cmd.Parameters.Add("PESO", SqlDbType.Float).Value = entity?.peso ?? 0;
                    cmd.Parameters.Add("SINTOMAS", SqlDbType.NVarChar).Value = entity?.sintomas ?? "";
                    cmd.Parameters.Add("DIAGNOSTICO", SqlDbType.NVarChar).Value = entity?.diagnostico ?? "";
                    cmd.Parameters.Add("VALOR", SqlDbType.Float).Value = entity?.valor ?? 0;

                    cmd.ExecuteNonQuery();

                    entity.id = GetMaxId();
                }
            }

            return entity;
        }

        public Consulta Update(int id, Consulta entity)
        {
            if (entity.animalId == 0)
                throw new Exception("Id do animal não informado");

            if (entity.veterinarioId == 0)
                throw new Exception("Id do veterinário não informado");

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "UPDATE CONSULTAS " +
                             "SET IDANIMAL = @IDANIMAL, " +
                                 "IDVETERINARIO = @IDVETERINARIO, " +
                                 "DTCONSULTA = @DTCONSULTA, " +
                                 "PESO = @PESO, " +
                                 "SINTOMAS = @SINTOMAS, " +
                                 "DIAGNOSTICO = @DIAGNOSTICO, " +
                                 "VALOR = @VALOR " +
                             "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("IDANIMAL", SqlDbType.Int).Value = entity.animal.id;
                    cmd.Parameters.Add("IDVETERINARIO", SqlDbType.Int).Value = entity.veterinario.id;
                    cmd.Parameters.Add("DTCONSULTA", SqlDbType.DateTime).Value = entity.data;
                    cmd.Parameters.Add("PESO", SqlDbType.Float).Value = entity?.peso ?? 0;
                    cmd.Parameters.Add("SINTOMAS", SqlDbType.NVarChar).Value = entity?.sintomas ?? "";
                    cmd.Parameters.Add("DIAGNOSTICO", SqlDbType.NVarChar).Value = entity?.diagnostico ?? "";
                    cmd.Parameters.Add("VALOR", SqlDbType.Float).Value = entity?.valor ?? 0;

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

                string sql = "DELETE CONSULTAS " +
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
