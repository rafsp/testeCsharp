namespace CandidatosModel;
public class CandidatoModel
{
    public string? Id { get; set; }
    public required string Nome { get; set; }
    public required string Partido { get; set; }
    public int Idade { get; set; }
    public CandidatoModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}