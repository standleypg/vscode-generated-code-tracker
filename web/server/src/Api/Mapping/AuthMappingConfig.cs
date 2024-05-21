using Application.Auth.Commands;
using Application.Auth.Common;
using Application.Auth.Queries;
using Contracts.Auth;
using Mapster;

namespace Api.Mapping;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthResult, AuthResponse>()
        .Map(dest => dest.Id, src => src.User.Id)
        .Map(dest => dest.Username, src => src.User.UserName)
        .Map(dest => dest.Email, src => src.User.UserEmail)
        .Map(dest => dest.Token, src => src.Token);
    }
}