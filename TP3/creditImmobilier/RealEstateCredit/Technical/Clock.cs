using RealEstateCredit.Interfaces;

namespace RealEstateCredit.Technical
{
    internal class Clock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
