using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Repository
{
  public interface IContactRepository
  {
    void Add(Contact contact);
    IEnumerable<Contact> GetAll();
    Contact Find(string key);
    void Remove(string id);
    void Update(Contact contact);
  }
}
