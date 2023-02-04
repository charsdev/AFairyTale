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

	public struct GenericFieldString1 : ICoherenceComponentData
	{
		public FixedString64 name;

		public uint GetComponentType() => Definition.InternalGenericFieldString1;

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
			var other = (GenericFieldString1)data;
			if ((mask & 0x01) != 0)
			{
				name = other.name;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GenericFieldString1)data;

			if (Diffing.HasNoticeableDifference(name, newData.name)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldString1 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteShortString(CoherenceToUnityConverters.FromUnityFixedString64(data.name));
			}
			mask >>= 1;
		}

		public static (GenericFieldString1, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldString1();
			if (bitStream.ReadMask())
			{
				val.name = CoherenceToUnityConverters.ToUnityFixedString64(bitStream.ReadShortString());
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}