namespace Tutorial4.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int AnimalId { get; set; }  // Powiązanie z zwierzęciem
    public Animal Animal { get; set; }
}