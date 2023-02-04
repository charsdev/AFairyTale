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

	public struct GenericFieldVector3 : ICoherenceComponentData
	{
		public float3 Value;

		public uint GetComponentType() => Definition.InternalGenericFieldVector3;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _Value_Min = -2400f;
		private static readonly float _Value_Max = 2400f;
		private static readonly float _Value_Epsilon = 0.000286102294921875f;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericFieldVector3)data;
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
			var newData = (GenericFieldVector3)data;

			if (Diffing.HasNoticeableDifference(Value, newData.Value, _Value_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldVector3 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.Value.x, _Value_Min, _Value_Max, "GenericFieldVector3.Value.x");

				Coherence.Toolkit.Bounds.Check(data.Value.y, _Value_Min, _Value_Max, "GenericFieldVector3.Value.y");

				Coherence.Toolkit.Bounds.Check(data.Value.z, _Value_Min, _Value_Max, "GenericFieldVector3.Value.z");

				bitStream.WriteVector3f(CoherenceToUnityConverters.FromUnityfloat3(data.Value), 24, 2400);
			}
			mask >>= 1;
		}

		public static (GenericFieldVector3, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldVector3();
			if (bitStream.ReadMask())
			{
				val.Value = CoherenceToUnityConverters.ToUnityfloat3(bitStream.ReadVector3f(24, 2400));
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}