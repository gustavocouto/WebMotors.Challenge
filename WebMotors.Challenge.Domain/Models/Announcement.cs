namespace WebMotors.Challenge.Domain.Models
{
    public class Announcement
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Comments { get; set; }
    }
}