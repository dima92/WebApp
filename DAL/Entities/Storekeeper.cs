using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Storekeeper
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SumKolDetail { get; set; }
        public List<Detail> Details { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode() => Id;

        public override bool Equals(object obj)
        {
            if (obj is Storekeeper storekeeper)
            {
                return Id.Equals(storekeeper.Id);
            }

            return false;
        }
    }
}
