namespace FullApi.Data.Repository
{
	public class RepoResponse<T> where T : class
	{
		public T? Result { get; set; }
		public bool Success { get; set; }
		public RepoResponseCode StatusCode { get; set; }
		public string? Message { get; set; }
	}

	public class PagedRepoResponse<T> : RepoResponse<T> where T : class
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int TotalRecords { get; set; }
		public bool HasPreviousPage { get; set; }
		public bool HasNextPage { get; set; }
	}
}
