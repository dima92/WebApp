using DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.ModelDto
{
    public class DetailDto
    {
        public int Id { get; set; }
        [Required]
        public int NomenclatureCode { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool SpecAccount { get; set; } = false;
        [Required]
        public DateTime Created { get; set; }
        public DateTime? DeleteDate { get; set; }
        [Required]
        public virtual Storekeeper Storekeeper { get; set; }
    }
}
