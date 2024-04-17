using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_task_Final.Models
{
    public class Room
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public int NumberOfPerson { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public string RoomType { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int TotalHours { get; set; }
        public int TotalDays { get; set; }
    }
}
