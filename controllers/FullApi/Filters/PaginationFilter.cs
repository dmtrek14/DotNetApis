namespace FullApi.Filters
{
	/// <summary>
	/// Provides a default page size of 25 and max page size of 50 and validates page number/size input. 
	/// If inputs are not valid (e.g., page number of -1 or page size exceeding min), they are set to valid values
	/// </summary>
	public class PaginationFilter
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public PaginationFilter()
		{
			this.PageNumber = 1;
			this.PageSize = 25;
		}
		public PaginationFilter(int pageNumber, int pageSize)
		{
			this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
			this.PageSize = pageSize > 50 ? 50 : pageSize;
		}
	}
}
