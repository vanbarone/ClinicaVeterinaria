using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaVeterinaria.Repositories
{
    public class ConsultaRepository
    {
        private AnimalRepository repoAnimal = new AnimalRepository();
        private VeterinarioRepository repoVeterinario = new VeterinarioRepository();

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
                            entity.peso = (float)reader["PESO"];
                            entity.sintomas = (string)reader["SINTOMAS"];
                            entity.diagnostico = (string)reader["DIAGNOSTICO"];
                            entity.valor = (decimal)reader["VALOR"];
                            entity.animal = repoAnimal.GetById((int)reader["IDANIMAL"]);
                            entity.veterinario = repoVeterinario.GetById((int)reader["IDVETERINARIO"]);
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
                                peso = (double)reader["PESO"],
                                sintomas = (string)reader["SINTOMAS"],
                                diagnostico = (string)reader["DIAGNOSTICO"],
                                valor = (decimal)reader["VALOR"],
                                animal = repoAnimal.GetById((int)reader["IDANIMAL"]),
                                veterinario = repoVeterinario.GetById((int)reader["IDVETERINARIO"])
                        });
                        }
                    }
                }
            }

            return lista;
        }

        public Consulta Insert(Consulta entity)
        {
            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "INSERT INTO CONSULTAS (IDANIMAL, IDVETERINARIO, DTCONSULTA, PESO, SINTOMAS, DIAGNOSTICO, VALOR) " +
                             "VALUES (@IDANIMAL, @IDVETERINARIO, @DTCONSULTA, @PESO, @SINTOMAS, @DIAGNOSTICO, @VALOR)";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("IDANIMAL", SqlDbType.Int).Value = entity.animal.id;
                    cmd.Parameters.Add("IDVETERINARIO", SqlDbType.Int).Value = entity.veterinario.id;
                    cmd.Parameters.Add("DTCONSULTA", SqlDbType.DateTime).Value = entity.data;
                    cmd.Parameters.Add("PESO", SqlDbType.Float).Value = entity.peso;
                    cmd.Parameters.Add("SINTOMAS", SqlDbType.NVarChar).Value = entity.sintomas;
                    cmd.Parameters.Add("DIAGNOSTICO", SqlDbType.NVarChar).Value = entity.diagnostico;
                    cmd.Parameters.Add("VALOR", SqlDbType.Float).Value = entity.valor;

                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public Consulta Update(int id, Consulta entity)
        {
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
                    cmd.Parameters.Add("PESO", SqlDbType.Float).Value = entity.peso;
                    cmd.Parameters.Add("SINTOMAS", SqlDbType.NVarChar).Value = entity.sintomas;
                    cmd.Parameters.Add("DIAGNOSTICO", SqlDbType.NVarChar).Value = entity.diagnostico;
                    cmd.Parameters.Add("VALOR", SqlDbType.Float).Value = entity.valor;

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
