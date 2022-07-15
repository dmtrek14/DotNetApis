namespace FullApi.Utils
{
	public static class CollectionsUtils
	{
		public static IQueryable<T> If<T>(
		this IQueryable<T> query,
		bool should,
		params Func<IQueryable<T>, IQueryable<T>>[] transforms)
		{
			return should
				? transforms.Aggregate(query,
					(current, transform) => transform.Invoke(current))
				: query;
		}

		public static IEnumerable<T> If<T>(
			this IEnumerable<T> query,
			bool should,
			params Func<IEnumerable<T>, IEnumerable<T>>[] transforms)
		{
			return should
				? transforms.Aggregate(query,
					(current, transform) => transform.Invoke(current))
				: query;
		}

		public static IEnumerable<T> Paged<T>(this IEnumerable<T> items, int pageNumber, int itemsPerPage)
		{
			return items.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
		}

		public static IQueryable<T> Paged<T>(this IQueryable<T> items, int pageNumber, int itemsPerPage)
		{
			return items.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
		}

		public static IList<T> Paged<T>(this IList<T> items, int pageNumber, int itemsPerPage)
		{
			return items.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();
		}
	}
}
