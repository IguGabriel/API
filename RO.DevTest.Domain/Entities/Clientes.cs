namespace RO.DevTest.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
