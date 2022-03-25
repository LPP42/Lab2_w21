using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_ef_2022.Pages;

public class PrivacyModel : PageModel
{

	public string Message { get; private set; } = "Message!";
	public string? Greeting { get; private set; }
	private readonly ILogger<PrivacyModel> _logger;

	public PrivacyModel(ILogger<PrivacyModel> logger)
	{
		_logger = logger;
	}

	public void OnGet()
	{
		Message += $" the time is {DateTime.Now}";
		Greeting = $"<a href=\"https://google.ca\">Google</a>";
	}


}

