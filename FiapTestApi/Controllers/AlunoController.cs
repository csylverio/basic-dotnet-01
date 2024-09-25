using FiapTestApi.Entities;
using FiapTestApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        Guid Guid { get; set; }
        private readonly ILogger<AlunoController> logger;
        //forma 1 de injeção
        private readonly IAlunoService alunoService;

        public AlunoController(IAlunoService alunoService, ILogger<AlunoController> logger)
        {
            this.alunoService = alunoService;
            this.logger = logger;
            Guid = Guid.NewGuid();
        }

        [HttpGet("alunos")]
        [Authorize]
        public IActionResult GetAlunos()
        {
            logger.LogInformation("Inicializando método GetAlunos. Guid: {Guid}", Guid.ToString());

            List<Aluno> ret = alunoService.RetornarAlunos();

            return Ok(ret);
        }


        //forma 3 de injeção
        [HttpGet("aluno")]
        [Authorize]
        public IActionResult GetAluno(IServiceProvider serviceProvider, int id)
        {
            logger.LogInformation("Inicializando método GetAluno. Guid: {Guid}", Guid.ToString());

            var alunoServiceProvider = serviceProvider.GetRequiredService<IAlunoService>();
            Aluno ret = alunoServiceProvider.RetornarAluno(id);

            return Ok(ret);
        }

        //forma 2 de injeção
        [HttpPost("inserirAluno")]
        [Authorize(Roles = "Adminstrador")]
        public IActionResult InserirAluno([FromKeyedServices("AlunoKeyed")] IAlunoService alunoKeyedService, [FromBody] Aluno aluno)
        {
            logger.LogInformation("Inicializando método InserirAluno. Guid: {Guid}", Guid.ToString());
            int id = alunoKeyedService.CriarAluno(aluno);
            return Ok(id);
        }
    }
}
