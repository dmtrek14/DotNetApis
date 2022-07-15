using FullApi.Data.Repository;

namespace FullApi.Utils
{
	public class RepoResponseFactory
	{
		public static RepoResponse<T> CreateResponse<T>(bool success, RepoResponseCode statusCode, string? message = null, T? data = null) where T : class
		{
			return new RepoResponse<T>
			{
				Success = success,
				Message = message,
				Result = data,
				StatusCode = statusCode
			};
		}

		public static PagedRepoResponse<T> CreatePagedResponse<T>(bool success, RepoResponseCode statusCode, int totalResults, string? message = null, T? data = null, int pageNumber = 1, int pageSize = 25) where T : class
		{
			var totalPages = Convert.ToInt32(Math.Ceiling((double)totalResults / (double)pageSize));
			bool hasNext = false;
			bool hasPrevious = false;
			if (pageNumber >= 1 && pageNumber < totalPages)
			{
				hasNext = true;
			}
			if (pageNumber - 1 >= 1 && pageNumber <= totalPages)
			{
				hasPrevious = true;
			}
			return new PagedRepoResponse<T>
			{
				Success = success,
				Message = message,
				Result = data,
				StatusCode = statusCode,
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalPages = totalPages,
				TotalRecords = totalResults,
				HasNextPage = hasNext,
				HasPreviousPage = hasPrevious
			};
		}
	}
}
