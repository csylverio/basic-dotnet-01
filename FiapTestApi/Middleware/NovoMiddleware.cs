using System;
using FiapTestApi.Entities;

namespace FiapTestApi.Middleware;

public class NovoMiddleware
{
   private readonly RequestDelegate _next;

    public NovoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ListaUsuario.Usuarios =
        [
            new Usuario { Id = 1, Username = "Admin", Password = "Abc123", PermissaoSistema = TipoPermissaoSistema.Adminstrador},
            new Usuario { Id = 2, Username = "Fiap", Password = "Abc123", PermissaoSistema = TipoPermissaoSistema.UsuarioEspecial},
        ];

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public static class NovoMiddlewareExtensions
{
    public static IApplicationBuilder UseNovoMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NovoMiddleware>();
    }
}