namespace HarryPotterApi.ValueObjects
{
    public record Paginator(int Skip, int Take, int Page, int TotalPages);
    
}
