using AzFuncApiTestVS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;

namespace My.Function
{
    public class RemoveUsuario
    {
        private readonly ILogger<RemoveUsuario> _logger;

        public RemoveUsuario(ILogger<RemoveUsuario> logger)
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

        [Function("Remove")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Remove")] HttpRequest req,
            [SqlInput(commandText: "dbo.usp_eliminar", 
                commandType: System.Data.CommandType.StoredProcedure, 
                parameters: "@idusuario={Query.Id}", 
                connectionStringSetting: "ConnectionString")] IEnumerable<Usuario> usuario) 
        {
            _logger.LogInformation("C# HTTP trigger function processed a GetAll request.");
            return new OkObjectResult(usuario);
        }
    }

}
