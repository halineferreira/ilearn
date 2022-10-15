namespace ilearn_ui.domain.Dtos.Response
{
    public class SearchResponseDto<T>
    {
        public IEnumerable<T> Values { get; set; }
        //public long TotalCount { get; set; }
        //public long TotalActiveCount { get; set; }
    }
}
