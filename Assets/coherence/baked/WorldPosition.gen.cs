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

	public struct WorldPosition : ICoherenceComponentData
	{
		public float3 value;

		public uint GetComponentType() => Definition.InternalWorldPosition;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _value_Min = -2400f;
		private static readonly float _value_Max = 2400f;
		private static readonly float _value_Epsilon = 0.000286102294921875f;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (WorldPosition)data;
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
			var newData = (WorldPosition)data;

			if (Diffing.HasNoticeableDifference(value, newData.value, _value_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(WorldPosition data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.value.x, _value_Min, _value_Max, "WorldPosition.value.x");

				Coherence.Toolkit.Bounds.Check(data.value.y, _value_Min, _value_Max, "WorldPosition.value.y");

				Coherence.Toolkit.Bounds.Check(data.value.z, _value_Min, _value_Max, "WorldPosition.value.z");

				bitStream.WriteVector3f(CoherenceToUnityConverters.FromUnityfloat3(data.value), 24, 2400);
			}
			mask >>= 1;
		}

		public static (WorldPosition, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new WorldPosition();
			if (bitStream.ReadMask())
			{
				val.value = CoherenceToUnityConverters.ToUnityfloat3(bitStream.ReadVector3f(24, 2400));
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}