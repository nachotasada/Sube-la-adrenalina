namespace TarjetaSube.Excepciones;

public class CargaInvalidaException : Exception
{
    public CargaInvalidaException(decimal monto)
        : base($"El monto {monto} no es una carga aceptada.")
    {
    }
}
