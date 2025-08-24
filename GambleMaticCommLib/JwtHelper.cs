
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace GambleMaticCommLib
{
    public class JwtHelper
    {
        private readonly IConfiguration _config;
        private readonly string JWT_ISSUER;
        private readonly string JWT_AUDIENCE;
        private readonly string JWT_SECRET_KEY;
        private readonly int JWT_EXPIRY_HOURS;

        public const string JWT_AUTORIZATION_POLICY = "RequireJwtToAccessGamblematicApi";
        public JwtHelper(IConfiguration config)
        {

            if ( config == null) throw new ArgumentNullException(nameof(config));

            JWT_ISSUER = config["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer");
            JWT_AUDIENCE = config["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience");
            JWT_SECRET_KEY = config["Jwt:SecretKey"] ?? throw new ArgumentNullException("Jwt:SecretKey");
            string? expiryHoursStr = config["Jwt:ExpiryHours"];
            if ( expiryHoursStr == null) throw new ArgumentNullException("Jwt:ExpiryHours");
            JWT_EXPIRY_HOURS = int.TryParse(expiryHoursStr, out int hours) ? hours : 1;
        }

        
        private string? _currentTokenString = null;
        private readonly ApiCommunicatorService _apiCommunicatorService;
        private JsonWebToken token;

        public async Task<string> GetTokenString()
        {

            DateTime now = DateTime.UtcNow;
            if ( now > token.ValidTo || now < token.ValidFrom)
            {
                //Token is expired, get a new one
                _currentTokenString = null;
                token = generateNewToken();
                _currentTokenString = token.ToString();
            }
            return _currentTokenString;
        }

        private JsonWebToken generateNewToken()
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECRET_KEY));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256Signature);

            Claim[] claims =
            {
                new Claim("serviceIdentifier", "GambleMaticCommLib"),
            };

            var tokenContents = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(JWT_EXPIRY_HOURS),
                SigningCredentials = credentials,
                Issuer = JWT_ISSUER,
                Audience = JWT_AUDIENCE
            };

            string jwtString = new JsonWebTokenHandler().CreateToken(tokenContents);
            JsonWebToken jsonWebToken = new JsonWebToken(jwtString);
            return jsonWebToken;

        }
    }





}
