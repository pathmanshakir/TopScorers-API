using System.Linq;

namespace Model
{
    public class DBInitializer{
        public static void Initialize(LibraryContext context){
            context.Database.EnsureCreated();

            if(!context.Topscorers.Any()){

                 var klopp = new Coach()
                 {
                    foto = "https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/man279.png",
                    fullName = "Jürgen Klopp",
                    nationality="Germany"
                 };
                 context.Coaches.Add(klopp);
            
                
                var Pochettino = new Coach()
                 {
                    foto = "https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/man38223.png",
                    fullName = "Mauricio Pochettino",
                    nationality="Argentina"
                 };
                 context.Coaches.Add(Pochettino);
                 var pep = new Coach()
                 {
                    foto = "https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/man37974.png",
                    fullName = "pep guardiola",
                    nationality="Spain"
                 };
                 context.Coaches.Add(pep);
                var player = new Topscorer(){
                    Foto= "https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/p118748.png",
                    Name = "MO Salah",
                    Team = "Liverpool",
                    Position = "Winger",
                    Goals_Scored=32,
                    Assists=10,
                    Coach=klopp
                };
                    var player2 = new Topscorer(){
                    Foto= "https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/p78830.png",
                    Name = "Harry Kane",
                    Team = "Spurs",
                    Position = "Striker",
                    Goals_Scored=30,
                    Assists=3,
                    Coach=Pochettino
                };
                   var player3 = new Topscorer(){
                    Foto= "https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/p37572.png",
                    Name = "Sergio Aguero",
                    Team = "Man City",
                    Position = "Striker",
                    Goals_Scored=21,
                    Assists=6,
                    Coach=pep
                };
                context.Topscorers.Add(player);
                context.Topscorers.Add(player2);
                context.Topscorers.Add(player3);
                context.SaveChanges();
            }
        }
    }
}