using System;

namespace SharedKernel.Model
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }

        public Customer(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
