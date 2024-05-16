using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Project
{
    [Key, Column("PROJECT_ID")]
    [MaxLength(50)]
    public string ProjectId { get; private set; } = string.Empty;

    [Column("PROJECT_NAME")]
    [MaxLength(50)]
    public string ProjectName { get; private set; } = string.Empty;

    public static Project Create(string projectId, string projectName)
    {
        return new Project
        {
            ProjectId = projectId,
            ProjectName = projectName
        };
    }
}