﻿using Newtonsoft.Json;

namespace Nest
{
	public interface ILongRangeQuery : IRangeQuery
	{
		[JsonProperty("gt")]
		long? GreaterThan { get; set; }

		[JsonProperty("gte")]
		long? GreaterThanOrEqualTo { get; set; }

		[JsonProperty("lt")]
		long? LessThan { get; set; }

		[JsonProperty("lte")]
		long? LessThanOrEqualTo { get; set; }

		[JsonProperty("relation")]
		RangeRelation? Relation { get; set; }
	}

	public class LongRangeQuery : FieldNameQueryBase, ILongRangeQuery
	{
		public long? GreaterThan { get; set; }
		public long? GreaterThanOrEqualTo { get; set; }
		public long? LessThan { get; set; }
		public long? LessThanOrEqualTo { get; set; }

		public RangeRelation? Relation { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Range = this;

		internal static bool IsConditionless(ILongRangeQuery q) => q.Field.IsConditionless()
			|| (q.GreaterThanOrEqualTo == null
				&& q.LessThanOrEqualTo == null
				&& q.GreaterThan == null
				&& q.LessThan == null);
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class LongRangeQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<LongRangeQueryDescriptor<T>, ILongRangeQuery, T>
			, ILongRangeQuery where T : class
	{
		protected override bool Conditionless => LongRangeQuery.IsConditionless(this);
		long? ILongRangeQuery.GreaterThan { get; set; }
		long? ILongRangeQuery.GreaterThanOrEqualTo { get; set; }
		long? ILongRangeQuery.LessThan { get; set; }
		long? ILongRangeQuery.LessThanOrEqualTo { get; set; }
		RangeRelation? ILongRangeQuery.Relation { get; set; }

		public LongRangeQueryDescriptor<T> GreaterThan(long? from) => Assign(a => a.GreaterThan = from);

		public LongRangeQueryDescriptor<T> GreaterThanOrEquals(long? from) => Assign(a => a.GreaterThanOrEqualTo = from);

		public LongRangeQueryDescriptor<T> LessThan(long? to) => Assign(a => a.LessThan = to);

		public LongRangeQueryDescriptor<T> LessThanOrEquals(long? to) => Assign(a => a.LessThanOrEqualTo = to);

		public LongRangeQueryDescriptor<T> Relation(RangeRelation? relation) => Assign(a => a.Relation = relation);
	}
}
