using System.Threading.Tasks;
using ECommerce.Ordering.Application.Models;

namespace ECommerce.Ordering.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}