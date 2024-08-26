using clima_tempo_api.Domain.Model;

namespace clima_tempo_api.Services.Interfaces {
    public interface ITemperaturaService {

        Task<Temperatura?> GetTemperatura(string nomeCidade);
    }
}
