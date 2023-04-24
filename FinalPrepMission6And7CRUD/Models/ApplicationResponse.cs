using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrepMission6And7CRUD.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Phone { get; set; }
        public bool CreeperStalker { get; set; }

        //Build Foreign Key Relationship
        public int MajorId { get; set; } //first list primary key in the Major table (see "Major" model)
        public Major Major { get; set; } //this is making an instance of type "Major" (see "Major" model) 7 min into vid
    }
}
