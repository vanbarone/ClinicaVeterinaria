using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        VeterinarioRepository repo = new VeterinarioRepository();

        /// <summary>
        /// Cadastra um novo veterinário
        /// </summary>
        /// <param name="entity">Objeto 'Veterinario' que deve ser inserido</param>
        /// <returns>Objeto 'Veterinario' que foi inserido</returns>
        [HttpPost]
        public IActionResult Inserir(Veterinario entity)
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
        /// Lista todos os veterinários cadastrados
        /// </summary>
        /// <returns>Lista de Veterinarios</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Veterinario> lista = repo.GetAll();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Altera os dados de um veterinário
        /// </summary>
        /// <param name="id">id do veterinário que deve ser alterado</param>
        /// <param name="entity">Objeto 'Veterinario' que deve ser alterado</param>
        /// <returns>Objeto 'Veterinario' que foi alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Veterinario entity)
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
        /// Exclui um veterinário
        /// </summary>
        /// <param name="id">id do veterinário que erá excluído</param>
        /// <returns>Mensagem de exclusão com sucesso se conseguiu fazer a exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (!repo.Delete(id))
                    return NotFound();

                return Ok(new { msg = "Veterinário excluído com sucesso !" });

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }
    }
}
