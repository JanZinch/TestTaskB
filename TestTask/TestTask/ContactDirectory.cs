using System;
using System.Collections.Generic;

namespace TestTask
{
    public class ContactDirectory
    {
        private Dictionary<FullName, string> _contacts = new Dictionary<FullName, string>();
        
        public bool AddContact(FullName fullName, string phoneNumber)
        {
            return _contacts.TryAdd(fullName, phoneNumber);
        }

        public bool RemoveContact(FullName fullName)
        {
            return _contacts.Remove(fullName);
        }
        
        public string GetPhoneNumber(FullName fullName)
        {
            _contacts.TryGetValue(fullName, out string phoneNumber);
            return phoneNumber;
        }

        public bool RewritePhoneNumber(FullName fullName, string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            if (_contacts.ContainsKey(fullName))
            {
                _contacts[fullName] = phoneNumber;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}