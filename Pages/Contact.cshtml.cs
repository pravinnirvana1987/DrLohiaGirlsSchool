using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DrLohiaGirlsSchool.Pages;
public class Enquiry
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Message is required")]
    public string Message { get; set; } = string.Empty;
}
public class ContactModel : PageModel
{
    [BindProperty]
    public Enquiry Enquiry { get; set; } = new();

    public string? SuccessMessage { get; set; }
    private readonly ILogger<ContactModel> _logger;

    public ContactModel(ILogger<ContactModel> logger)
    {
        _logger = logger;
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Here you can process the enquiry (e.g., save to DB, send email, etc.)

        SuccessMessage = "Thank you for your enquiry! We will get back to you soon.";
        ModelState.Clear();
        Enquiry = new Enquiry(); // Reset form

        return Page();
    }
    public void OnGet()
    {
    }
}

