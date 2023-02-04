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

	public struct Persistence : ICoherenceComponentData
	{

		public uint GetComponentType() => Definition.InternalPersistence;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;


		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Persistence)data;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			uint mask = 0;
			var newData = (Persistence)data;


			return mask;
		}

		public static void Serialize(Persistence data, uint mask, IOutProtocolBitStream bitStream)
		{
		}

		public static (Persistence, uint, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Persistence();
			return (val, mask, 0);
		}
	}
}