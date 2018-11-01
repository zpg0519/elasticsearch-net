using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	public interface IGraphExploreControls
	{
		[JsonProperty("sample_diversity")]
		SampleDiversity SampleDiversity { get; set; }

		[JsonProperty("sample_size")]
		int? SampleSize { get; set; }

		[JsonProperty("timeout")]
		Time Timeout { get; set; }

		[JsonProperty("use_significance")]
		bool? UseSignificance { get; set; }
	}

	public class GraphExploreControls : IGraphExploreControls
	{
		public SampleDiversity SampleDiversity { get; set; }

		public int? SampleSize { get; set; }

		public Time Timeout { get; set; }
		public bool? UseSignificance { get; set; }
	}

	public class GraphExploreControlsDescriptor<T> : DescriptorBase<GraphExploreControlsDescriptor<T>, IGraphExploreControls>, IGraphExploreControls
		where T : class
	{
		SampleDiversity IGraphExploreControls.SampleDiversity { get; set; }
		int? IGraphExploreControls.SampleSize { get; set; }
		Time IGraphExploreControls.Timeout { get; set; }
		bool? IGraphExploreControls.UseSignificance { get; set; }

		public GraphExploreControlsDescriptor<T> SamleDiversity(Field field, int? maxDocumentsPerValue) =>
			Assign(a => a.SampleDiversity = new SampleDiversity { Field = field, MaxDocumentsPerValue = maxDocumentsPerValue });

		public GraphExploreControlsDescriptor<T> SamleDiversity(Expression<Func<T, object>> field, int? maxDocumentsPerValue) =>
			Assign(a => a.SampleDiversity = new SampleDiversity { Field = field, MaxDocumentsPerValue = maxDocumentsPerValue });

		public GraphExploreControlsDescriptor<T> SampleSize(int? sampleSize) => Assign(a => a.SampleSize = sampleSize);

		public GraphExploreControlsDescriptor<T> Timeout(Time time) => Assign(a => a.Timeout = time);

		public GraphExploreControlsDescriptor<T> UseSignificance(bool? useSignificance = true) => Assign(a => a.UseSignificance = useSignificance);
	}
}
