using ButtonGrid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ButtonGrid.Controllers
{
    public class ButtonController : Controller
    { 
        static List<ButtonModel> buttons = new List<ButtonModel>();

        string[] buttonImages = { 
            "blue.png",
            "black.png",
            "orange.png",
            "white.png"
        };

        int buttonCount = 25;

        public bool complete;

        public ButtonController()
        {
            if (buttons.Count != 0) return;

            for (int i = 0; i < buttonCount; i++)
            {
                int number = RandomNumberGenerator.GetInt32(0, 4);
                buttons.Add(new ButtonModel(i, number, buttonImages[number]));
            }

        }

        public IActionResult Index()
        {
            var viewModel = new ButtonViewModel
            {
                Buttons = buttons,
                Complete = CheckSimilar()
            };

            return View(viewModel);
        }

        public IActionResult ButtonClick(int id)
        {
            ButtonModel button = buttons.FirstOrDefault(b => b.Id == id);
            if (button == null) return View();

            button.buttonState = (button.buttonState + 1) % 4;
            button.buttonImage = buttonImages[button.buttonState];

            return RedirectToAction("Index");
        }

        public IActionResult PartialPageUpdate(int id)
        {
            ButtonModel button = buttons.FirstOrDefault(b => b.Id == id);
            if (button == null) return NotFound("Button not found.");

            button.buttonState = (button.buttonState + 1) % 4;
            button.buttonImage = buttonImages[button.buttonState];
            Console.WriteLine($"Button {id} updated. New State: {button.buttonState}");
            return PartialView("_Button", button);
        }

        public IActionResult RightClickPartialPageUpdate(int id)
        {
            ButtonModel button = buttons.FirstOrDefault(b => b.Id == id);
            if (button == null) return NotFound("Button not found.");

            button.buttonState = (button.buttonState + 3) % 4;
            button.buttonImage = buttonImages[button.buttonState];
            Console.WriteLine($"Button {id} updated. New State: {button.buttonState}");
            return PartialView("_Button", button);
        }

        public bool CheckSimilar()
        {
            if (buttons.Count <= 0) return false;

            int color = buttons[0].buttonState;
            for(int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].buttonState != color) return false;
            }

            return true;
        }
    }
}
