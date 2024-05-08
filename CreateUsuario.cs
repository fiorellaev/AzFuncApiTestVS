using AzFuncApiTestVS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;

namespace My.Function
{
    public class CreateUsuario
    {
        private readonly ILogger<CreateUsuario> _logger;

        public CreateUsuario(ILogger<CreateUsuario> logger)
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

        [Function("Create")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Create")] HttpRequest req,
            [SqlInput(commandText: "dbo.usp_registrar", 
                commandType: System.Data.CommandType.StoredProcedure, 
                parameters: "@documentoidentidad={Query.DocId},@nombres={Query.Nombre},@telefono={Query.Telefono},@correo={Query.Correo},@ciudad={Query.Ciudad}", 
                connectionStringSetting: "ConnectionString")] IEnumerable<Usuario> usuario) 
        {
            _logger.LogInformation("C# HTTP trigger function processed a GetAll request.");
            return new OkObjectResult(usuario);
        }
    }

}
