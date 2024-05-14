using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MainUserStat
{
    [Key, Column(Order = 0)]
    public Guid UserId { get; set; }

    [Key, Column(Order = 1)]
    [StringLength(50)]
    public required string ProjectId { get; set; }

    [Key, Column(Order = 2)]
    [StringLength(50)]
    public required string SolutionId { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal NoOfAutoGenLines { get; set; }
}