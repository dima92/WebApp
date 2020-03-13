using DAL.Entities;
using System;

namespace BLL.ModelDto
{
    public class DetailDto
    {    
        public int Id { get; set; }
        public string NomenclatureCode { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public bool? SpecAccount { get; set; } 
        public string NameStorekeeper { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
