using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.ViewModels;

namespace RizzGamingBase.Models.Exts
{
    public static class DeveloperExt
	{
        public static EditProfileVm ToEditProfileVm(this Developer  developer)
        {
            return new EditProfileVm
            {
                Id = developer.Id,
                Name = developer.Name,
                EMail = developer.EMail,
                PhoneNumber = developer.PhoneNumber

            };
        }
    }
}