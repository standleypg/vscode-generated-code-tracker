using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MainUserStats
{
    [Key, Column("USER_ID", Order = 0)]
    public Guid UserId { get; set; }
    public required User User { get; set; }

    [Key, Column("PROJECT_ID", Order = 1)]
    [MaxLength(50)]
    public string ProjectId { get; set; } = "";
    public Project Project { get; set; } = new Project();

    [Key, Column("SOLUTION_ID", Order = 2)]
    [MaxLength(50)]
    public string SolutionId { get; set; } = "";

    [Column("NOOF_AUTO_GEN_LINES", TypeName = "numeric(18, 0)")]
    public decimal NoOfAutoGenLines { get; set; }
}