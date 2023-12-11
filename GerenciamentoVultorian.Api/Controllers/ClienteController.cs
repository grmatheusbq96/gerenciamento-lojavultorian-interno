using GerenciamentoVultorian.CQS.Commands.Cliente;
using GerenciamentoVultorian.CQS.Dtos.Cliente;
using GerenciamentoVultorian.CQS.Queries.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciamentoVultorian.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Buscar")]
    [ProducesResponseType(typeof(List<ResultViewModel<ClienteViewModel>>), (int)HttpStatusCode.OK)]
    public IActionResult BuscarTodosClientes()
    {
        var objetoRetorno = _mediator.Send(new BuscarClienteQuery()).Result;
        if (!objetoRetorno.Success)
            return StatusCode((int)objetoRetorno.StatusCode, objetoRetorno);

        return Ok(objetoRetorno);
    }

    [HttpGet("BuscarPorId")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult BuscarClientePorId([FromQuery] int id)
    {
        var objetoRetorno = _mediator.Send(new BuscarClientePorIdQuery(id)).Result;
        if (!objetoRetorno.Success)
            return StatusCode((int)objetoRetorno.StatusCode, objetoRetorno);

        return Ok(objetoRetorno);
    }

    [HttpPost("Cadastrar")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult CadastrarCliente([FromBody] CadastrarClienteDto dto)
    {
        var objetoRetorno = _mediator.Send(new CadastrarClienteCommand(dto)).Result;
        var urlParaBusca = nameof(BuscarClientePorId);

        if (!objetoRetorno.Success)
            return StatusCode((int)objetoRetorno.StatusCode, objetoRetorno);

        return CreatedAtAction(urlParaBusca, objetoRetorno);
    }

    [HttpPut("Alterar")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult AlterarCliente([FromQuery] int id, [FromBody] AlterarClienteDto dto)
    {
        var objetoRetorno = _mediator.Send(new AlterarClienteCommand(id, dto)).Result;
        var urlParaBusca = nameof(BuscarClientePorId);

        if (!objetoRetorno.Success)
            return StatusCode((int)objetoRetorno.StatusCode, objetoRetorno);

        return Created(urlParaBusca, objetoRetorno);
    }
}