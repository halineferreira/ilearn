using Swashbuckle.AspNetCore.Annotations;

namespace ilearn.Data
{
  [SwaggerSchema("Pagination Request Schema")]
  public class Pagination
  {
    public Pagination()
    {
      PageNumber = 1;
      PageSize = 30;
      SortBy = "Name";
      SortOrder = "asc";
    }

    [SwaggerParameter("Page Number")]
    public int PageNumber { get; set; }

    [SwaggerParameter("Page Size")]
    public int PageSize { get; set; }

    [SwaggerParameter("Sort By")]
    public string SortBy { get; set; }

    [SwaggerParameter("Sort Order")]
    public string SortOrder { get; set; }
  }
}
