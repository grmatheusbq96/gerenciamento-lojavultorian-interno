﻿using GerenciamentoVultorian.CQS.Commands.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using GerenciamentoVultorian.Domain.Enums;
using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using GerenciamentoVultorian.Domain.Models;
using GerenciamentoVultorian.Domain.Utils;
using GerenciamentoVultorian.Domain.Validations;
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
            var documento = request.Documento.ExtrairNumeros();
            var celular = request.Celular.ExtrairNumeros();

            var cliente = new ClienteModel(
                celular,
                documento,
                request.Nome,
                request.Endereco,
                request.Email
                );

            var clienteValido = cliente.ModeloValido();

            if (!clienteValido.IsValid)
                return Task.FromResult(
                    new ResultViewModel<ClienteViewModel>(
                        null,
                        StatusCodeEnum.Forbidden)
                    .AddMessages(clienteValido.AddErrorMessages()));

            var clienteJaCadastradoParaODocumentoInformado = _clienteRepository.BuscarPorDocumento(documento).FirstOrDefault();
            if (clienteJaCadastradoParaODocumentoInformado != null)
                return Task.FromResult(
                        new ResultViewModel<ClienteViewModel>(
                            null,
                            StatusCodeEnum.Forbidden)
                        .AddMessage("Documento informado já cadastrado."));

            _clienteRepository.Create(cliente);
            _clienteRepository.Commit();

            return Task.FromResult(
                new ResultViewModel<ClienteViewModel>(
                    new ClienteViewModel(cliente),
                    StatusCodeEnum.Created)
                .AddMessage("Cliente cadastrado com sucesso!"));
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