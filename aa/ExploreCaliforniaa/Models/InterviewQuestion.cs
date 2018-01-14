using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCaliforniaa.Models
{
    public class InterviewQuestion
    {
        public long Id { get; set; }

        public string Questionn { get; set; }

        public string Answer { get; set; }

        public int interview_id { get; set; }
    }
}
