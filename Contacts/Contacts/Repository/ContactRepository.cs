using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Repository
{
  public class ContactRepository : IContactRepository
  {
    static List<Contact> _contacts = new List<Contact>();

    public void Add(Contact contact)
    {
      _contacts.Add(contact);
    }

    public Contact Find(string key)
    {
      return _contacts.Where(x => x.MobilePhone.Equals(key)).SingleOrDefault();
    }

    public IEnumerable<Contact> GetAll()
    {
      return _contacts;
    }

    public void Remove(string id)
    {
      Contact contact = _contacts.SingleOrDefault(x => x.MobilePhone.Equals(id));
      if (contact != null) _contacts.Remove(contact);
    }

    public void Update(Contact contact)
    {
      Contact existing = _contacts.SingleOrDefault(x => x.MobilePhone.Equals(contact.MobilePhone));
      if (existing != null)
      {
        existing.FirstName = contact.FirstName;
        existing.LastName = contact.LastName;
        existing.IsFamilyMember = contact.IsFamilyMember;
        existing.Company = contact.Company;
        existing.JobTitle = contact.JobTitle;
        existing.Email = contact.Email;
        existing.MobilePhone = contact.MobilePhone;
        existing.DateOfBirth = contact.DateOfBirth;
        existing.AnniversaryDate = contact.AnniversaryDate;
      }
    }
  }
}
