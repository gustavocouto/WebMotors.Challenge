using System;
using System.ComponentModel.DataAnnotations;

namespace WebMotors.Challenge.ViewModels
{
    public class AnnouncementViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Version { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Year { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        public string Comments { get; set; }
    }
}