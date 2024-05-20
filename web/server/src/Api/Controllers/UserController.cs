using Application.User.Queries;
using Contracts.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserByEmail(string email)
    {
        var result = await _mediator.Send(_mapper.Map<GetUserQuery>(email));

        return Ok(_mapper.Map<GetUserByEmailResponse>(result));
    }
}