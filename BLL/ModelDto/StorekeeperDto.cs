using System.ComponentModel.DataAnnotations;

namespace BLL.ModelDto
{
    public class StorekeeperDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patron { get; set; }
    }
}
