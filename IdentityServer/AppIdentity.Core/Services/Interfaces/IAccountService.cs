﻿using System.Threading.Tasks;
using AppIdentity.Core.ViewModels.Account;

namespace AppIdentity.Core.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl);
        Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model);
        Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId);
        Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId);
    }
}