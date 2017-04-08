using Source.Models;

namespace Source.Services
{
    public interface IOrderProcessor
    {
        Order CompleteOrder(Cart cart);
    }
}