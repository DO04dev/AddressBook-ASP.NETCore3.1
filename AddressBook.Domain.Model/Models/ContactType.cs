using AddressBook.Domain.Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Model.Models
{
    [Table("ContactTypes", Schema = "dbo")]
    public class ContactType : IContactType
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ContactTypeId { get; set; }

        [Required]
        public virtual string Address { get; set; }
        
        [Required, StringLength(15)]
        public virtual string Telephone { get; set; }

        [Required, StringLength(15)]
        public virtual string Cell { get; set; }

        [Required, StringLength(500)]
        public virtual string Email { get; set; }
    }
}
