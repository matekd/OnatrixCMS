using System.ComponentModel.DataAnnotations;

namespace OnatrixCMS.ViewModels;

public class SupportViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;
}
