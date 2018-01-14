using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCaliforniaa.Models
{
    public class Interview
    {
        public long Id { get; set; }

        [Display(Name = "Gotten")]
        public bool Gotten { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Story { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date { get; set; }

        public int visa_ID { get; set; }
        public string visa_Name { get; set; }
    }
}
