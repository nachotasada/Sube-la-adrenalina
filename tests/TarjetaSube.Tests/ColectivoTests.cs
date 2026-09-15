using TarjetaSube.Excepciones;
using TarjetaSube.Modelo;

namespace TarjetaSube.Tests;

public class ColectivoTests
{
    [Test]
    public void PagarCon_ConSaldoSuficiente_DescuentaLaTarifaBasica()
    {
        var colectivo = new Colectivo("K");
        var tarjeta = new Tarjeta(2000m);

        colectivo.PagarCon(tarjeta);

        Assert.That(tarjeta.Saldo, Is.EqualTo(2000m - Colectivo.TarifaBasica));
    }

    [Test]
    public void PagarCon_ConSaldoSuficiente_DevuelveUnBoletoConLosDatosDelViaje()
    {
        var colectivo = new Colectivo("K");
        var tarjeta = new Tarjeta(2000m);

        var boleto = colectivo.PagarCon(tarjeta);

        Assert.That(boleto.Colectivo, Is.SameAs(colectivo));
        Assert.That(boleto.Tarjeta, Is.SameAs(tarjeta));
        Assert.That(boleto.Total, Is.EqualTo(Colectivo.TarifaBasica));
        Assert.That(boleto.SaldoRestante, Is.EqualTo(2000m - Colectivo.TarifaBasica));
    }

    [Test]
    public void PagarCon_SinSaldoSuficiente_LanzaExcepcionYNoDescuentaSaldo()
    {
        var colectivo = new Colectivo("K");
        var tarjeta = new Tarjeta(1000m);

        Assert.Throws<SaldoInsuficienteException>(() => colectivo.PagarCon(tarjeta));
        Assert.That(tarjeta.Saldo, Is.EqualTo(1000m));
    }

    [Test]
    public void PagarCon_TarjetaNula_LanzaArgumentNullException()
    {
        var colectivo = new Colectivo("K");

        Assert.Throws<ArgumentNullException>(() => colectivo.PagarCon(null!));
    }
}
