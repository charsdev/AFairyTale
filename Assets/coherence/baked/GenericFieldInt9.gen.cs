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

	public struct GenericFieldInt9 : ICoherenceComponentData
	{
		public int number;

		public uint GetComponentType() => Definition.InternalGenericFieldInt9;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly int _number_Min = -9999;
		private static readonly int _number_Max = 9999;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericFieldInt9)data;
			if ((mask & 0x01) != 0)
			{
				number = other.number;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (GenericFieldInt9)data;

			if (number != newData.number) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldInt9 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.number, _number_Min, _number_Max, "GenericFieldInt9.number");

				bitStream.WriteIntegerRange(data.number, 15, -9999);
			}
			mask >>= 1;
		}

		public static (GenericFieldInt9, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldInt9();
			if (bitStream.ReadMask())
			{
				val.number = bitStream.ReadIntegerRange(15, -9999);
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}