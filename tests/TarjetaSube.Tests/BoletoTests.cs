using TarjetaSube.Modelo;

namespace TarjetaSube.Tests;

public class BoletoTests
{
    [Test]
    public void Constructor_ArmaElBoletoConLosDatosDeLaOperacion()
    {
        var colectivo = new Colectivo("K");
        var tarjeta = new Tarjeta(2000m);
        var fecha = new DateTime(2026, 9, 15, 8, 0, 0);
        tarjeta.Descontar(Colectivo.TarifaBasica);

        var boleto = new Boleto(colectivo, tarjeta, Colectivo.TarifaBasica, fecha);

        Assert.That(boleto.Colectivo, Is.SameAs(colectivo));
        Assert.That(boleto.Tarjeta, Is.SameAs(tarjeta));
        Assert.That(boleto.Total, Is.EqualTo(Colectivo.TarifaBasica));
        Assert.That(boleto.SaldoRestante, Is.EqualTo(tarjeta.Saldo));
        Assert.That(boleto.Fecha, Is.EqualTo(fecha));
    }
}
