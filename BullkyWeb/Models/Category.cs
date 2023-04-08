using System.ComponentModel.DataAnnotations;

namespace BullkyWeb.Models
{
    public class Category
    {
        //if we add id in class name or write id it automatic think it as primary key
        //[Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
