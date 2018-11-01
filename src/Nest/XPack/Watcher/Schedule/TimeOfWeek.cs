﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<TimeOfWeek>))]
	public interface ITimeOfWeek
	{
		[JsonProperty("at")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<string>))]
		IEnumerable<string> At { get; set; }

		[JsonProperty("on")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<Day>))]
		IEnumerable<Day> On { get; set; }
	}

	public class TimeOfWeek : ITimeOfWeek
	{
		public TimeOfWeek() { }

		public TimeOfWeek(Day on, string at)
		{
			On = new[] { on };
			At = new[] { at };
		}

		public IEnumerable<string> At { get; set; }

		public IEnumerable<Day> On { get; set; }
	}

	public class TimeOfWeekDescriptor : DescriptorBase<TimeOfWeekDescriptor, ITimeOfWeek>, ITimeOfWeek
	{
		IEnumerable<string> ITimeOfWeek.At { get; set; }
		IEnumerable<Day> ITimeOfWeek.On { get; set; }

		public TimeOfWeekDescriptor At(IEnumerable<string> time) => Assign(a => a.At = time);

		public TimeOfWeekDescriptor At(params string[] time) => Assign(a => a.At = time);

		public TimeOfWeekDescriptor On(IEnumerable<Day> day) => Assign(a => a.On = day);

		public TimeOfWeekDescriptor On(params Day[] day) => Assign(a => a.On = day);
	}
}
