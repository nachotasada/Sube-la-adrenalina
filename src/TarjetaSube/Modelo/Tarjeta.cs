using TarjetaSube.Excepciones;

namespace TarjetaSube.Modelo;

public class Tarjeta
{
    public static readonly decimal[] CargasAceptadas =
    {
        2000m, 3000m, 4000m, 5000m, 8000m, 10000m, 15000m, 20000m, 25000m, 30000m
    };

    public const decimal LimiteSaldo = 40000m;

    public int Id { get; set; }
    public decimal Saldo { get; private set; }

    public Tarjeta() : this(0m)
    {
    }

    public Tarjeta(decimal saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void Cargar(decimal monto)
    {
        if (!CargasAceptadas.Contains(monto))
        {
            throw new CargaInvalidaException(monto);
        }

        Saldo = Math.Min(Saldo + monto, LimiteSaldo);
    }

    public bool TieneSaldoSuficiente(decimal importe)
    {
        return Saldo >= importe;
    }

    public void Descontar(decimal importe)
    {
        if (!TieneSaldoSuficiente(importe))
        {
            throw new SaldoInsuficienteException();
        }

        Saldo -= importe;
    }
}
