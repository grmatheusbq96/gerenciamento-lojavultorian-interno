using GerenciamentoVultorian.CQS.Commands.Cliente;
using GerenciamentoVultorian.CQS.Dtos.Cliente;
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
        return Ok();
    }

    [HttpGet("BuscarPorId")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult BuscarClientePorId([FromQuery] int id)
    {
        return Ok();
    }

    [HttpPost("Cadastrar")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult CadastrarCliente([FromBody] CadastrarClienteDto dto) =>
        Ok(_mediator.Send(new CadastrarClienteCommand(dto)).Result);

    [HttpPut("Alterar")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult AlterarCliente([FromQuery] int id, [FromBody] string value)
    {
        return Ok();
    }

    [HttpPut("Inativar")]
    [ProducesResponseType(typeof(ResultViewModel<ClienteViewModel>), (int)HttpStatusCode.OK)]
    public IActionResult InativarCliente([FromBody] string value)
    {
        return Ok();
    }
}