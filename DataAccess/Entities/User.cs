#nullable disable

using DataAccess.Enums;
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class User : Record
{

    [Required]
    [StringLength(10)]
    public string UserName { get; set; }

    [Required]
    [StringLength(8)]
    public string Password { get; set; }

    public bool IsActive { get; set; } 
    public Statuses Status { get; set; }

    public Role Role { get; set; }
    public int RoleId { get; set; }

    public List<UserReading> UserReadings { get; set; }
}