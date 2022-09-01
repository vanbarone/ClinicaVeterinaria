using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteRepository repo = new ClienteRepository();

        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="entity">Objeto 'Cliente' que deve ser inserido</param>
        /// <returns>Objeto 'Cliente' que foi inserido</returns>
        [HttpPost]
        public IActionResult Inserir(Cliente entity)
        {
            try
            {
                entity = repo.Insert(entity);

                return Ok(entity);

            }catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Lista todos os clientes cadastrados
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Cliente> lista = repo.GetAll();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Altera os dados de um cliente
        /// </summary>
        /// <param name="id">id do cliente que deve ser alterado</param>
        /// <param name="entity">Objeto 'Cliente' que deve ser alterado</param>
        /// <returns>Objeto 'Cliente' que foi alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cliente entity)
        {
            try
            {
                entity = repo.Update(id, entity);
                
                return Ok(entity);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="id">id do cliente que erá excluído</param>
        /// <returns>Mensagem de exclusão com sucesso se conseguiu fazer a exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (!repo.Delete(id))
                    return NotFound();

                return Ok(new { msg = "Cliente excluído com sucesso !" });

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }
    }
}
