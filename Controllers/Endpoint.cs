using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace Hng_Task_1.Controllers
{
        [Route("api")]
        [ApiController]
        public class ApiController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get([FromQuery] string slack_name = "Mims", [FromQuery] string track = "Backend")

            {
                try
                {
                    //Get the current UTC time with proper formatting
                    DateTime utcNow = DateTime.UtcNow;
                    string utcTime = utcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

                    //Calculate the current day of the week
                    string currentDay = DateTime.Now.ToString("dddd");

                    // Construct the JSON response
                    var response = new
                    {
                        slack_name,
                        current_day = currentDay,
                        utc_time = utcTime,
                        track,
                        github_file_url = "https://github.com/Mims70/HNG-task/tree/main/Stage%201%20Task/Stage%201%20Task",
                        github_repo_url = "https://github.com/Mims70/HNG-task.git",
                        status_code = 200,



                    };
                    //Return the JSON response
                    return Ok(response);

                }
                catch (Exception ex)
                {
                    // Handle any exception and return an error response if necessary
                    return StatusCode(500, new { error = ex.Message });
                }
            }
        }
}
