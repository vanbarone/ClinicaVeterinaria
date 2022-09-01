using ClinicaVeterinaria.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public class Consulta
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int id { get; set; }

        [Required(ErrorMessage = "Animal não informado")]
        public int animalId {
            get { return animal?.id ?? 0; }
            
            set
            {
                AnimalRepository repo = new AnimalRepository();

                if (value != 0)
                    animal = repo.GetById(value);
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Animal animal { get; set; }

        [Required(ErrorMessage = "Veterinário não informado")]
        public int veterinarioId
        {
            get { return veterinario?.id ?? 0; }

            set
            {
                VeterinarioRepository repo = new VeterinarioRepository();

                if (value != 0)
                    veterinario = repo.GetById(value);
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)] 
        public Veterinario veterinario { get; set; }

        [Required(ErrorMessage = "Data não informada")]
        public DateTime data { get; set; }

        public double peso { get; set; }

        public string sintomas { get; set; }

        public string diagnostico { get; set; }

        public decimal valor { get; set; }

    }
}
