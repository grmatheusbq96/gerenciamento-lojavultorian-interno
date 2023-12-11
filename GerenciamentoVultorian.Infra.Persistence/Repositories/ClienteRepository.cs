using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using GerenciamentoVultorian.Domain.Models;
using GerenciamentoVultorian.Infra.Persistence.Contexts;
using GerenciamentoVultorian.Infra.Persistence.Repositories.Generic;

namespace GerenciamentoVultorian.Infra.Persistence.Repositories;

public class ClienteRepository : RepositorioGenerico<ClienteModel, int>, IClienteRepository
{
    public ClienteRepository(VultorianContext context) : base(context)
    {
    }

    public IQueryable<ClienteModel> BuscarPorDocumento(string documento) =>
        DbSet.Where(c => c.Documento.Equals(documento));
}