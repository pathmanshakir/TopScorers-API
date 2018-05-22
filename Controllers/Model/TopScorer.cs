
namespace Model
{
    public class Topscorer
    {
        public int id { get; set; }
        public string Foto { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public Coach Coach { get; set; }
        public string Position { get; set; }
        public int Goals_Scored { get; set; }
        public int Assists {get; set;}
       
        
    }
}