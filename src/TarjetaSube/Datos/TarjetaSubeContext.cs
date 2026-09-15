using Microsoft.EntityFrameworkCore;
using TarjetaSube.Modelo;

namespace TarjetaSube.Datos;

public class TarjetaSubeContext : DbContext
{
    public DbSet<Tarjeta> Tarjetas { get; set; } = null!;
    public DbSet<Colectivo> Colectivos { get; set; } = null!;
    public DbSet<Boleto> Boletos { get; set; } = null!;

    public TarjetaSubeContext(DbContextOptions<TarjetaSubeContext> options) : base(options)
    {
    }
}
