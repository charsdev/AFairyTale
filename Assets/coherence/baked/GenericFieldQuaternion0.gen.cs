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

	public struct GenericFieldQuaternion0 : ICoherenceComponentData
	{
		public quaternion Value;

		public uint GetComponentType() => Definition.InternalGenericFieldQuaternion0;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _Value_Epsilon = 0.01f; // TODO!

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (GenericFieldQuaternion0)data;
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
			var newData = (GenericFieldQuaternion0)data;

			if (Diffing.HasNoticeableDifference(Value, newData.Value, _Value_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(GenericFieldQuaternion0 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteUnitRotation(CoherenceToUnityConverters.FromUnityquaternion(data.Value));
			}
			mask >>= 1;
		}

		public static (GenericFieldQuaternion0, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new GenericFieldQuaternion0();
			if (bitStream.ReadMask())
			{
				val.Value = CoherenceToUnityConverters.ToUnityquaternion(bitStream.ReadUnitRotation());
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}