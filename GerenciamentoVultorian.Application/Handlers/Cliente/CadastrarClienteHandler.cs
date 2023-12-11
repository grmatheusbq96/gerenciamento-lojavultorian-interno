using GerenciamentoVultorian.CQS.Commands.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using GerenciamentoVultorian.Domain.Models;
using MediatR;

namespace GerenciamentoVultorian.Application.Handlers.Cliente;

public class CadastrarClienteHandler : IRequestHandler<CadastrarClienteCommand, ResultViewModel<ClienteViewModel>>
{
    private readonly IClienteRepository _clienteRepository;

    public CadastrarClienteHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public Task<ResultViewModel<ClienteViewModel>> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = new ClienteModel(
                request.Nome,
                request.Documento,
                request.Endereco,
                request.Celular,
                request.Email
                );

            _clienteRepository.Create(cliente);
            _clienteRepository.Commit();

            return Task.FromResult(
                new ResultViewModel<ClienteViewModel>(
                    new ClienteViewModel(cliente)).AddMessage("Cliente cadastrado com sucesso!"));
        }
        catch (Exception ex)
        {
            return Task.FromResult(
                new ResultViewModel<ClienteViewModel>(
                    new ClienteViewModel()).AddMessage("Ocorreu um erro interno no sistema!", $"Exception: {ex.Message}"));
        }
    }
}