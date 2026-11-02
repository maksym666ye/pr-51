using PostService.BusinessLogic;
using PostService.DataAccess;
using PostService.Dtos;
using PostService.Mappings;
using PostService.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostingDbContext>();
builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IPostingService, PostingService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "PostService REST API",
        Version = "1.0",
        Description = "REST API сервісу обліку поштових відправлень"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PostingDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("/postings", (IPostingService postingService) =>
    Results.Ok(postingService.GetAll().Select(PostingMapper.ToPostingGetDto)))
    .WithSummary("Отримати всі відправлення")
    .WithDescription("Повертає повний список поштових відправлень з бази даних.");

app.MapGet("/postings/{id}", (int id, IPostingService postingService) =>
{
    var posting = postingService.Find(id);
    return posting == null ? Results.NotFound() : Results.Ok(PostingMapper.ToPostingGetDto(posting));
})
.WithSummary("Отримати відправлення за ID")
.WithDescription("Повертає інформацію про конкретне відправлення за його ідентифікатором.");

app.MapPost("/postings", (PostingPostDto postDto, IPostingService postingService) =>
{
    var newPosting = PostingMapper.ToPosting(postDto);
    var savedObject = postingService.Create(newPosting);
    var resultDto = PostingMapper.ToPostingGetDto(savedObject);
    return Results.Created($"/postings/{resultDto.Id}", resultDto);
})
.WithSummary("Створити нове відправлення")
.WithDescription("Приймає дані нового відправлення, зберігає його та повертає створений об'єкт.");

app.MapPut("/postings/{id}", (int id, PostingPutDto putDto, IPostingService postingService) =>
{
    if (id != putDto.Id) return Results.BadRequest();

    var postingToUpdate = new Posting
    {
        Id = putDto.Id,
        From = putDto.From,
        To = putDto.To,
        Content = putDto.Content,
        DeliveryType = putDto.DeliveryType,
        Weight = putDto.Weight,
        Width = putDto.Width,
        Height = putDto.Height,
        Depth = putDto.Depth,
        Value = putDto.Value,
        Price = putDto.Price
    };

    var updatedPosting = postingService.Update(postingToUpdate);
    return updatedPosting == null ? Results.NotFound() : Results.Ok(PostingMapper.ToPostingGetDto(updatedPosting));
})
.WithSummary("Оновити існуюче відправлення")
.WithDescription("Оновлює дані відправлення за його ID.");

app.MapDelete("/postings/{id}", (int id, IPostingService postingService) =>
    postingService.Delete(id) ? Results.NoContent() : Results.NotFound())
    .WithSummary("Видалити відправлення")
    .WithDescription("Видаляє поштове відправлення з бази даних за вказаним ID.");

app.Run();