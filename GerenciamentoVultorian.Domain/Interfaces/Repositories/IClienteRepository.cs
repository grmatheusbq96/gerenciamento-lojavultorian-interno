using GerenciamentoVultorian.Domain.Interfaces.Repositories.Generic;
using GerenciamentoVultorian.Domain.Models;

namespace GerenciamentoVultorian.Domain.Interfaces.Repositories;

public interface IClienteRepository : IRepositorioGenerico<ClienteModel, int>
{
    IQueryable<ClienteModel> BuscarPorDocumento(string documento);
}