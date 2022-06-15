using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

/// <summary>
/// Basic implementation of AuthenticationStateProvider
/// </summary>
public class LocalAuthenticationStateProvider : AuthenticationStateProvider
{
  /// <summary>
  /// Creates an instance of the type.
  /// </summary>
  public LocalAuthenticationStateProvider()
  {
    SetPrincipal(new ClaimsPrincipal());
  }

  private AuthenticationState AuthenticationState { get; set; } = 
    new AuthenticationState(new ClaimsPrincipal());

  /// <summary>
  /// Gets the authentication state.
  /// </summary>
  /// <returns></returns>
  public override Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    return Task.FromResult(AuthenticationState);
  }

  /// <summary>
  /// Sets the principal representing the current user identity.
  /// </summary>
  /// <param name="principal">ClaimsPrincipal instance</param>
  public void SetPrincipal(ClaimsPrincipal principal)
  {
    AuthenticationState = new AuthenticationState(principal);
    NotifyAuthenticationStateChanged(Task.FromResult(AuthenticationState));
  }
}