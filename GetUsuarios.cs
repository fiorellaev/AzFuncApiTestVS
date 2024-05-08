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

        [Function("GetAll")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetAll")] HttpRequest req,
            [SqlInput(commandText: "dbo.usp_listar", 
                commandType: System.Data.CommandType.StoredProcedure, 
                parameters: "", 
                connectionStringSetting: "ConnectionString")] IEnumerable<Usuario> usuarios) 
        {
            _logger.LogInformation("C# HTTP trigger function processed a GetAll request.");
            return new OkObjectResult(usuarios);
        }
    }

}
