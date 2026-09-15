using TarjetaSube.Excepciones;
using TarjetaSube.Modelo;

namespace TarjetaSube.Tests;

public class TarjetaTests
{
    private static readonly decimal[] MontosAceptados = Tarjeta.CargasAceptadas;

    [TestCaseSource(nameof(MontosAceptados))]
    public void Cargar_ConMontoAceptado_AcreditaElSaldo(decimal monto)
    {
        var tarjeta = new Tarjeta();

        tarjeta.Cargar(monto);

        Assert.That(tarjeta.Saldo, Is.EqualTo(monto));
    }

    [Test]
    public void Cargar_ConMontoNoAceptado_LanzaExcepcion()
    {
        var tarjeta = new Tarjeta();

        Assert.Throws<CargaInvalidaException>(() => tarjeta.Cargar(1000m));
    }

    [Test]
    public void Cargar_SuperandoElLimite_ElSaldoQuedaTopeadoAlLimite()
    {
        var tarjeta = new Tarjeta(30000m);

        tarjeta.Cargar(30000m);

        Assert.That(tarjeta.Saldo, Is.EqualTo(Tarjeta.LimiteSaldo));
    }

    [Test]
    public void TieneSaldoSuficiente_ConSaldoMayorOIgual_DevuelveTrue()
    {
        var tarjeta = new Tarjeta(1580m);

        Assert.That(tarjeta.TieneSaldoSuficiente(1580m), Is.True);
    }

    [Test]
    public void TieneSaldoSuficiente_ConSaldoMenor_DevuelveFalse()
    {
        var tarjeta = new Tarjeta(1000m);

        Assert.That(tarjeta.TieneSaldoSuficiente(1580m), Is.False);
    }

    [Test]
    public void Descontar_ConSaldoSuficiente_RestaElImporte()
    {
        var tarjeta = new Tarjeta(2000m);

        tarjeta.Descontar(1580m);

        Assert.That(tarjeta.Saldo, Is.EqualTo(420m));
    }

    [Test]
    public void Descontar_SinSaldoSuficiente_LanzaExcepcionYNoModificaElSaldo()
    {
        var tarjeta = new Tarjeta(1000m);

        Assert.Throws<SaldoInsuficienteException>(() => tarjeta.Descontar(1580m));
        Assert.That(tarjeta.Saldo, Is.EqualTo(1000m));
    }
}
