
namespace WebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            this.Telefone = new HashSet<Telefone>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100)]
        public string NomeRazaoSocial { get; set; }

        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required]
        [StringLength(1)]
        public string Classificacao { get; set; }

        [StringLength(100)]
        public string CpfCnpj { get; set; }

        [Required]
        [StringLength(1)]
        public string TipoPessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
