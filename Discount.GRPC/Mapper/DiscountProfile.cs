using AutoMapper;
using Discount.Grpc.Protos;
using Discount.GRPC.Entitites;

namespace Discount.GRPC.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}