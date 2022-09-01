using APIMaisEventos.Utils;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        AnimalRepository repo = new AnimalRepository();

        /// <summary>
        /// Cadastra um novo animal
        /// </summary>
        /// <param name="entity">Objeto 'Animal' que deve ser inserido</param>
        /// <returns>Objeto 'Animal' que foi inserido</returns>
        [HttpPost]
        public IActionResult Inserir(Animal entity)
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
        /// Lista todos os animais cadastrados
        /// </summary>
        /// <returns>Lista de Animais</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Animal> lista = repo.GetAll();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Altera os dados de um animal
        /// </summary>
        /// <param name="id">id do animal que deve ser alterado</param>
        /// <param name="entity">Objeto 'Animal' que deve ser alterado</param>
        /// <returns>Objeto 'Animal' que foi alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Animal entity)
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
        /// Exclui um animal
        /// </summary>
        /// <param name="id">id do animal que erá excluído</param>
        /// <returns>Mensagem de exclusão com sucesso se conseguiu fazer a exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (!repo.Delete(id))
                    return NotFound();

                return Ok(new { msg = "Animal excluído com sucesso !" });

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }
    }
}
