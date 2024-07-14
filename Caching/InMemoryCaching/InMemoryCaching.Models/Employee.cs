using System.ComponentModel.DataAnnotations;

namespace InMemoryCaching.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
