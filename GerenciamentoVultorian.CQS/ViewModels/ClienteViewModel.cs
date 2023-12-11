using GerenciamentoVultorian.Domain.Models;

namespace GerenciamentoVultorian.CQS.ViewModels;

public class ClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Documento { get; set; }
    public string Endereco { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

    public ClienteViewModel()
    {
    }

    public ClienteViewModel(ClienteModel model)
    {
        Id = model.Id;
        Nome = model.Nome;
        Documento = model.Documento;
        Endereco = model.Endereco;
        Celular = model.Celular;
        Email = model.Email;
    }
}