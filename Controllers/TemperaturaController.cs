using clima_tempo_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clima_tempo_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TemperaturaController : ControllerBase {

        private readonly ILogger<TemperaturaController> _logger;
        private readonly ITemperaturaService _temperaturaService;

        public TemperaturaController(ILogger<TemperaturaController> logger, ITemperaturaService temperaturaService) {
            _temperaturaService = temperaturaService;
            _logger = logger;
        }

        [HttpGet("{nomeCidade}")]
        public async Task<IActionResult> GetTemperaturaCidade(string nomeCidade) {
            try {

                var temperatura = await _temperaturaService.GetTemperatura(nomeCidade);
                if(temperatura != null) {

                    return Ok(temperatura);
                }
                return BadRequest();
            }
            catch (Exception) {
                throw;
            }
        }
    }
}