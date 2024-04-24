using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinanceiroServico
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaServico;
        public UsuarioSistemaFinanceiroServico(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro)
        {
            _interfaceUsuarioSistemaServico = interfaceUsuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _interfaceUsuarioSistemaServico.Add(usuarioSistemaFinanceiro);
        }
    }
}
