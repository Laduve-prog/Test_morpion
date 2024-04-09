using RealEstateCredit.Interfaces;

namespace RealEstateCreditTest.Fixtures
{
    public class FakeClock : IClock
    {
        private readonly DateTime fakeDateTime;
        public FakeClock(DateTime fakeDateTime)
        {
            this.fakeDateTime = fakeDateTime;
        }

        public DateTime Now => fakeDateTime;
    }
}
