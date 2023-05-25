namespace TestTask
{
    public class ContactDirectory
    {
        private Dictionary<int, Tuple<string, string>> _contacts = new Dictionary<int, Tuple<string, string>>();

        private const int HashConstant = 13;

        private static int GetFullNameHash(string fullName)
        {
            int hashCode = 0;

            for (int i = 0; i < fullName.Length; i++)
            {
                hashCode += fullName[i] * (int)Math.Pow(HashConstant, i);
            }

            return hashCode;
        }

        public bool AddContact(string fullName, string phoneNumber)
        {
            return _contacts.TryAdd(GetFullNameHash(fullName), new Tuple<string, string>(fullName, phoneNumber));
        }

        public bool RemoveContact(string fullName)
        {
            return _contacts.Remove(GetFullNameHash(fullName));
        }
        
        public string GetPhoneNumber(string fullName)
        {
            _contacts.TryGetValue(GetFullNameHash(fullName), out Tuple<string, string> contactData);

            return contactData != null ? contactData.Item2 : null;
        }

        public bool RewritePhoneNumber(string fullName, string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            int fullNameHash = GetFullNameHash(fullName);
            
            if (_contacts.ContainsKey(fullNameHash))
            {
                _contacts[fullNameHash] = new Tuple<string, string>(fullName, phoneNumber);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}