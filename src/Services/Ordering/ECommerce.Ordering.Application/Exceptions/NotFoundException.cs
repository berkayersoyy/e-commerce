using System;

namespace ECommerce.Ordering.Application.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name,object key):base($"Entity \"{name}\" ({key}) was not found.")
        {
            
        }
    }
}