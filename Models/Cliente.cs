using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Transactions;

namespace ClinicaVeterinaria.Models
{
    public class Cliente: Pessoa
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public List<Animal> animals { get; set; }
    }
}
