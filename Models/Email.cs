using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
  public class Email
  {
    [Key]
    [DisplayName("Identificador")]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail não pode ser vazio ou nulo.")]
    [MaxLength(120, ErrorMessage = "E-mail deve ter no máximo 120 caracteres.")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
      ErrorMessage = "Formato válido \"exemplo@domino.com\"")]
    [DisplayName("Endereço de e-mail")]
    public string EmailAddress { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Data de criação não pode ser vazia ou nula.")]
    [DisplayName("Data de criação")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Data de atualização não pode ser vazia ou nula.")]
    [DisplayName("Data de atualização")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Identificador do contato não pode ser vazio ou nulo.")]
    [ForeignKey("ContactId")]
    [DisplayName("Identificador do contato")]
    public int ContactId { get; set; }
  }
}
