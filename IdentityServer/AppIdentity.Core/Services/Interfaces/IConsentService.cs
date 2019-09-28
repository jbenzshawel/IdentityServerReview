using System.Threading.Tasks;
using AppIdentity.Core.ViewModels.Consent;
using IdentityServer4.Models;

namespace AppIdentity.Core.Services.Interfaces
{
    public interface IAppConsentService
    {
        Task<ProcessConsentResult> ProcessConsent(ConsentInputModel model);
        Task<ConsentViewModel> BuildViewModelAsync(string returnUrl, ConsentInputModel model = null);

        ConsentViewModel CreateConsentViewModel(
            ConsentInputModel model, string returnUrl,
            AuthorizationRequest request,
            Client client, Resources resources);

        ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check);
        ScopeViewModel CreateScopeViewModel(Scope scope, bool check);
        ScopeViewModel GetOfflineAccessScope(bool check);
    }
}