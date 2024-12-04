using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.ActivityTracker
{
    public class ActivityTrackerResponseDTO:BaseActivityTracker
    {
        [Required]
        public string UserName { get; set; }
    }
}
