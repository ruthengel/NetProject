using System.ComponentModel.DataAnnotations;

namespace EasyDiet.Core.Models
{
    public class Weight
    {
        [Key]
        public DateTime Date { get; set; }
        public double CurrentWeight { get; set; }

        public Weight(DateTime date, double currentWeight)
        {
            Date = date;
            CurrentWeight = currentWeight;
        }
    }
}
