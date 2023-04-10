using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BullkyBook.Models
{
    public class Category
    {
        //if we add id in class name or write id it automatic think it as primary key
        //[Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        //DisplayName show changed name in Ui
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
