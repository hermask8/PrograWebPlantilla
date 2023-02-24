namespace CRUDPractica.Models
{
    public class PersonModel
    {
       public int id { get; set; } 
       public string first_name { get; set; } 
       public string last_name { get; set; }
       public string? birth_date { get; set; } 
       public int gender { get; set; } 
       public int? status { get; set; } 
       public string? create_date { get; set; } 
       public string? edit_date { get;set; }
    }
}
