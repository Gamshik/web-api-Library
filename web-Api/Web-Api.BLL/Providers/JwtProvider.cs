using Contracts.Providers;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web_Api.BLL.Providers
{
    public class JwtProvider : IJwtProvider
    {
        private readonly UserManager<User> _userManager;
        private readonly string? _securityKey;
        private readonly string? _issuer;
        private readonly string? _audience;
        private readonly string? _expiry;
        public JwtProvider(IConfiguration configuration, UserManager<User> userManager)
        {
            var jwtSetting = configuration.GetSection("JwtSetting");

            _securityKey = jwtSetting.GetSection("SecurityKey").Value;
            _issuer = jwtSetting.GetSection("Issuer").Value;
            _audience = jwtSetting.GetSection("Audience").Value;
            _expiry = jwtSetting.GetSection("ExpiryInMinutes").Value;

            if (_securityKey == null || _issuer == null || _audience == null || _expiry == null)
            {
                throw new ArgumentNullException(nameof(jwtSetting));
            }

            _userManager = userManager;
        }

        public async Task<Jwt?> CreateJwtAsync(User user, CancellationToken cancellationToken = default)
        {
            var claims = await GetClaimsAsync(user, cancellationToken);
            var signingCredentials = GetSigningCredentials();
            var tokenOptions = GenerateTokenOptions(claims, signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new Jwt { Token = token };
        }

        private async Task<List<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken = default)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
        }
        private JwtSecurityToken GenerateTokenOptions(List<Claim> listClaims, SigningCredentials signingCredentials)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: listClaims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_expiry)),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }
    }
}
