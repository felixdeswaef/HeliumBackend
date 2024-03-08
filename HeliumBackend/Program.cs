using dotenv.net;
using HeliumBackend;
using HeliumBackend.interfaces;
using HeliumBackend.models;
using HeliumBackend.realtime;
using HeliumBackend.services;
using MongoDB.Driver;










var builder = WebApplication.CreateBuilder(args);
var envVars = DotEnv.Read();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
//load db settings into model
builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("DBSettings"));
//create mongoclient instance
builder.Services.AddSingleton<IMongoClient>(_ =>
{
    return new MongoClient(envVars["mongoUrl"]);
});
// The admin database should exist on each MongoDB 3.6 Installation, if not explicitly deleted!
var isAlive = mongotest.ProbeForMongoDbConnection(envVars["mongoUrl"], "admin");
Console.WriteLine("Connection to "+envVars["mongoUrl"]+" was " + (isAlive ? "successful!" : "NOT successful!"));

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IGroupService, GroupService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI();
}
//TODO add back in maybe ?
//app.UseHttpsRedirection();



app.MapGet("/PingMongo", () =>
{
    var isAlive = mongotest.ProbeForMongoDbConnection(envVars["mongoUrl"], "admin");
    Console.WriteLine("Connection to "+envVars["mongoUrl"]+" was " + (isAlive ? "successful!" : "NOT successful!"));
    return "Connection to mongodb was " + (isAlive ? "successful!" : "NOT successful!");
})
    .WithName("Ping mongo")
    .WithDescription("")
    .WithOpenApi();


app.MapControllers();
app.MapHub<TextHub>("/SYNCTEXT");
app.MapHub<ShowHub>("/SYNCSHOW");

app.Run();



