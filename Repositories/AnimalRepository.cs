using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaVeterinaria.Repositories
{
    public class AnimalRepository
    {
        // Pega o objeto pelo id
        public Animal GetById(int id)
        {
            Animal entity = new Animal();

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM ANIMAIS WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity.id = (int)reader["ID"];
                            entity.nome = (string)reader["NOME"];
                            entity.raca = (string)reader["RACA"];
                            entity.dtNascimento = (DateTime)reader["DTNASC"];
                            entity.clienteId = (int)reader["IDCLIENTE"];
                            entity.tipoAnimalId = (int)reader["IDTIPOANIMAL"];
                        }
                    }
                }
            }

            return entity;
        }

        //Lista todos os animais
        public List<Animal> GetAll()
        {
            List<Animal> lista = new List<Animal>();

            using(SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT * FROM ANIMAIS";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Animal
                            {
                                id = (int)reader["ID"],
                                nome = (string)reader["NOME"],
                                raca = (string)reader["RACA"],
                                dtNascimento = (DateTime)reader["DTNASC"],
                                clienteId = (int)reader["IDCLIENTE"],
                                tipoAnimalId = (int)reader["IDTIPOANIMAL"]
                        });
                        }
                    }
                }
            }

            return lista;
        }

        //Pega o maior id da tabela, uso isso pra saber o id do último objeto inserido
        public int GetMaxId()
        {
            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "SELECT MAX(ID) FROM ANIMAIS";

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

        //médoto responsável pela inserção
        public Animal Insert(Animal entity)
        {
            //verifica se o id do cliente e do tipo de animal foram informados pois o 'required' não funciona qdo passa com valor = 0
            if (entity.tipoAnimalId == 0)
                throw new Exception("Id do tipo do animal não informado");

            if (entity.clienteId == 0)
                throw new Exception("Id do cliente não informado");

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "INSERT INTO ANIMAIS (NOME, RACA, DTNASC, IDCLIENTE, IDTIPOANIMAL) " +
                             "VALUES (@NOME, @RACA, @DTNASC, @IDCLIENTE, @IDTIPOANIMAL)";

                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("NOME", SqlDbType.NVarChar).Value = entity.nome;
                    cmd.Parameters.Add("RACA", SqlDbType.NVarChar).Value = entity.raca;
                    cmd.Parameters.Add("DTNASC", SqlDbType.DateTime).Value = entity.dtNascimento;
                    cmd.Parameters.Add("IDCLIENTE", SqlDbType.Int).Value = entity.clienteId;
                    cmd.Parameters.Add("IDTIPOANIMAL", SqlDbType.Int).Value = entity.tipoAnimalId;

                    cmd.ExecuteNonQuery();

                    entity.id = GetMaxId(); //pega o id do objeto inserido
                }
            }

            return entity;
        }

        //médoto responsável pela alteração
        public Animal Update(int id, Animal entity)
        {
            //verifica se o id do cliente e do tipo de animal foram informados pois o 'required' não funciona qdo passa com valor = 0
            if (entity.tipoAnimalId == 0)
                throw new Exception("Id do tipo do animal não informado");

            if (entity.clienteId == 0)
                throw new Exception("Id do cliente não informado");

            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "UPDATE ANIMAIS " +
                             "SET NOME = @NOME, " +
                                 "RACA = @RACA, " +
                                 "DTNASC = @DTNASC, " + 
                                 "IDCLIENTE = @IDCLIENTE, " +
                                 "IDTIPOANIMAL = @IDTIPOANIMAL " +
                             "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("NOME", SqlDbType.NVarChar).Value = entity.nome;
                    cmd.Parameters.Add("RACA", SqlDbType.NVarChar).Value = entity.raca;
                    cmd.Parameters.Add("DTNASC", SqlDbType.DateTime).Value = entity.dtNascimento;
                    cmd.Parameters.Add("IDCLIENTE", SqlDbType.Int).Value = entity.clienteId;
                    cmd.Parameters.Add("IDTIPOANIMAL", SqlDbType.Int).Value = entity.tipoAnimalId;

                    cmd.ExecuteNonQuery();
                }
            }

            entity.id = id;

            return entity;
        }

        //médoto responsável pela exclusão
        public bool Delete(int id)
        {
            using (SqlConnection conn = Conexao.GetConection())
            {
                conn.Open();

                string sql = "DELETE ANIMAIS " +
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
