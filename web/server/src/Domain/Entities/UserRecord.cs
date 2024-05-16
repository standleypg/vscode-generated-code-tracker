using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class UserRecord
{
    [Key, Column("USER_ID", Order = 0)]
    public Guid UserId { get; private set; }
    public User User { get; private set; } = new User();

    [Key, Column("SOLUTION_ID", Order = 1)]
    [MaxLength(50)]
    public string SolutionId { get; private set; } = "";

    [Key, Column("SEQ_NO", Order = 2)]
    public int SeqNo { get; private set; }

    [Column("RECORD_DATE")]
    public DateTime RecordDate { get; private set; }

    [Column("NOOF_AUTO_GEN_LINES", TypeName = "numeric(18, 0)")]
    public decimal NoOfAutoGenLines { get; private set; }

    public static UserRecord Create(Guid userId, string solutionId, int seqNo, DateTime recordDate, decimal noOfAutoGenLines)
    {
        return new UserRecord
        {
            UserId = userId,
            SolutionId = solutionId,
            SeqNo = seqNo,
            RecordDate = recordDate,
            NoOfAutoGenLines = noOfAutoGenLines
        };
    }
}
