using System.Threading.Tasks;
using Discount.GRPC.Entitites;

namespace Discount.GRPC.Repository
{
    public interface IDiscountRepository
    {
         Task<Coupon> GetDiscount(string productName);
         Task<bool> CreateDiscount(Coupon coupon);
         Task<bool> UpdateDiscount(Coupon coupon);
         Task<bool> DeleteDiscount(string productName);
    }
}