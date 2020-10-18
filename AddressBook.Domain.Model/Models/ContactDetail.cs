using AddressBook.Domain.Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Model.Models
{
    [Table("ContactDetails", Schema = "dbo")]
    public class ContactDetail : IContactDetail
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ContactDetailId { get; set; }

        [Required, ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }

        [Required, StringLength(500)]
        public virtual string Description { get; set; }

        [Required, ForeignKey("ContactTypeId")]
        public virtual ContactType ContactType { get; set; }
    }
}
