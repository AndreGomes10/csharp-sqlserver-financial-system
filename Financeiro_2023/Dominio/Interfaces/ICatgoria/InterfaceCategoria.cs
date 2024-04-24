using Dominio.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.ICatgoria
{
    public interface InterfaceCategoria : InterfaceGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario);  // vai retornar uma lista de categoria
    }
}
