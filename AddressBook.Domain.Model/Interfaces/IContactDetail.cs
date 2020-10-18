using AddressBook.Domain.Model.Models;

namespace AddressBook.Domain.Model.Interfaces
{
    public interface IContactDetail
    {
        long ContactDetailId { get; set; }

        Contact Contact { get; set; }

        string Description { get; set; }

        ContactType ContactType { get; set; }
    }
}