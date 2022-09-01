using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        ConsultaRepository repo = new ConsultaRepository();

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="entity">Objeto 'Consulta' que deve ser inserido</param>
        /// <returns>Objeto 'Consulta' que foi inserido</returns>
        [HttpPost]
        public IActionResult Inserir(Consulta entity)
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
        /// Lista todas as consultas cadastradas
        /// </summary>
        /// <returns>Lista de Consultas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Consulta> lista = repo.GetAll();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Altera os dados de uma consulta
        /// </summary>
        /// <param name="id">id da consulta que deve ser alterada</param>
        /// <param name="entity">Objeto 'Consulta' que deve ser alterado</param>
        /// <returns>Objeto 'Consulta' que foi alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Consulta entity)
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
        /// Exclui uma consulta
        /// </summary>
        /// <param name="id">id da consulta que erá excluída</param>
        /// <returns>Mensagem de exclusão com sucesso se conseguiu fazer a exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (!repo.Delete(id))
                    return NotFound();

                return Ok(new { msg = "Consulta excluída com sucesso !" });

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }
    }
}
