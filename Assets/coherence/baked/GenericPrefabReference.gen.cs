namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.SimulationFrame;
	using Coherence.Entity;
	using Coherence.Toolkit;
	using Unity.Mathematics;
	using Unity.Collections;
	using UnityEngine;

	public struct GenericPrefabReference : ICoherenceComponentData
	{
		public FixedString64 prefab;

		public uint GetComponentType() => Definition.InternalGenericPrefabReference;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;


		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericPrefabReference)data;
			if ((mask & 0x01) != 0)
			{
				prefab = other.prefab;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GenericPrefabReference)data;

			if (Diffing.HasNoticeableDifference(prefab, newData.prefab)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericPrefabReference data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteShortString(CoherenceToUnityConverters.FromUnityFixedString64(data.prefab));
			}
			mask >>= 1;
		}

		public static (GenericPrefabReference, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericPrefabReference();
			if (bitStream.ReadMask())
			{
				val.prefab = CoherenceToUnityConverters.ToUnityFixedString64(bitStream.ReadShortString());
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}