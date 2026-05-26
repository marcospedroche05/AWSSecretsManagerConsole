// See https://aka.ms/new-console-template for more information
using AWSSecretsManagerConsole.Helpers;
using AWSSecretsManagerConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secretos AWS");
string miSecret = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecret);
//MAPEAMOS EL STRING CON NUESTRO MODEL
KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecret);
Console.WriteLine("MySql: " + model.MySql);
Console.WriteLine("Bucket: " + model.Bucket);
Console.WriteLine("Api: " + model.Api);
Console.WriteLine("Todo correcto!!!!!!!");

var provider = new ServiceCollection()
    .AddTransient<ClaseTest>()
    .AddSingleton<KeysModel>(x => model)
    .BuildServiceProvider();

//LA INYECCION ESTA RESUELTA Y VAMOS A COMPROBAR LA FUNCIONALIDAD
var test = provider.GetService<ClaseTest>();
Console.WriteLine("Api Key: " + test.GetApiKey());

