using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
         Task<CustomerCart> GetCartAsync(string CartId);
         Task<CustomerCart> UpdateCartAsync(CustomerCart Cart);
         Task<bool> DeleteCartAsync(string CartId);
    }
}