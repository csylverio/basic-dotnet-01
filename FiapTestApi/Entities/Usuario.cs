using System;

namespace FiapTestApi.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public TipoPermissaoSistema PermissaoSistema { get; set; }
}

public enum TipoPermissaoSistema
{
    Adminstrador,
    UsuarioEspecial,
    UsuarioBasico,
    UsuarioLimitado
}

// Simula em memória simulando banco de dados de usuário
public static class ListaUsuario
{
    public static IList<Usuario> Usuarios { get; set; }
}