namespace TestTask
{
    public struct Contact
    {
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }

        public Contact(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
        
        public static bool operator==(Contact a, Contact b)
        {
            return a.FullName == b.FullName && a.PhoneNumber == b.PhoneNumber;
        }

        public static bool operator!=(Contact a, Contact b)
        {
            return !(a == b);
        }
    }
}

