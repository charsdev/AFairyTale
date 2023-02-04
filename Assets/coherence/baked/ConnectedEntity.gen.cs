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

	public struct ConnectedEntity : ICoherenceComponentData
	{
		public SerializeEntityID value;

		public uint GetComponentType() => Definition.InternalConnectedEntity;

		public const int order = -1;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;


		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (ConnectedEntity)data;
			if ((mask & 0x01) != 0)
			{
				value = other.value;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (ConnectedEntity)data;

			if (value != newData.value) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(ConnectedEntity data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteEntity(data.value);
			}
			mask >>= 1;
		}

		public static (ConnectedEntity, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new ConnectedEntity();
			if (bitStream.ReadMask())
			{
				val.value = bitStream.ReadEntity();
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}