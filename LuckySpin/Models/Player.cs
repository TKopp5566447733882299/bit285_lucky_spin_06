namespace LuckySpin.Models
{
    public class Player : DbContext
    {
        public int Luck { get; set; }
        public string FirstName { get; set; }
        public int PlayerId { get; set; }
        public decimal balance { get; set; }

    }
}