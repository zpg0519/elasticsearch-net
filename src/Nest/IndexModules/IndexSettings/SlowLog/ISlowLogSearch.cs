using System;

namespace Nest
{
	public interface ISlowLogSearch
	{
		ISlowLogSearchFetch Fetch { get; set; }
		LogLevel? LogLevel { get; set; }
		ISlowLogSearchQuery Query { get; set; }
	}

	public class SlowLogSearch : ISlowLogSearch
	{
		public ISlowLogSearchFetch Fetch { get; set; }

		public LogLevel? LogLevel { get; set; }

		public ISlowLogSearchQuery Query { get; set; }
	}

	public class SlowLogSearchDescriptor : DescriptorBase<SlowLogSearchDescriptor, ISlowLogSearch>, ISlowLogSearch
	{
		ISlowLogSearchFetch ISlowLogSearch.Fetch { get; set; }
		LogLevel? ISlowLogSearch.LogLevel { get; set; }
		ISlowLogSearchQuery ISlowLogSearch.Query { get; set; }

		/// <inheritdoc />
		public SlowLogSearchDescriptor Fetch(Func<SlowLogSearchFetchDescriptor, ISlowLogSearchFetch> selector) =>
			Assign(a => a.Fetch = selector?.Invoke(new SlowLogSearchFetchDescriptor()));

		/// <inheritdoc />
		public SlowLogSearchDescriptor LogLevel(LogLevel? level) => Assign(a => a.LogLevel = level);

		/// <inheritdoc />
		public SlowLogSearchDescriptor Query(Func<SlowLogSearchQueryDescriptor, ISlowLogSearchQuery> selector) =>
			Assign(a => a.Query = selector?.Invoke(new SlowLogSearchQueryDescriptor()));
	}
}
