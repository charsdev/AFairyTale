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

	public struct WorldOrientation : ICoherenceComponentData
	{
		public quaternion value;

		public uint GetComponentType() => Definition.InternalWorldOrientation;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly float _value_Epsilon = 0.01f; // TODO!

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (WorldOrientation)data;
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
			var newData = (WorldOrientation)data;

			if (Diffing.HasNoticeableDifference(value, newData.value, _value_Epsilon)) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(WorldOrientation data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				bitStream.WriteUnitRotation(CoherenceToUnityConverters.FromUnityquaternion(data.value));
			}
			mask >>= 1;
		}

		public static (WorldOrientation, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new WorldOrientation();
			if (bitStream.ReadMask())
			{
				val.value = CoherenceToUnityConverters.ToUnityquaternion(bitStream.ReadUnitRotation());
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}