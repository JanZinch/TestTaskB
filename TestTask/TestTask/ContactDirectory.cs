namespace TestTask
{
    public class ContactDirectory
    {
        private Dictionary<int, List<Contact>> _contactsTable = new Dictionary<int, List<Contact>>();
        
        private static int GetFullNameHash(string fullName)
        {
            return fullName.Select<char, int>(character => (int)character).Sum();
        }

        public bool AddContact(Contact newContact)
        {
            int newContactHash = GetFullNameHash(newContact.FullName);

            if (_contactsTable.TryGetValue(newContactHash, out List<Contact>? collidedContacts))
            {
                int index = collidedContacts.FindIndex(c => c.FullName == newContact.FullName);

                if (index != -1)
                {
                    return false;
                }
                else
                {
                    collidedContacts.Add(newContact);
                    return true;
                }
            }
            else
            {
                _contactsTable.Add(newContactHash, new List<Contact>() { newContact });
                return true;
            }
        }

        public bool RemoveContact(string fullName)
        {
            int fullNameHash = GetFullNameHash(fullName);
            
            if (_contactsTable.TryGetValue(fullNameHash, out List<Contact>? collidedContacts))
            {
                if (collidedContacts.Count == 1 && collidedContacts[0].FullName == fullName)
                {
                    return _contactsTable.Remove(fullNameHash);
                }
                else
                {
                    int index = collidedContacts.FindIndex(c => c.FullName == fullName);

                    if (index != -1)
                    {
                        collidedContacts.RemoveAt(index);
                        return true;
                    }
                }
            }

            return false;
        }
        
        public string GetPhoneNumber(string fullName)
        {
            if (_contactsTable.TryGetValue(GetFullNameHash(fullName), out List<Contact>? collidedContacts))
            {
                Contact contact = collidedContacts.Find(c => c.FullName == fullName);
                return contact != default ? contact.PhoneNumber : null;
            }
            
            return null;
        }

        public bool RewritePhoneNumber(string fullName, string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }
            
            if (_contactsTable.TryGetValue(GetFullNameHash(fullName), out List<Contact>? collidedContacts))
            {
                int index = collidedContacts.FindIndex(c => c.FullName == fullName);

                if (index != -1)
                {
                    collidedContacts[index] = new Contact(fullName, phoneNumber);
                    return true;
                }
            }
            
            return false;
        }

    }
}