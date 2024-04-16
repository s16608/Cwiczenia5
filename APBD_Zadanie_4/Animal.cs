using System.ComponentModel.DataAnnotations;

namespace APBD_Zadanie_4
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public string Category { get; set; }
        public double Weight { get; set; }

        public string Color { get; set; }
    }
}
