namespace CP2_net.Models;

public class Moto
{
    public int Id { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public string? Cor { get; set; }
    public string? Vaga { get; set; }
    public DateTime Entrada { get; set; }
    public DateTime? Saida { get; set; }
}
