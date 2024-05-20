using Application.User.Queries;
using Contracts.User;
using Mapster;

namespace Api.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<string, GetUserQuery>()
        .Map(dest => dest.Email, src => src);

        config.NewConfig<GetUserResult, GetUserByEmailResponse>()
        .Map(dest => dest.Id, src => src.User.UserId)
        .Map(dest => dest.Email, src => src.User.UserEmail)
        .Map(dest => dest.Username, src => src.User.UserName);
    }
}