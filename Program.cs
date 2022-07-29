using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt=> opt.UseInMemoryDatabase("TrefasDb"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/",() => "Olá Mundo!");
app.MapGet("frases",async() =>
    await new HttpClient().GetStreamAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes")
);





app.Run();

 

 class Tarefa {
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsConcluida { get; set; }
    
 }

 class AppDbContext: DbContext{

    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {}

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();
 }

 