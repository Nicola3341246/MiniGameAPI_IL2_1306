using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiniGameAPI_IL2_1306.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RockPaperScissorsController : ControllerBase
    {
        [HttpPost(Name = "GetRockPaperSissors")]
        public IActionResult RockPaperSissors(RockPaperSissorModel model)
        {

            string[] obtions = { "r", "p", "s"};
            Random rd = new Random();
            string pcItem = obtions[rd.Next(0, obtions.Length)];
            string win = "";

            switch (model.SelectedItem)
            {
                case "r":
                    switch (pcItem)
                    {
                        case "r":
                            win = "equ";
                            break;
                        case "p":
                            win = "lose";
                            break;
                        case "s":
                            win = "win";
                            break;
                        default:
                            break;
                    }
                    break;
                case "p":
                    switch (pcItem)
                    {
                        case "r":
                            win = "win";
                            break;
                        case "p":
                            win = "equ";
                            break;
                        case "s":
                            win = "lose";
                            break;
                        default:
                            break;
                    }
                    break;
                case "s":
                    switch (pcItem)
                    {
                        case "r":
                            win = "lose";
                            break;
                        case "p":
                            win = "win";
                            break;
                        case "s":
                            win = "equ";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    return BadRequest(new
                    {
                        title = "Wrong Input",
                        status = 69420,
                        Errors = new
                        {
                            SelectedItem = "For the field [SelectedItem], either [r], [p], or [s] is expected."
                        }
                    });
            }

            return Ok(new {
                userChoice = model.SelectedItem,
                pcChoice = pcItem,
                winner = win
            });
        }
    }
}
