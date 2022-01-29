using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.ViewModels;
using LuckySpin.Services;
using System.Globalization;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        private RepositoryService repoService;

         //  --------------------------------- Constructor -  with RepositoryService DIJ -----------------------------
        public SpinnerController(RepositoryService repoService)
        {
            this.repoService = repoService;
        }

         // ---------------------------------------------- Index Action ----------------------------------------------
        [HttpGet]
        public IActionResult Index()
        {
            return View(); //Sends the empty Index form
        }

        [HttpPost]
        public IActionResult Index(Player player, IndexViewModel indexViewModel) //TODO: Update Index() to receive form data as IndexViewModel
        {
            if (!ModelState.IsValid) { return View(); } //Check for missing data

            repoService.Player = new Player //adds Player data to store in the repoService
            {
                FirstName = indexViewModel.FirstName,
                balance = indexViewModel.StartoutCash,
                Luck = indexViewModel.PlayerLuck,
            };

            return RedirectToAction("Spin");
        }

        
         // ---------------------------------------------- Spin Action -----------------------------------------------

        public IActionResult Spin() //Start a Spin WITHOUT data
        {
            //CHARGE 
            // TODO: Load Player balance from the repoService

            decimal balance;
            //balance =4.5;
            //TODO: Charge $0.50 to spin


            //SPIN
            //TODO: Complete adding data to a new SpinViewModel to gather items for the View

            SpinViewModel spinVM = new SpinViewModel
            {
                //CurrentBalance = string.Format(new CultureInfo("en-SG", false), "{0:C2}", balance),
            };

            //GAMEPLAY
            //TODO: Check the Balance to see if the game is over
            if (balance < 0) {
                // end game somehow
            } else if (true/* Spin.iswinning?*/) { 
                balance -= 0;
            }else
                balance -= 0;
            //TODO: Pay $1.00 if Winning


            //UPDATE DATA STORE
            //TODO: Save balance to repoService
            repoService.Player = new Player
            {
                balance = balance,
            };

            //TODO: Use the repoService to add a spin to the repository


            return View("Spin", spinVM);
        }

        //TODO: BONUS:  the LuckList
        
        //--------------------------------------------- LuckList Action ----------------------------------------------
        
        [HttpGet]
        public IActionResult LuckList()
        {
            return new ContentResult { Content = "<h1>Luck's Run Out</h1>", ContentType = "text/html" };
        }

    }
}