using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Infra;
using RizzGamingBase.Models.ViewModels;
using System;

namespace RizzGamingBase.Models.Exts
{
    public static class RegisterExts
    {
        public static Developer ToEFModel(this RegisterVm vm)
        {
            var salt = HashUtility.GetSalt();
            var hashPassword = HashUtility.ToSHA256(vm.Password, salt);
            var confirmCode = Guid.NewGuid().ToString("N");

            return new Developer
            {
                Id = vm.Id,
                Account = vm.Account,
                EncryptedPassword = hashPassword,
                EMail = vm.EMail,
                Name = vm.Name,
                PhoneNumber = vm.PhoneNumber,
                ConfirmCode = confirmCode,
                IsConfirmed = false, // 初始狀態，帳戶未確認
                
            };
        }

    }
}