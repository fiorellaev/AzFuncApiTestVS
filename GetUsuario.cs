using AzFuncApiTestVS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;

namespace My.Function
{
    public class GetUsuario
    {
        private readonly ILogger<GetUsuario> _logger;

        public GetUsuario(ILogger<GetUsuario> logger)
        {
            _logger = logger;
        }

        /*
        [Function("ApiFunc")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }*/

        [Function("GetById")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetById/{Id}")] HttpRequest req,
            [SqlInput("select [IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad], [FechaRegistro] from dbo.USUARIO where IdUsuario = @Id",
                commandType: System.Data.CommandType.Text,
                parameters: "@Id={Id}",
                connectionStringSetting: "ConnectionString")] IEnumerable<Usuario> usuarios) 
        {
            _logger.LogInformation("C# HTTP trigger function processed a GetById request.");
            return new OkObjectResult(usuarios);
        }
    }

}
