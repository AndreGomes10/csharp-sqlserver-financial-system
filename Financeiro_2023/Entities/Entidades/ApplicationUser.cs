using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class ApplicationUser: IdentityUser  // definir como public
    {
        [Column("USER_CPF")]  // dar um nome pra coluna CPF
        public string CPF { get; set; }
    }
}
