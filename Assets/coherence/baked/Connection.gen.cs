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

	public struct Connection : ICoherenceComponentData
	{
		public int id;

		public uint GetComponentType() => Definition.InternalConnection;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;

		private static readonly int _id_Min = -9999;
		private static readonly int _id_Max = 9999;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Connection)data;
			if ((mask & 0x01) != 0)
			{
				id = other.id;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (Connection)data;

			if (id != newData.id) {
				mask |= 0b00000000000000000000000000000001;
			}

			return mask;
		}

		public static void Serialize(Connection data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Toolkit.Bounds.Check(data.id, _id_Min, _id_Max, "Connection.id");

				bitStream.WriteIntegerRange(data.id, 15, -9999);
			}
			mask >>= 1;
		}

		public static (Connection, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Connection();
			if (bitStream.ReadMask())
			{
				val.id = bitStream.ReadIntegerRange(15, -9999);
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, 0);
		}
	}
}