using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrepMission6And7CRUD.Models
{
    public class Major
    {
        [Key]
        [Required]
        public int MajorId { get; set; }
        public string MajorName { get; set; }
    }
}
