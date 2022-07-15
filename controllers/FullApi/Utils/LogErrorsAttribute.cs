using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace FullApi.Utils
{
	public class LogErrorsAttribute : ExceptionFilterAttribute
	{
		public override async Task OnExceptionAsync(ExceptionContext context)
		{
			if (context.Exception != null)
			{
				LogManager.GetCurrentClassLogger().Error(context.Exception);
			}
		}
	}
}
