using AzFuncApiTestVS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;

namespace My.Function
{
    public class GetUsuarios
    {
        private readonly ILogger<GetUsuarios> _logger;

        public GetUsuarios(ILogger<GetUsuarios> logger)
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

        [Function("GetAll")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetAll")] HttpRequest req,
            [SqlInput("select [IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad], [FechaRegistro] from dbo.USUARIO",
                connectionStringSetting: "ConnectionString")] IEnumerable<Usuario> usuarios) 
        {
            _logger.LogInformation("C# HTTP trigger function processed a GetAll request.");
            return new OkObjectResult(usuarios);
        }
    }

}
