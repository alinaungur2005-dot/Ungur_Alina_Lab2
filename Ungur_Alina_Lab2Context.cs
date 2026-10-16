using Microsoft.EntityFrameworkCore;

public class Ungur_Alina_Lab2Context(DbContextOptions<Ungur_Alina_Lab2Context> options) : DbContext(options)
{
    public DbSet<Ungur_Alina_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Ungur_Alina_Lab2.Models.Publisher> Publisher { get; set; } = default!;

    public DbSet<Ungur_Alina_Lab2.Models.Author> Author { get; set; } = default!;
}
