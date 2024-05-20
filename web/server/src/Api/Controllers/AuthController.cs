using Application.Auth.Commands;
using Application.Auth.Queries;
using Contracts.Auth;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<RegisterCommand>(request));

        return CreatedAtAction("GetUserByEmail", "User", new { id = result!.User.UserEmail }, _mapper.Map<AuthResponse>(result!));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<LoginQuery>(request));

        return Ok(_mapper.Map<AuthResponse>(result));
    }
}