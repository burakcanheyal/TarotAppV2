#nullable disable

using DataAccess.Records.Bases;

namespace DataAccess.Entities;

public class UserReading : Record
{
 
    public int UserId { get; set; }

    public User User { get; set; }

    public int ReadingId { get; set; }

    public Reading Reading { get; set; }
}