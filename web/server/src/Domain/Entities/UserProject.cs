namespace Domain.Entities;

public class UserProject : EntityBase
{
    public Guid UserId { get; private set; }
    public string UserEmail { get; private set; } = null!;
    public User User { get; private set; } = null!;
    public Guid ProjectId { get; private set; }
    public Project Project { get; private set; } = null!;

    public static UserProject Create(Guid userId, Guid projectId)
    {
        return new UserProject
        {
            UserId = userId,
            ProjectId = projectId
        };
    }
}