﻿using SuntechIT.Demo.Domain.Entities.Customers;

namespace SuntechIT.Demo.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
    }
}
