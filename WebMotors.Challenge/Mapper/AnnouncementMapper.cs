using WebMotors.Challenge.Domain.Models;
using WebMotors.Challenge.ViewModels;

namespace WebMotors.Challenge.Mapper
{
    public class AnnouncementMapper
    {
        public static Announcement Map(AnnouncementViewModel vm)
        {
            return new Announcement
            {
                ID = vm.ID,
                Comments = vm.Comments,
                Make = vm.Make,
                Mileage = vm.Mileage,
                Model = vm.Model,
                Version = vm.Version,
                Year = vm.Year
            };
        }
    }
}