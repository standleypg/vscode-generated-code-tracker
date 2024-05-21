using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Project : EntityBase
{
    public string ProjectName { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    [JsonIgnore]
    public IEnumerable<UserProject> UserProjects { get; private set; } = [];
    [JsonIgnore]
    public IEnumerable<Solution> Solutions { get; private set; } = [];
    [JsonIgnore]
    public IEnumerable<Stat> Stats { get; private set; } = [];

    public static Project Create(string projectName, string? description = null)
    {
        return new Project
        {
            ProjectName = projectName,
            Description = description
        };
    }
}