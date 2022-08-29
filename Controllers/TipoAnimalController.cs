using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repositories;
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
        public IActionResult Inserir(TipoAnimal entidade)
        {
            try
            {
                entidade = repo.Insert(entidade);

                return Ok(entidade);
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
        public IActionResult Alterar(int id, TipoAnimal entidade)
        {
            try
            {
                entidade = repo.Update(id, entidade);

                return Ok(entidade);
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
