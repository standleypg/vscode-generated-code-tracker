using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Stat : EntityBase
{
    public Guid ProjectId { get; private set; }
    public Project Project { get; private set; } = null!;
    public Guid UserId { get; private set; }
    public string UserEmail { get; private set; } = null!;
    public User User { get; private set; } = null!;
    public Guid SolutionId { get; private set; }
    public Solution Solution { get; private set; } = null!;
    public decimal NumberOfGeneratedLines { get; private set; }

    public static Stat Create(Guid projectId, Guid userId, string userEmail, Guid solutionId, decimal numberOfGeneratedLines)
    {
        return new Stat
        {
            ProjectId = projectId,
            UserId = userId,
            UserEmail = userEmail,
            SolutionId = solutionId,
            NumberOfGeneratedLines = numberOfGeneratedLines
        };
    }

}