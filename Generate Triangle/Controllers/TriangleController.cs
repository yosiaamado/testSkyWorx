using Microsoft.AspNetCore.Mvc;

namespace Generate_Triangle.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TriangleController : ControllerBase
	{

		private readonly ILogger<TriangleController> _logger;

		public TriangleController(ILogger<TriangleController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public ActionResult<string> GenerateTriangle(string number)
		{
			if (number == "")
			{
				return BadRequest("Please input a positive number");
			}

			string result = "";
			for(int i = 0; i < number.Length; i++)
			{
				double lineResult = Convert.ToInt32(number.Substring(i, 1)) * Math.Pow(10, i + 1);
				result += lineResult.ToString() + '\n';
			}

			return Ok(result);
		}
	}
}