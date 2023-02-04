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

	public struct ArchetypeComponent : ICoherenceComponentData
	{
		public int index;

		public uint GetComponentType() => Definition.InternalArchetypeComponent;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly int _index_Min = -9999;
		private static readonly int _index_Max = 9999;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (ArchetypeComponent)data;
			if ((mask & 0x01) != 0)
			{
				index = other.index;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (ArchetypeComponent)data;

			if (index != newData.index) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(ArchetypeComponent data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.index, _index_Min, _index_Max, "ArchetypeComponent.index");

				bitStream.WriteIntegerRange(data.index, 15, -9999);
			}
			mask >>= 1;
		}

		public static (ArchetypeComponent, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new ArchetypeComponent();
			if (bitStream.ReadMask())
			{
				val.index = bitStream.ReadIntegerRange(15, -9999);
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}