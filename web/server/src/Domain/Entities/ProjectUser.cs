using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ProjectUser
{
    [Key, Column("PROJECT_ID", Order = 0)]
    [MaxLength(50)]
    public string ProjectId { get; private set; } = string.Empty;
    public Project? Project { get; private set; }

    [Key, Column("USER_ID", Order = 1)]
    public Guid UserId { get; private set; }
    public User? User { get; private set; }

    public static ProjectUser Create(string projectId, Guid userId)
    {
        return new ProjectUser
        {
            ProjectId = projectId,
            UserId = userId
        };
    }
}
