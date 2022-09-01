using ClinicaVeterinaria.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public class Animal
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]     //não mostra esse campo no json na inserção e alteração
        public int id { get; set; }

        [Required(ErrorMessage = "Nome não informado")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Raça não informada")]
        public string raca { get; set; }

        [Required(ErrorMessage = "Data de nascimento não informada")]
        public DateTime dtNascimento { get; set; }

        [Required(ErrorMessage = "Tipo do Animal não informado")]
        public int tipoAnimalId 
        {
            get { return tipoAnimal?.id ?? 0; } //se o objeto for nulo pega o valor default

            set {
                TipoAnimalRepository repo = new TipoAnimalRepository();

                if (value != 0)
                    tipoAnimal = repo.GetById(value);   //carrega os dados do objeto tipoAnimal
            } 
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public TipoAnimal tipoAnimal { get; set; }

        [Required(ErrorMessage = "Cliente não informado")]
        public int clienteId
        {
            get { return cliente?.id ?? 0; }    //se o objeto for nulo pega o valor default

            set
            {
                ClienteRepository repo = new ClienteRepository();

                if (value != 0)
                    cliente = repo.GetById(value);  //carrega os dados do objeto cliente
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Cliente cliente { get; set; }

    }
}
