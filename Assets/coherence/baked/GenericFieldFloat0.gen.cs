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

	public struct GenericFieldFloat0 : ICoherenceComponentData
	{
		public float number;

		public uint GetComponentType() => Definition.InternalGenericFieldFloat0;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _number_Min = -2400f;
		private static readonly float _number_Max = 2400f;
		private static readonly float _number_Epsilon = 0.000286102294921875f;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericFieldFloat0)data;
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
			var newData = (GenericFieldFloat0)data;

			if (Diffing.HasNoticeableDifference(number, newData.number, _number_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldFloat0 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.number, _number_Min, _number_Max, "GenericFieldFloat0.number");

				bitStream.WriteFixedPoint(CoherenceToUnityConverters.FromUnityfloat(data.number), 24, 2400);
			}
			mask >>= 1;
		}

		public static (GenericFieldFloat0, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldFloat0();
			if (bitStream.ReadMask())
			{
				val.number = CoherenceToUnityConverters.ToUnityfloat(bitStream.ReadFixedPoint(24, 2400));
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}