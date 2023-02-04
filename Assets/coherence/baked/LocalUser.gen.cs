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

	public struct LocalUser : ICoherenceComponentData
	{
		public int localIndex;

		public uint GetComponentType() => Definition.InternalLocalUser;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly int _localIndex_Min = -9999;
		private static readonly int _localIndex_Max = 9999;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (LocalUser)data;
			if ((mask & 0x01) != 0)
			{
				localIndex = other.localIndex;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (LocalUser)data;

			if (localIndex != newData.localIndex) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(LocalUser data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.localIndex, _localIndex_Min, _localIndex_Max, "LocalUser.localIndex");

				bitStream.WriteIntegerRange(data.localIndex, 15, -9999);
			}
			mask >>= 1;
		}

		public static (LocalUser, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new LocalUser();
			if (bitStream.ReadMask())
			{
				val.localIndex = bitStream.ReadIntegerRange(15, -9999);
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}