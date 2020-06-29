using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
  public class Contact
  {
    [Key]
    [DisplayName("Identificador")]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Primeiro nome não pode ser vazio ou nulo.")]
    [MaxLength(50, ErrorMessage = "Primeiro nome deve ter no máximo 50 caracteres.")]
    [DisplayName("Primeiro nome")]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Último nome não pode ser vazio ou nulo.")]
    [MaxLength(50, ErrorMessage = "Último nome deve ter no máximo 50 caracteres.")]
    [DisplayName("Último nome")]
    public string LastName { get; set; }

    [MaxLength(50, ErrorMessage = "Apelido deve ter no máximo 50 caracteres.")]
    [DisplayName("Apelido")]
    public string NickName { get; set; }

    [NotMapped]
    [DisplayName("Nome completo")]
    public string FullName
    {
      get
      {
        string fullName = $"{ FirstName } { LastName }";

        if (NickName != null && NickName != string.Empty)
          fullName += $" ({ NickName })";

        return fullName;
      }
    }

    [DisplayName("Data de aniversário")]
    public DateTime? BirthDate { get; set; }

    [MaxLength(100, ErrorMessage = "Empresa deve ter no máximo 100 caracteres.")]
    [DisplayName("Empresa")]
    public string Organization { get; set; }

    [MaxLength(50, ErrorMessage = "Cargo deve ter no máximo 50 caracteres.")]
    [DisplayName("Cargo")]
    public string Role { get; set; }

    [MaxLength(255, ErrorMessage = "Observações devem ter no máximo 255 caracteres.")]
    [DisplayName("Observações")]
    public string Notes { get; set; }

    [Required(ErrorMessage = "Favorito não pode ser nulo")]
    [DisplayName("Favorito")]
    public bool Favorite { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Data de criação não pode ser vazia ou nula.")]
    [DisplayName("Data de criação")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Data de atualização não pode ser vazia ou nula.")]
    [DisplayName("Data de atualização")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [DisplayName("Telefones")]
    public IEnumerable<Phone> Phones { get; set; }

    [DisplayName("E-mails")]
    public IEnumerable<Email> Emails { get; set; }
  }
}
