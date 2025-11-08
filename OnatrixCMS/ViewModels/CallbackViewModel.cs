using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace OnatrixCMS.ViewModels;

public class CallbackViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    [Display(Name = "Phone")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Must select an option")]
    public string SelectedOption { get; set; } = null!;


    [BindNever]
    public IEnumerable<string> Options { get; set; } = []; 

    [BindNever]
    public bool IsMainSubmitButton { get; set; } = true;
}
