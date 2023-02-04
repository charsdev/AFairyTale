
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using global::Unity.Collections;
	using global::Unity.Mathematics;

	public struct TransferAction : IEntityEvent
	{
		readonly public int participant;
		readonly public bool accepted;

		public uint GetComponentType() => Definition.InternalTransferAction;

		public TransferAction
		(
			int dataparticipant,
			bool dataaccepted
		)
		{
			participant = dataparticipant;
			accepted = dataaccepted;
		}

		public static void Serialize(TransferAction eventData, IOutProtocolBitStream bitStream)
		{
			bitStream.WriteIntegerRange(eventData.participant, 15, -9999);
			bitStream.WriteBool(eventData.accepted);
		}

		public static TransferAction Deserialize(IInProtocolBitStream bitStream)
		{
			var dataparticipant = bitStream.ReadIntegerRange(15, -9999);
			var dataaccepted = bitStream.ReadBool();

			return new TransferAction
			(
				dataparticipant,
				dataaccepted
			){};
		}
	}
}

