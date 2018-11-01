﻿using System;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<CreateIndexRequest>))]
	public partial interface ICreateIndexRequest : IIndexState { }

	public partial class CreateIndexRequest
	{
		private static readonly string[] ReadOnlySettings =
		{
			"index.creation_date",
			"index.uuid",
			"index.version.created",
			"index.provided_name"
		};

		//Only here for ReadAsType new() constraint needs to be updated
		internal CreateIndexRequest() { }

		public CreateIndexRequest(IndexName index, IIndexState state) : this(index)
		{
			Settings = state.Settings;
			Mappings = state.Mappings;
			RemoveReadOnlySettings(Settings);
		}

		public IAliases Aliases { get; set; }

		public IMappings Mappings { get; set; }

		public IIndexSettings Settings { get; set; }

		internal static void RemoveReadOnlySettings(IIndexSettings settings)
		{
			if (settings == null) return;

			foreach (var bad in ReadOnlySettings)
				if (settings.ContainsKey(bad))
					settings.Remove(bad);
		}
	}

	[DescriptorFor("IndicesCreate")]
	public partial class CreateIndexDescriptor
	{
		IAliases IIndexState.Aliases { get; set; }

		IMappings IIndexState.Mappings { get; set; }
		IIndexSettings IIndexState.Settings { get; set; }

		public CreateIndexDescriptor Aliases(Func<AliasesDescriptor, IPromise<IAliases>> selector) =>
			Assign(a => a.Aliases = selector?.Invoke(new AliasesDescriptor())?.Value);

		public CreateIndexDescriptor InitializeUsing(IIndexState indexSettings) => Assign(a =>
		{
			a.Settings = indexSettings.Settings;
			a.Mappings = indexSettings.Mappings;
			a.Aliases = indexSettings.Aliases;
			CreateIndexRequest.RemoveReadOnlySettings(a.Settings);
		});

		public CreateIndexDescriptor Mappings(Func<MappingsDescriptor, IPromise<IMappings>> selector) =>
			Assign(a => a.Mappings = selector?.Invoke(new MappingsDescriptor())?.Value);

		public CreateIndexDescriptor Settings(Func<IndexSettingsDescriptor, IPromise<IIndexSettings>> selector) =>
			Assign(a => a.Settings = selector?.Invoke(new IndexSettingsDescriptor())?.Value);
	}
}
