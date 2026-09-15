using TarjetaSube.Excepciones;

namespace TarjetaSube.Modelo;

public class Colectivo
{
    public const decimal TarifaBasica = 1580m;

    public int Id { get; set; }
    public string Linea { get; set; } = string.Empty;

    public Colectivo()
    {
    }

    public Colectivo(string linea)
    {
        Linea = linea;
    }

    public Boleto PagarCon(Tarjeta tarjeta)
    {
        if (tarjeta == null)
        {
            throw new ArgumentNullException(nameof(tarjeta));
        }

        if (!tarjeta.TieneSaldoSuficiente(TarifaBasica))
        {
            throw new SaldoInsuficienteException();
        }

        tarjeta.Descontar(TarifaBasica);
        return new Boleto(this, tarjeta, TarifaBasica, DateTime.Now);
    }
}
