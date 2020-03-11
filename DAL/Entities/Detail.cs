using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        [Required]
        public string NomenclatureCode { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool SpecAccount { get; set; }
        [Required]
        public int StorekeeperId { get; set; } // внешний ключ
        public Storekeeper Storekeeper { get; set; } // навигационное свойство
        [Required]
        public DateTime Created { get; set; }
        public DateTime? DeleteDate { get; set; }

        public override string ToString()
        {
            return $" №{Id} от {Created:dd.MM.yyyy hh:mm:ss}";
        }
    }
}
