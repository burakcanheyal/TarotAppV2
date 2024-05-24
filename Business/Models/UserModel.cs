#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAccess.Enums;
using DataAccess.Records.Bases;

namespace Business.Models;

public class UserModel : Record
{
    #region Properties copied from the related entity
    [DisplayName("User Name")]
    [Required(ErrorMessage = "{0} is required!")]
    [MinLength(3, ErrorMessage = "{0} must be minimum {1} characters!")]
    [MaxLength(10, ErrorMessage = "{0} must be maximum {1} characters!")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [StringLength(8, MinimumLength = 3, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
    public string Password { get; set; }

    [DisplayName("Active")]
    public bool IsActive { get; set; }

    public Statuses Status { get; set; }

    [DisplayName("Role")]
    [Required(ErrorMessage = "{0} is required!")]
    public int? RoleId { get; set; }
    #endregion

    #region Extra properties required for the views
    [DisplayName("Active")]
    public string IsActiveOutput { get; set; }

    [DisplayName("Role")]
    public string RoleNameOutput { get; set; }

    [DisplayName("Password")]
    public string PasswordOutput { get; set; }
    #endregion
}