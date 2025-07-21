using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class Expence
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public double Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public string Category { get; set; } = null!;
        //// Constructor to initialize the properties
        //public Expence(int id, string description, decimal amount, DateTime date, string category)
        //{
        //    Id = id;
        //    Description = description;
        //    Amount = amount;
        //    Date = date;
        //    Category = category;
        //}
    }
}
