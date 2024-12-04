using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.ActivityTracker
{
    public class BaseActivityTracker
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }=DateTime.Now.Date;
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string OperationState { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
