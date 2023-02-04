
namespace Coherence.Toolkit
{
	using UnityEngine;
	using Unity.Mathematics;
	using global::Coherence.Generated;
	using Coherence.Entity;

	public class CoherenceLiveQueryImpl : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void OnRuntimeMethodLoad()
		{
			CoherenceLiveQuery.CreateLiveQuery = CreateLiveQuery;
			CoherenceLiveQuery.UpdateLiveQuery = UpdateLiveQuery;
		}

		private static SerializeEntityID CreateLiveQuery(IClient client, float radius, float3 pos) {
			var components = new ICoherenceComponentData[] {
				new WorldPosition
				{
					value = pos // TODO WHICH ONE IS IT?
				},
				new WorldPositionQuery
				{
					position = pos, // TODO WHICH ONE IS IT?
					radius = radius
				}
			};

			return client.CreateEntity(components, false);
		}

		private static void UpdateLiveQuery(IClient client, SerializeEntityID liveQuery, float radius, float3 pos)
		{
			var newWorldPosition = new WorldPosition
			{
				value = pos
			};

			var newWorldPositionQuery = new WorldPositionQuery
			{
				position = pos,
				radius = radius
			};

			var components = new ICoherenceComponentData[]
			{
				newWorldPosition,
				newWorldPositionQuery,
			};

			var masks = new uint[]
			{
				0x11,
				0x11
			};

			client.UpdateComponents(liveQuery, components, masks);
		}
	}
}
