using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Solution : EntityBase
{
    public Guid ProjectId { get; private set; }
    public Project Project { get; private set; } = null!;
    public string SolutionName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string? SolutionUrl { get; private set; }
    public string? SourceCodeUrl { get; private set; }
    [JsonIgnore]
    public IEnumerable<Stat> Stats { get; private set; } = [];
    public static Solution Create(Guid projectId, string solutionName, string description, string? solutionUrl = null, string? sourceCodeUrl = null)
    {
        return new Solution
        {
            ProjectId = projectId,
            SolutionName = solutionName,
            Description = description,
            SolutionUrl = solutionUrl,
            SourceCodeUrl = sourceCodeUrl
        };
    }
}