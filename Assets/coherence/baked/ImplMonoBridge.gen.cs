
namespace Coherence.Toolkit
{
	using UnityEngine;
	using Unity.Collections;
	using System;
	using Coherence.Entity;
	using Coherence.Generated;
	using Coherence.ProtocolDef;

	public enum InterpolationSetupID
	{
		DefaultTranslation = 0,
		DefaultRotation = 1,
	}

	public class CoherenceMonoBridgeImpl
	{
		//interpolation setups
		private static bool _doneSetup;
		private static NativeArray<InterpolationSetup> _interpolationSetups;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void OnRuntimeMethodLoad()
		{
			CoherenceMonoBridge.GenericPrefabReferenceTypeID = GenericPrefabReferenceTypeID;
			CoherenceMonoBridge.GetSpawnInfo = GetSpawnInfo;
			CoherenceMonoBridge.GetRootDefinition = GetRootDefinition;
			CoherenceMonoBridge.OnShutdown = OnShutdown;
			CoherenceMonoBridge.GetInterpolationSetup = GetInterpolationSetup;

			CreateSetups();
		}

		private static uint GenericPrefabReferenceTypeID()
		{
			return Definition.InternalGenericPrefabReference;
		}

		private static InterpolationSetup GetInterpolationSetup(string setupName)
		{
			return GetSetup(setupName);
		}

		static (bool, CoherenceMonoBridge.SpawnInfo) GetSpawnInfo(IClient client, EntityUpdate entityUpdate)
		{
			var info = new CoherenceMonoBridge.SpawnInfo();
			var gotPosition = false;
			var gotPrefabReference = false;

			foreach (var comp in entityUpdate.Components.Creates.Store)
			{
				switch(comp.Value.Data)
				{
					case WorldPosition pos:
						info.position = pos.value;
						gotPosition = true;
						break;
					case WorldOrientation rot:
						info.rotation = rot.value;
						break;
					case GenericPrefabReference prefabRef:
						info.prefabName = prefabRef.prefab;
						gotPrefabReference = true;
						break;
					case ConnectedEntity connectedEntity:
						info.connectedEntity = connectedEntity.value;
						break;
					case Connection con:
						info.connectionId = con.id;
						break;
				}
			}

			var shouldSpawn = (gotPosition && gotPrefabReference) || info.connectionId.HasValue;

			return (shouldSpawn, info);
		}

		private static IDefinition GetRootDefinition()
		{
			return new Definition();
		}

		public static void CreateSetups()
		{
			if (!_doneSetup)
			{
				_interpolationSetups = new NativeArray<InterpolationSetup>(2, Allocator.Persistent);
				_interpolationSetups[(int)InterpolationSetupID.DefaultTranslation] = new InterpolationSetup
				{
					overshootPercentage = 2f,
					overshootRetraction = 0.25f,
					manualLatency = 1f,
					autoLatencyFactor = 1.2f,
					elasticity = 0.045f,
					maxDistance = 1024f,
					curveType = InterpolationCurveType.Linear,
				};
				_interpolationSetups[(int)InterpolationSetupID.DefaultRotation] = new InterpolationSetup
				{
					overshootPercentage = 0f,
					overshootRetraction = 0f,
					manualLatency = 1f,
					autoLatencyFactor = 1f,
					elasticity = 0.05f,
					maxDistance = 1f,
					curveType = InterpolationCurveType.Linear,
				};

				_doneSetup = true;
			}
		}

		public static void OnShutdown()
		{
			if (_doneSetup)
			{
				_interpolationSetups.Dispose();
				_doneSetup = false;
			}
		}

		public static NativeArray<InterpolationSetup>.ReadOnly GetSetups()
		{
			return _interpolationSetups.AsReadOnly();
		}

		public static InterpolationSetup GetSetup(InterpolationSetupID ID)
		{
			return _interpolationSetups[(int)ID];
		}

		public static InterpolationSetup GetSetup(string IDstring)
		{
			return _interpolationSetups[(int)GetSetupID(IDstring)];
		}

		public static InterpolationSetupID GetSetupID(string name)
		{
			return (InterpolationSetupID)Enum.Parse(typeof(InterpolationSetupID), name);
		}
	}
}
