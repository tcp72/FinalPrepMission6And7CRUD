using FinalPrepMission6And7CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrepMission6And7CRUD.Controllers
{
    public class HomeController : Controller
    {
        //private dateapplicationContext instance named that that we can get and set
        //it's an instance of dbcontext class
        private DateApplicationContext DaContext { get; set; } //da for date application

        //constructor
        public HomeController(DateApplicationContext someName)
        {
            DaContext = someName;//just know we're getting info from context file into controller, and this is how we do it
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] //when we get the form
        public IActionResult DatingApplication ()
        //could've named this FillOutAPplication as long as change asp-action in view
        //if change the name of the return View("DatingApplication"); below
        {
            ViewBag.BlahMajors = DaContext.Majors.ToList(); //example he just did "Majors"

            return View(); //ViewBag.BlahMajors is automatically set
        }

        [HttpPost] //post and this receiveds the information passed in
        public IActionResult DatingApplication(ApplicationResponse ar)
            //create an instance of application response (from the model) and catch all of the info that's coming in
        {
            DaContext.Add(ar); //this adds the data from ApplicationResponse to the context file
            DaContext.SaveChanges(); //this actually saves the data to the context file (which then saves it to the db)

            return View("Confirmation", ar); //this is passing to the view for when we submit the form the model
            //so we can use it in our confirmation message (see video 7 UsingTheModel)
        }

        public IActionResult WaitList ()
        {
            //go to the DaContext (gives access to database, Responses table. Put it to a list we can use)
            //later we'll use ienumerable and iqueryable that is another object that tried to improve
            //upon just a standard list
            var applications = DaContext.Responses
                .Include(x => x.Major) //need to click lightbult for "Include"
                .Where(blah => blah.CreeperStalker == false) //this is where we only pass the non CreeperStalkers
                .OrderBy(x => x.LastName) //this is where we do alphabetical 
                .ToList(); //here is where you'd do .Where()etc.

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.BlahMajors = DaContext.Majors.ToList(); //example he just did "Majors". This populates the list of majors

            var application = DaContext.Responses.Single(x => x.ApplicationId == applicationid); 
            //to populate the data in the form; get a single record that has the application id that passed
            //in the URL; "Responses" is the dbset created in the context file

            return View("DatingApplication", application);  //ViewBag.BlahMajors is automatically set and not need pass;
            //pass the "application" single record that we want to edit and was passed in URL
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {
            DaContext.Update(blah); //update changes based on info passed in
            DaContext.SaveChanges(); //save those changes

            return RedirectToAction("WaitList"); //send user to WaitList Action and load the data needed to make page display
        }

        public IActionResult Delete ()
        {
            return View();
        }

        //public IActionResult DatingApplication()
        //{


        //    return View
        //}
       
    }
}
