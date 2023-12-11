namespace GerenciamentoVultorian.Domain.Models;

public class ClienteModel : Entity<int>
{
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataAlteracao { get; private set; }

    public string Nome { get; private set; }
    public string Documento { get; private set; }
    public string Endereco { get; private set; }
    public string Celular { get; private set; }
    public string Email { get; private set; }

    public ClienteModel(string nome, string documento, string endereco, string celular, string email)
    {
        DataCadastro = DateTime.Now;
        Nome = nome;
        Documento = documento;
        Endereco = endereco;
        Celular = celular;
        Email = email;
    }

    public ClienteModel AlterarDados(string nome, string documento, string endereco, string celular, string email)
    {
        DataAlteracao = DateTime.Now;

        Nome = !string.IsNullOrEmpty(nome) ? nome : Nome;
        Documento = !string.IsNullOrEmpty(documento) ? documento : Documento;
        Endereco = !string.IsNullOrEmpty(endereco) ? endereco : Endereco;
        Celular = !string.IsNullOrEmpty(celular) ? celular : Celular;
        Email = !string.IsNullOrEmpty(email) ? email : Email;

        return this;
    }
}