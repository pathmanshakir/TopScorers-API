using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

[Route("api/v1/TopScorers")]
public class BooksController2 : Controller
{

    private static List<Topscorer> list = new List<Topscorer>();

    private readonly LibraryContext context;
    public BooksController2(LibraryContext context)
    {
        this.context = context;
    }

 
    [Route("{id}")]   // api/v1/books/2
    [HttpGet]
    public IActionResult GetTopScorer(int id)
    {
        var TopScorer = context.Topscorers
        .Single(d => d.id == id);

        if (TopScorer == null)
            return NotFound();

        return Ok(TopScorer);
    }

    [Route("{id}/coach")]   // api/v1/books/2
    [HttpGet]
   public IActionResult GetPlayerCoach(int id)
   {
       
        var player = context.Topscorers.
        Include(d => d.Coach)
          .Single(d => d.id == id);

        if (player == null)
            return NotFound();

        return Ok(player.Coach);  
           }

 

    [HttpGet]         // api/v1/TopSCorers
    public List<Topscorer> GetAllTopScorers(string Team, string Name, string sort, int? pages, int? page, int? pageLength = 10, string dir = "asc")
    {
        IQueryable<Topscorer> query = context.Topscorers;
    

        if (!string.IsNullOrWhiteSpace(Team))
        {
            query = query.Where(d => d.Team == Team);
            //return context.Books
            //.Where(d =>d.Genre==genre)
            //.ToList();
        }
        if (!string.IsNullOrWhiteSpace(Name))
        {
            query = query.Where(d => d.Name == Name);
            //return context.Books
            //.Where(d =>d.ISBN==ISBN)
            //.ToList();
        }
        if (pages.HasValue)
        {
            query = query.Where(d => d.Goals_Scored == pages.Value);  //pages with 123 pages 
                                                                      //return context.Books
                                                                      // .Where(d =>d.Pages==pages)
                                                                      //.ToList();
        }
        if (page.HasValue)
        {
            query = query.Skip(page.Value * pageLength.Value);


        }
        if (!string.IsNullOrWhiteSpace(sort))
        {
            switch (sort)
            {
                case "Position":
                    if (dir == "asc")
                    {
                        query = query.OrderBy(d => d.Position);
                    }
                    else
                    {
                        query = query.OrderByDescending(d => d.Position);
                    }
                    break;

                case "Team":
                    if (dir == "asc")
                    {
                        query = query.OrderBy(d => d.Team);
                    }
                    else
                    {
                        query = query.OrderByDescending(d => d.Team);
                    }
                    break;


            }
        }
        query = query.Take(pageLength.Value);
        return query.ToList();
    }

    [Route("{id}")]
    [HttpDelete]
    public IActionResult DeletePlayer(int id)
    {
        var Player = context.Topscorers.Find(id);
        if (Player == null)
        {
            return NotFound();
        }

        //book verwijderen
        context.Topscorers.Remove(Player);
        context.SaveChanges();
        //Standaard response 204 bij een gelukte delete
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateTopScorer([FromBody] Topscorer newPlayer)
    {

        context.Topscorers.Add(newPlayer);
        context.SaveChanges();


        return Created("", newPlayer);

    }

    [HttpPut]
    public IActionResult UpdatePlayer([FromBody] Topscorer Player)
    {
        var orgPlayer = context.Topscorers.Find(Player.id);
        if (orgPlayer == null)
            return NotFound();

        orgPlayer.id = Player.id;
        orgPlayer.Foto = Player.Foto;
        orgPlayer.Name = Player.Name;
        orgPlayer.Team = Player.Team;
        orgPlayer.Position = Player.Position;
        orgPlayer.Goals_Scored = Player.Goals_Scored;
        orgPlayer.Coach=Player.Coach;
        orgPlayer.Assists = Player.Assists;


        context.SaveChanges();
        return Ok();
    }
}

