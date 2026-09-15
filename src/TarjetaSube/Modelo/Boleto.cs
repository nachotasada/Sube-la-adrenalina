namespace TarjetaSube.Modelo;

public class Boleto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public decimal SaldoRestante { get; set; }

    public int ColectivoId { get; set; }
    public Colectivo Colectivo { get; set; } = null!;

    public int TarjetaId { get; set; }
    public Tarjeta Tarjeta { get; set; } = null!;

    public Boleto()
    {
    }

    public Boleto(Colectivo colectivo, Tarjeta tarjeta, decimal total, DateTime fecha)
    {
        Colectivo = colectivo;
        Tarjeta = tarjeta;
        Total = total;
        SaldoRestante = tarjeta.Saldo;
        Fecha = fecha;
    }
}
