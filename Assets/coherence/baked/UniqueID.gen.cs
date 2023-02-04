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

	public struct UniqueID : ICoherenceComponentData
	{
		public FixedString64 uuid;

		public uint GetComponentType() => Definition.InternalUniqueID;

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
			var other = (UniqueID)data;
			if ((mask & 0x01) != 0)
			{
				uuid = other.uuid;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (UniqueID)data;

			if (Diffing.HasNoticeableDifference(uuid, newData.uuid)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(UniqueID data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteShortString(CoherenceToUnityConverters.FromUnityFixedString64(data.uuid));
			}
			mask >>= 1;
		}

		public static (UniqueID, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new UniqueID();
			if (bitStream.ReadMask())
			{
				val.uuid = CoherenceToUnityConverters.ToUnityFixedString64(bitStream.ReadShortString());
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}