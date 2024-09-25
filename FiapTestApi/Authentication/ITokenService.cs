using System;
using FiapTestApi.Entities;

namespace FiapTestApi.Authentication;

public interface ITokenService
{
    public string GetToken(Usuario usuario);
}
