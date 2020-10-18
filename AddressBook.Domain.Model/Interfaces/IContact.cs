using System;

namespace AddressBook.Domain.Model.Interfaces
{
    public interface IContact
    {
        long ContactId { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime BirthDate { get; set; }
        
        DateTime UpdatedDate { get; set; }
    }
}
