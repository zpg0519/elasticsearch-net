using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<TermsAggregation>))]
	public interface ITermsAggregation : IBucketAggregation
	{
		[JsonProperty("collect_mode")]
		TermsAggregationCollectMode? CollectMode { get; set; }

		[JsonProperty("exclude")]
		TermsExclude Exclude { get; set; }

		[JsonProperty("execution_hint")]
		TermsAggregationExecutionHint? ExecutionHint { get; set; }

		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("include")]
		TermsInclude Include { get; set; }

		[JsonProperty("min_doc_count")]
		int? MinimumDocumentCount { get; set; }

		[JsonProperty("missing")]
		object Missing { get; set; }

		[JsonProperty("order")]
		IList<TermsOrder> Order { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }

		[JsonProperty("shard_size")]
		int? ShardSize { get; set; }

		[JsonProperty("show_term_doc_count_error")]
		bool? ShowTermDocCountError { get; set; }

		[JsonProperty("size")]
		int? Size { get; set; }
	}

	public class TermsAggregation : BucketAggregationBase, ITermsAggregation
	{
		internal TermsAggregation() { }

		public TermsAggregation(string name) : base(name) { }

		public TermsAggregationCollectMode? CollectMode { get; set; }
		public TermsExclude Exclude { get; set; }
		public TermsAggregationExecutionHint? ExecutionHint { get; set; }
		public Field Field { get; set; }
		public TermsInclude Include { get; set; }
		public int? MinimumDocumentCount { get; set; }
		public object Missing { get; set; }
		public IList<TermsOrder> Order { get; set; }
		public IScript Script { get; set; }
		public int? ShardSize { get; set; }
		public bool? ShowTermDocCountError { get; set; }
		public int? Size { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Terms = this;
	}

	public class TermsAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<TermsAggregationDescriptor<T>, ITermsAggregation, T>, ITermsAggregation
		where T : class
	{
		TermsAggregationCollectMode? ITermsAggregation.CollectMode { get; set; }

		TermsExclude ITermsAggregation.Exclude { get; set; }

		TermsAggregationExecutionHint? ITermsAggregation.ExecutionHint { get; set; }
		Field ITermsAggregation.Field { get; set; }

		TermsInclude ITermsAggregation.Include { get; set; }

		int? ITermsAggregation.MinimumDocumentCount { get; set; }

		object ITermsAggregation.Missing { get; set; }

		IList<TermsOrder> ITermsAggregation.Order { get; set; }

		IScript ITermsAggregation.Script { get; set; }

		int? ITermsAggregation.ShardSize { get; set; }

		bool? ITermsAggregation.ShowTermDocCountError { get; set; }

		int? ITermsAggregation.Size { get; set; }

		public TermsAggregationDescriptor<T> CollectMode(TermsAggregationCollectMode? collectMode) =>
			Assign(a => a.CollectMode = collectMode);

		public TermsAggregationDescriptor<T> Exclude(string excludePattern) =>
			Assign(a => a.Exclude = new TermsExclude(excludePattern));

		public TermsAggregationDescriptor<T> Exclude(IEnumerable<string> values) =>
			Assign(a => a.Exclude = new TermsExclude(values));

		public TermsAggregationDescriptor<T> ExecutionHint(TermsAggregationExecutionHint? executionHint) =>
			Assign(a => a.ExecutionHint = executionHint);

		public TermsAggregationDescriptor<T> Field(Field field) => Assign(a => a.Field = field);

		public TermsAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(a => a.Field = field);

		public TermsAggregationDescriptor<T> Include(long partition, long numberOfPartitions) =>
			Assign(a => a.Include = new TermsInclude(partition, numberOfPartitions));

		public TermsAggregationDescriptor<T> Include(string includePattern) =>
			Assign(a => a.Include = new TermsInclude(includePattern));

		public TermsAggregationDescriptor<T> Include(IEnumerable<string> values) =>
			Assign(a => a.Include = new TermsInclude(values));

		public TermsAggregationDescriptor<T> MinimumDocumentCount(int? minimumDocumentCount) =>
			Assign(a => a.MinimumDocumentCount = minimumDocumentCount);

		public TermsAggregationDescriptor<T> Missing(object missing) => Assign(a => a.Missing = missing);

		public TermsAggregationDescriptor<T> Order(Func<TermsOrderDescriptor<T>, IPromise<IList<TermsOrder>>> selector) =>
			Assign(a => a.Order = selector?.Invoke(new TermsOrderDescriptor<T>())?.Value);

		public TermsAggregationDescriptor<T> Script(string script) => Assign(a => a.Script = (InlineScript)script);

		public TermsAggregationDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(a => a.Script = scriptSelector?.Invoke(new ScriptDescriptor()));

		public TermsAggregationDescriptor<T> ShardSize(int? shardSize) => Assign(a => a.ShardSize = shardSize);

		public TermsAggregationDescriptor<T> ShowTermDocCountError(bool? showTermDocCountError = true) =>
			Assign(a => a.ShowTermDocCountError = showTermDocCountError);

		public TermsAggregationDescriptor<T> Size(int? size) => Assign(a => a.Size = size);
	}
}
