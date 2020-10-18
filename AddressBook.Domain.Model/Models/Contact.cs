using AddressBook.Domain.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Model.Models
{
    [Table("Contacts", Schema ="dbo")]
    public class Contact : IContact
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ContactId { get; set; }

        [Required, StringLength(100)]
        public virtual string FirstName { get; set; }
       
        [Required, StringLength(100)]
        public virtual string Surname { get; set; }

        [Required]
        public virtual DateTime BirthDate { get; set; }
        
        [Required, DefaultValue("SYSDATETIME")]
        public virtual DateTime UpdatedDate { get; set; }
    }
}