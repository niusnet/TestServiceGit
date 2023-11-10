using TestService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("time/utc", () => Results.Ok(DateTime.UtcNow));


var products = new[] { 
    new Product(1, "Table", 100),
    new Product(2, "Chair", 200),
    new Product(3, "Desk", 300),
    new Product(4, "Computer", 400),
    new Product(5, "Beer fridge", 500)
};
app.MapGet("/products", () => products);

await app.RunAsync();
