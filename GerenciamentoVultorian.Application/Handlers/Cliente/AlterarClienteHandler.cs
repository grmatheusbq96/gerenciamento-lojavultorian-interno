using GerenciamentoVultorian.CQS.Commands.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using GerenciamentoVultorian.Domain.Enums;
using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using MediatR;

namespace GerenciamentoVultorian.Application.Handlers.Cliente;

public class AlterarClienteHandler : IRequestHandler<AlterarClienteCommand, ResultViewModel<ClienteViewModel>>
{
    private readonly IClienteRepository _clienteRepository;

    public AlterarClienteHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public Task<ResultViewModel<ClienteViewModel>> Handle(AlterarClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var clienteEncontradoPorId = _clienteRepository.GetById(request.Id);
            var clienteEncontradoPorDocumento = _clienteRepository.BuscarPorDocumento(request.Documento).FirstOrDefault();

            if (clienteEncontradoPorDocumento != null && clienteEncontradoPorDocumento != clienteEncontradoPorId)
                return Task.FromResult(
                    new ResultViewModel<ClienteViewModel>(
                        null,
                        StatusCodeEnum.Forbidden)
                    .AddMessage("Documento informado já cadastrado."));

            clienteEncontradoPorId.AlterarDados(
                request.Nome,
                request.Documento,
                request.Endereco,
                request.Celular,
                request.Email
                );

            _clienteRepository.Commit();

            return Task.FromResult(
                new ResultViewModel<ClienteViewModel>(
                    new ClienteViewModel(clienteEncontradoPorId),
                    StatusCodeEnum.Created)
                );
        }
        catch
        {
            return Task.FromResult(
                new ResultViewModel<ClienteViewModel>(
                    null,
                    StatusCodeEnum.Ok)
                .AddMessage("Ocorreu um erro interno no sistema!"));
        }
    }
}