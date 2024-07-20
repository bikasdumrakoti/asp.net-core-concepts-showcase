using System.ComponentModel.DataAnnotations;

namespace MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
