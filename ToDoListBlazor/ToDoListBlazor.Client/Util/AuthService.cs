using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ToDoListBlazor.Client.Util;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Client.Services
{

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
        }

        public async Task<Result> Register(RegisterRequest request)
        {
            return await _httpClient.PostJsonAsync<Result>("api/UserAccount", request);
        }

        public async Task<LoginResult> Login(LoginRequest request)
        {
            var result = await _httpClient.PostJsonAsync<LoginResult>("api/Login", request);

            if (result.Successful)
            {
                await SetupAuthentication(result);
            }

            return result;
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        private async Task SetupAuthentication(LoginResult result)
        {
            await _localStorageService.SetItemAsync("authToken", result.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
        }
    }
}
