using Microsoft.Extensions.Configuration;


var builder = new ConfigurationBuilder()
    .AddUserSecrets("b3534026-7455-41b1-ace0-5d4768978c1b");

var config = builder.Build();

var xpto = config.GetSection("itaquaquecetuba").Get<MyCredentials>();

Console.WriteLine($"Username: {xpto.Username}; Password: {xpto.Password}");

class MyCredentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}


