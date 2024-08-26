using clima_tempo_api.Domain.Model;
using clima_tempo_api.Services.Interfaces;
using System.Text.Json;

namespace clima_tempo_api.Services.Implementation {
    public class TemperaturaService : ITemperaturaService {

        private readonly IConfiguration _configuration;

        public TemperaturaService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public async Task<Temperatura?> GetTemperatura(string nomeCidade) {
            string baseUrl = _configuration["Api_url"];
            string apiKey = _configuration["Api_key"];
            string parametros = $"?q={nomeCidade}&appid={apiKey}";

            string url = baseUrl + parametros;

            using (var httpClient = new HttpClient()) {
                var response = await httpClient.GetAsync(url);

                if(response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<TemperaturaResponse>(content) ?? new();

                    return new Temperatura {
                        Cidade = nomeCidade,
                        TemperaturaCelsius = ConvertToCelsius(data.Main.Temp),
                        TemperaturaFahrenheit = ConvertToFahrenheit(data.Main.Temp),
                        TemperaturaKelvin = data.Main.Temp,
                    };
                }
                return null;
            }

        }

        private double ConvertToCelsius(double tempKelvin) => tempKelvin - 273.15;
        private double ConvertToFahrenheit(double tempKelvin) => (tempKelvin - 273.15) * 9.0 / 5.0 + 32;

    }
}
