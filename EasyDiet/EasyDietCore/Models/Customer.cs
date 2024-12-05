namespace EasyDiet.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Weight> MyWeigths { get; set; }
        public int MyDiet { get; set; } 
        public bool Status { get; set; }

        public Customer(int id, string name, int myDiet)
        {
            Id = id;
            Name = name;
            MyWeigths = new List<Weight>();
            MyDiet = myDiet;
            Status = true;
        }

    }
}
