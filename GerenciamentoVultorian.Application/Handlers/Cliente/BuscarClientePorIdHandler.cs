using GerenciamentoVultorian.CQS.Queries.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using GerenciamentoVultorian.Domain.Enums;
using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using MediatR;

namespace GerenciamentoVultorian.Application.Handlers.Cliente;

public class BuscarClientePorIdHandler : IRequestHandler<BuscarClientePorIdQuery, ResultViewModel<ClienteViewModel>>
{
    private readonly IClienteRepository _clienteRepository;

    public BuscarClientePorIdHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public Task<ResultViewModel<ClienteViewModel>> Handle(BuscarClientePorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var clienteEncontrado = _clienteRepository.GetById(request.Id);
            if (clienteEncontrado == null)
                return Task.FromResult(
                    new ResultViewModel<ClienteViewModel>(
                        null,
                        StatusCodeEnum.NotFound)
                    .AddMessage("Nenhum cliente encontrado."));
            else
            {
                ///Escrever aqui uma possível regra para cliente encontrado. Ex: verificar reputação do cliente;
                return Task.FromResult(
                    new ResultViewModel<ClienteViewModel>(
                        new ClienteViewModel(clienteEncontrado),
                        StatusCodeEnum.Ok)
                    );
            }
        }
        catch
        {
            return Task.FromResult(
                new ResultViewModel<ClienteViewModel>(
                    null,
                    StatusCodeEnum.InternalServerError)
                .AddMessage("Ocorreu um erro interno no sistema!"));
        }
    }
}