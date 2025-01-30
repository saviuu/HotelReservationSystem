using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services;

public class ReservaService
{
    private readonly Reserva _reserva;

    public ReservaService(Reserva reserva)
    {
        _reserva = reserva;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count <= _reserva.Suite.Capacidade)
        {
            _reserva.Hospedes = hospedes;
        }
        else
        {
            throw new Exception("Número de hóspedes excede a capacidade da suíte.");
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        _reserva.Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return _reserva.Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valorTotal = _reserva.DiasReservados * _reserva.Suite.ValorDiaria;

        // Desconto de 10% para reservas acima de 10 dias
        if (_reserva.DiasReservados >= 10)
        {
            valorTotal *= 0.90m;
        }

        return valorTotal;
    }
}
