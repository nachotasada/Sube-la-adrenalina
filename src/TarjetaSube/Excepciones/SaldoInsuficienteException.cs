namespace TarjetaSube.Excepciones;

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException()
        : base("La tarjeta no tiene saldo suficiente para pagar el pasaje.")
    {
    }
}
