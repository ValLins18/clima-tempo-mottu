using clima_tempo_api.Domain.Enums;

namespace clima_tempo_api.Domain.Model {
    public class Temperatura {
        public string? Cidade { get ; set; }
        public double? TemperaturaCelsius { get; set; }
        public double? TemperaturaFahrenheit { get; set; }
        public double? TemperaturaKelvin{ get; set; }
    }
}
