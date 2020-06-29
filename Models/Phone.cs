using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
  public class Phone
  {
    [Key]
    [DisplayName("Identificador")]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Telefone não pode ser vazio ou nulo.")]
    [MaxLength(15, ErrorMessage = "Telefone deve ter no máximo 15 caracteres.")]
    [RegularExpression(@"\(\d{2}\)\s\d{4,5}\-\d{4}",
      ErrorMessage = "Valid Formats: \"(00) 0000-0000\" or \"(00) 00000-0000\"")]
    [DisplayName("Número de Telefone")]
    public string PhoneNumber { get; set; }

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
