using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class MainUserStats
{
    [Key, Column("USER_ID", Order = 0)]
    public Guid UserId { get; private set; }
    public User? User { get; private set; }

    [Key, Column("PROJECT_ID", Order = 1)]
    [MaxLength(50)]
    public string ProjectId { get; private set; } = string.Empty;
    public Project? Project { get; private set; }

    [Key, Column("SOLUTION_ID", Order = 2)]
    [MaxLength(50)]
    public string SolutionId { get; private set; } = string.Empty;

    [Column("NOOF_AUTO_GEN_LINES", TypeName = "numeric(18, 0)")]
    public decimal NoOfAutoGenLines { get; private set; }
}