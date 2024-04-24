using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Categoria")]
    public class Categoria : Base
    {
        /* foreignkey */
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }

        // comentar essa linha abaixo depois de rodar o migration, senão toda vez que adicionar uma despesa ele vai tentar criar
        // uma categoria nova

        // public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
        /* foreignkey */
    }
}
