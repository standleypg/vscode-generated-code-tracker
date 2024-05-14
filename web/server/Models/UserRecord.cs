using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRecord
{
    [Key, Column("USER_ID", Order = 0)]
    public Guid UserId { get; set; }
    public User User { get; set; } = new User();

    [Key, Column("SOLUTION_ID", Order = 1)]
    [MaxLength(50)]
    public string SolutionId { get; set; } = "";

    [Key, Column("SEQ_NO", Order = 2)]
    public int SeqNo { get; set; }

    [Column("RECORD_DATE")]
    public DateTime RecordDate { get; set; }

    [Column("NOOF_AUTO_GEN_LINES", TypeName = "numeric(18, 0)")]
    public decimal NoOfAutoGenLines { get; set; }
}
