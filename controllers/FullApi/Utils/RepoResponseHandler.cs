using FullApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FullApi.Utils
{
	public static class RepoResponseHandler
	{
		public static ObjectResult CreateResult<T>(RepoResponse<T> response) where T : class
		{
			if (!response.Success)
			{
				return new ObjectResult(response.Message)
				{
					StatusCode = (int)response.StatusCode,
				};
			}
			return new ObjectResult(response.Result)
			{
				StatusCode = (int)response.StatusCode
			};
		}

		public static ObjectResult CreatePagedResult<T>(PagedRepoResponse<T> response) where T : class
		{
			if (!response.Success)
			{
				return new ObjectResult(response.Message)
				{
					StatusCode = (int)response.StatusCode,
				};
			}
			return new ObjectResult(response)
			{
				StatusCode = (int)response.StatusCode
			};
		}
	}
}
