using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FiapTestApi.Entities;
using Microsoft.IdentityModel.Tokens;

namespace FiapTestApi.Authentication;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public string GetToken(Usuario usuario)
    {
        var usuarioExiste = ListaUsuario.Usuarios.Any(x => usuario.Username.Equals(x.Username) && usuario.Password.Equals(x.Password));
        if (!usuarioExiste) {
            return string.Empty;
        }

        usuario = ListaUsuario.Usuarios.First(x => usuario.Username.Equals(x.Username) && usuario.Password.Equals(x.Password));
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJWT"));
        var tokenProperties = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.PermissaoSistema.ToString()),
                new Claim("ClaimPersonalizada", "Conteúdo Personalizado")
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenProperties);
        return tokenHandler.WriteToken(token);
    }
}
