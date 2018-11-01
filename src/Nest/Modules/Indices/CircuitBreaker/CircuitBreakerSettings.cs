namespace Nest
{
	public interface ICircuitBreakerSettings
	{
		/// <summary></summary>
		string FielddataLimit { get; set; }

		/// <summary></summary>
		float? FielddataOverhead { get; set; }

		/// <summary></summary>
		string RequestLimit { get; set; }

		/// <summary></summary>
		float? RequestOverhead { get; set; }

		/// <summary></summary>
		string TotalLimit { get; set; }
	}

	public class CircuitBreakerSettings : ICircuitBreakerSettings
	{
		/// <inheritdoc />
		public string FielddataLimit { get; set; }

		/// <inheritdoc />
		public float? FielddataOverhead { get; set; }

		/// <inheritdoc />
		public string RequestLimit { get; set; }

		/// <inheritdoc />
		public float? RequestOverhead { get; set; }

		/// <inheritdoc />
		public string TotalLimit { get; set; }
	}

	public class CircuitBreakerSettingsDescriptor
		: DescriptorBase<CircuitBreakerSettingsDescriptor, ICircuitBreakerSettings>, ICircuitBreakerSettings
	{
		string ICircuitBreakerSettings.FielddataLimit { get; set; }
		float? ICircuitBreakerSettings.FielddataOverhead { get; set; }
		string ICircuitBreakerSettings.RequestLimit { get; set; }
		float? ICircuitBreakerSettings.RequestOverhead { get; set; }
		string ICircuitBreakerSettings.TotalLimit { get; set; }

		/// <inheritdoc />
		public CircuitBreakerSettingsDescriptor FielddataLimit(string limit) => Assign(a => a.FielddataLimit = limit);

		/// <inheritdoc />
		public CircuitBreakerSettingsDescriptor FielddataOverhead(float? overhead) => Assign(a => a.FielddataOverhead = overhead);

		/// <inheritdoc />
		public CircuitBreakerSettingsDescriptor RequestLimit(string limit) => Assign(a => a.RequestLimit = limit);

		/// <inheritdoc />
		public CircuitBreakerSettingsDescriptor RequestOverhead(float? overhead) => Assign(a => a.RequestOverhead = overhead);

		/// <inheritdoc />
		public CircuitBreakerSettingsDescriptor TotalLimit(string limit) => Assign(a => a.TotalLimit = limit);
	}
}
