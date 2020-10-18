using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Model.Interfaces
{
    
    public interface IContactType
    {
        long ContactTypeId { get; set; }

        string Address { get; set; }

        string Telephone { get; set; }

        string Cell { get; set; }

        string Email { get; set; }
    }
}