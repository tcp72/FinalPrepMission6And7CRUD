using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrepMission6And7CRUD.Models
{
    public class DateApplicationContext : DbContext
    {
        //constructor. Method that doesn't return something
        //run this only the first time we build this class
        //when built, receive a list of options for this particular context file of type DateApplicationContext
        //and we're going to refer to this object as "options"
        //these also inherit from the parent base options class. DOn't worry if don't totally understand here
        public DateApplicationContext (DbContextOptions<DateApplicationContext> options) : base (options)
        {
            //leave blank for now
        }

        //use Dbset to store information, not a whole database
        //this Dbset is of type ApplicationResponse (remember our ApplicationResponse model!)
        //and we'll call this set of individual ApplicationResponses "responses"
        public DbSet<ApplicationResponse> Responses { get; set; } //we can get or set responses to the database
        public DbSet<Major> Majors { get; set; }//get/set a set of Major responses and called it "Majors"

        //******below is just for seeding the database ***
        //protected can be accessed by children
        protected override void OnModelCreating(ModelBuilder mb)
        {

            //this is for Major table
            mb.Entity<ApplicationResponse>().HasData(
                new Major { MajorId = 1, MajorName = "Information Systems" },
                new Major { MajorId = 2, MajorName = "Ancient Near Eastern Studies" },
                new Major { MajorId = 3, MajorName = "Accounting" },
                new Major { MajorId = 4, MajorName = "Actuarial Science" },
                new Major { MajorId = 5, MajorName = "Undeclared" }
            );

            //this is for the application response
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse //need to put everything from the model here, including id; JSON
                {
                    ApplicationId = 1,
                    FirstName = "Michael",
                    LastName = "Scott",
                    Age = 45, //not need quotes for ints
                    Phone = "555-555-5555",
                    MajorId = 4,
                    CreeperStalker = true //not need for boolean
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    FirstName = "John",
                    LastName = "Hills",
                    Age = 33, //not need quotes for ints
                    Phone = "444-555-5555",
                    MajorId = 5,
                    CreeperStalker = false //not need for boolean
                }
                );


        }
    }
}