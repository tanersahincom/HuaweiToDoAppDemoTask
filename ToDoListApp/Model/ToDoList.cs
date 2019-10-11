using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.Model
{
    public class ToDoList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}