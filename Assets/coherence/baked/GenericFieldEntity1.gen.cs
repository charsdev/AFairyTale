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

	public struct GenericFieldEntity1 : ICoherenceComponentData
	{
		public SerializeEntityID Value;

		public uint GetComponentType() => Definition.InternalGenericFieldEntity1;

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
			var other = (GenericFieldEntity1)data;
			if ((mask & 0x01) != 0)
			{
				Value = other.Value;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GenericFieldEntity1)data;

			if (Value != newData.Value) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldEntity1 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteEntity(data.Value);
			}
			mask >>= 1;
		}

		public static (GenericFieldEntity1, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldEntity1();
			if (bitStream.ReadMask())
			{
				val.Value = bitStream.ReadEntity();
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}