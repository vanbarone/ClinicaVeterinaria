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
    public class TipoAnimalController : ControllerBase
    {
        TipoAnimalRepository repo = new TipoAnimalRepository();

        /// <summary>
        /// Cadastra um novo tipo de animal
        /// </summary>
        /// <param name="entity">Objeto 'TipoAnimal' que deve ser inserido</param>
        /// <returns>Objeto 'TipoAnimal' que foi inserido</returns>
        [HttpPost]
        public IActionResult Inserir([FromForm] TipoAnimal entity, IFormFile arquivo)
        {
            try
            {
                #region Upload de imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, "Images", extensoesPermitidas);

                entity.imagem = uploadResultado;
                #endregion

                entity = repo.Insert(entity);

                return Ok(entity);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Lista todos os tipos de animais cadastrados
        /// </summary>
        /// <returns>Lista de Tipo de Animais</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<TipoAnimal> lista = repo.GetAll();

                return Ok(lista);

            } catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Altera os dados de um tipo de animal
        /// </summary>
        /// <param name="id">id do tipoAnimal que deve ser alterado</param>
        /// <param name="entity">Objeto 'TipoAnimal' que deve ser alterado</param>
        /// <returns>Objeto 'TipoAnimal' que foi alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromForm] TipoAnimal entity, IFormFile arquivo)
        {
            try
            {
                #region Upload de imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, "Images", extensoesPermitidas);

                entity.imagem = uploadResultado;
                #endregion

                entity = repo.Update(id, entity);

                return Ok(entity);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

        /// <summary>
        /// Exclui um tipo de animal
        /// </summary>
        /// <param name="id">id do tipoAnimal que erá excluído</param>
        /// <returns>Mensagem de exclusão com sucesso se conseguiu fazer a exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (! repo.Delete(id))
                    return NotFound();

                return Ok(new { msg = "TipoAnimal excluído com sucesso !" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }
    }
}
