
namespace WebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    [Table("Telefone")]
    public partial class Telefone
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroTelefone { get; set; }

        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
