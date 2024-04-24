using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken token;

        internal TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidTo => token.ValidTo;  // tempo que o token vai permanecer valido

        public string value => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}
