namespace HarryPotterApi.Domain.ValueObjects
{
    public class Pagination
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }

        public Pagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}