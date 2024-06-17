using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Enums
{
    public class Enum
    {
        public enum TasksStatus
        {
            [Display(Name = "Pendiete")]
            Pending = 1,
            [Display(Name = "Completo")]
            Complete = 2
        }
    }
}
