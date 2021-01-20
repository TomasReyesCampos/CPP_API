using CPP.Entities.Data;
using CPP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface IUsuarioRepostory
    {
        Task<UsuarioDto[]> GetUsuarios();

        Task<Usuario> GetUsuarioById(int usuario_id);

        Task<Usuario> GetUsuarioByName(string user_name);

        Task<AuthUserViewModel> AuthenticateUser(string user_name, string password);

    }
}
