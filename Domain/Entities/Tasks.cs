using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static ToDo.Domain.Enums.Enum;

namespace ToDo.Domain.Entities
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 

        [DefaultValue(1)]
        public TasksStatus Status { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
