using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp.training.congruent.classes
{
    [Table("Accounts", Schema = "training")]
    public class Accounts
    {
        [Key]
        public string AccountNumber { get; set; } = string.Empty;// Primary Key
        public string AccountType { get; set; } = string.Empty;
    }
}
