using GerenciamentoVultorian.CQS.Queries.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using GerenciamentoVultorian.Domain.Enums;
using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using MediatR;

namespace GerenciamentoVultorian.Application.Handlers.Cliente;

public class BuscarClienteHandler : IRequestHandler<BuscarClienteQuery, ResultViewModel<List<ClienteViewModel>>>
{
    private readonly IClienteRepository _clienteRepository;

    public BuscarClienteHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public Task<ResultViewModel<List<ClienteViewModel>>> Handle(BuscarClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var listaRetorno = new List<ClienteViewModel>();
            var totalClientesNaBase = _clienteRepository.GetAll().ToList();

            totalClientesNaBase.ForEach(c =>
                listaRetorno.Add(new ClienteViewModel(c)));

            return Task.FromResult(
                new ResultViewModel<List<ClienteViewModel>>(
                    listaRetorno,
                    StatusCodeEnum.Ok)
                );
        }
        catch
        {
            return Task.FromResult(
                new ResultViewModel<List<ClienteViewModel>>(
                    null,
                    StatusCodeEnum.Ok)
                .AddMessage("Ocorreu um erro interno no sistema!"));
        }
    }
}