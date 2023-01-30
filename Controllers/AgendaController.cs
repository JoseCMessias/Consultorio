
using Consultorio.Models;
using Consultorio.Service;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly IEmailService _emailService;
        List<Agendamento> agendamentos = new List<Agendamento>();

        public AgendaController(IEmailService emailService)
        {
            agendamentos.Add(new Agendamento 
            {
                Id = 1, 
                NomePaciente = "Arian", 
                Horario = new DateTime(2023, 01, 30)
            });
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(agendamentos);
        }

         [HttpGet("Buasca-Agendamento/{id}")]
        public IActionResult GetById(int id)
        {
            var agendamentoSelecionado = agendamentos
            .FirstOrDefault(x => x.Id == id);

            if(agendamentoSelecionado is not null)
                return Ok(agendamentoSelecionado);
            else
                return BadRequest("Erro ao buscar o agendamento");      
        }

        [HttpPost]
        public IActionResult Post()
        {
            var pacienteAgendado = true;

            if(pacienteAgendado)
            {
                _emailService.EnviarEmail("Arian@gmail.com");
            }

            return Ok();
        }
    }
}
