// See https://aka.ms/new-console-template for more information
using CleanArchitecture.Domain;
using ClientArchitecture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

StreamerDbContext context = new();

//await AddNewRecords();

//QueryStreaming();
// QueryFilter();


//await QueryFilter();

//await AddNewStreamerWithVideo();

//await AddNewDirectoryWithVideo();
await MultipleEntityWithQuery();


async Task MultipleEntityWithQuery()
{
   // var videoWithActor = await context!.Videos.Include(a => a.Actors).FirstOrDefaultAsync(id => id.Id == 1);

  // var actor = await context!.Actors.Select(x => x.Nombre).ToListAsync();

  var videoWithDirector = await context!
      .Videos.Where(x=> x.Director != null).Include(q => q.Director)
      .Select(x => new
      {
          nombre_completo_director = $"{x.Director.Nombre} - {x.Director.Apellido}",
          movie = x.Nombre
      }).ToListAsync();
  
  videoWithDirector.ForEach(movie =>
  {
      Console.WriteLine($"{movie.nombre_completo_director} {movie.movie}");
  });

}
async Task AddNewDirectoryWithVideo()
{
    var directory = new Director()
    {
        Nombre = "Pepe",
        Apellido = "Santander",
        VideoId = 1
    };

    await context.AddAsync(directory);
    await context.SaveChangesAsync();

}
async Task AddVideoWithNewActor()
{
    var actor = new Actor()
    {
        Nombre = "Anyelo",
        Apellido = "vinzen"
    };
    
    await context.AddAsync(actor);
    await context.SaveChangesAsync();
    
    var videoActor = new VideoActor()
    {
        ActorId = actor.Id,
        VideoId = 1
    };
    
    await context.AddAsync(videoActor);
    await context.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer()
    {
        Nombre = "Pantaya"
    };

    var hungerGame = new Video()
    {
        Nombre = "Hunger games",
        Streamer = pantaya
    };

    await context.AddAsync(hungerGame);
    await context.SaveChangesAsync();
}


async Task QueryableMethods(){
       // var streamer  = context.Streamers.Where(y => EF.like(co))
}
async Task QueryFilter()
{

    var result = await (from i in context.Streamers
            where EF.Functions.Like(i.Nombre, $"%net%")
            select i
        ).ToListAsync();
    var listado =  context.Streamers.ToList().Where(x => x.Nombre == "Netflix").ToList();
    
    
    var filter = await context.Streamers.ToListAsync();//.Where(x => x.Nombre == "Netflix").ToListAsync();

    // foreach (var streamers in filter)
    // {
    //     Console.WriteLine($"{streamers.Id}  {streamers.Nombre} {streamers.Url}");
    //
    // }
    
    result.ForEach(streamer =>
    {
        Console.WriteLine($"{streamer.Id}  {streamer.Nombre} {streamer.Url}");
    });

}

void QueryStreaming()
{
    var streamers = context!.Streamers!.ToList();
    
    foreach (var str in streamers)
    {
        Console.WriteLine($"Identificador: {str.Id} Nombre:{str.Nombre} Url: {str.Url}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new Streamer()
    {
        Nombre = "Disney",
        Url = "Https://www.disney.com"
    };
    
    await context.Streamers.AddAsync(streamer);
    await context.SaveChangesAsync();

    var movies = new List<Video>()
    {
        new Video
        {
            Nombre = "La cenicienta",
            StreamerId = streamer.Id
        },
        new Video()
        {
            Nombre = "El jorobado Vancuel",
            StreamerId = streamer.Id
        }
    };
    
    await context.Videos.AddRangeAsync(movies);
    await context.SaveChangesAsync();
}