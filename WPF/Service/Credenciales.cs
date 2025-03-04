using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DTOs;

namespace WPF_UI.Services
{
    public class Credenciales
    {
        private string? UserName;
        private string? Password;
        public string? Token { get; set; }

        public LoginDTO GetCredenciales()
        {
            return new LoginDTO
            {
                UserName = UserName,
                Password = Password
            };
        }

        public void SetCredenciales(LoginDTO loginDTO)
        {
            this.UserName = loginDTO.UserName;
            this.Password = loginDTO.Password;
        }

        public void BorrarCredenciales()
        {
            UserName = null;
            Password = null;
            Token = null;
        }

    }
}
