using System.ComponentModel.DataAnnotations;

namespace OnatrixCMS.ViewModels;

public class QuestionViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Must write a question")]
    [Display(Name = "Question")]
    public string Question { get; set; } = null!;
}
