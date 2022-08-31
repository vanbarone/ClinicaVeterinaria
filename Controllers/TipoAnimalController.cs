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

        [HttpPost]
        public IActionResult Inserir([FromForm] TipoAnimal entity, IFormFile arquivo)
        {
            try
            {
                #region Upload de imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, "Images", extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extensão não permitida ");
                }

                entity.Imagem = uploadResultado;
                #endregion

                entity = repo.Insert(entity);

                return Ok(entity);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

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

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromForm] TipoAnimal entity, IFormFile arquivo)
        {
            try
            {
                #region Upload de imagem
                    string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                    string uploadResultado = Upload.UploadFile(arquivo, "Images", extensoesPermitidas);

                    if (uploadResultado == "")
                    {
                        return BadRequest("Arquivo não encontrado ou extensão não permitida ");
                    }

                    entity.Imagem = uploadResultado;
                #endregion

                entity = repo.Update(id, entity);

                return Ok(entity);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { msg = "Falha na conexão", erro = ex.Message });
            }
        }

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
