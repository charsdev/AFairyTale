
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using global::Unity.Collections;
	using global::Unity.Mathematics;
	using UnityEngine;
	using Coherence.Entity;

	public struct AuthorityTransfer : IEntityCommand
	{
		public int participant;

		public MessageTarget Routing => MessageTarget.AuthorityOnly;
		public uint GetComponentType() => Definition.InternalAuthorityTransfer;

		public AuthorityTransfer
		(
			int dataparticipant
		)
		{
			participant = dataparticipant;
		}

		public static void Serialize(AuthorityTransfer commandData, IOutProtocolBitStream bitStream)
		{
			bitStream.WriteIntegerRange(commandData.participant, 15, -9999);
		}

		public static AuthorityTransfer Deserialize(IInProtocolBitStream bitStream)
		{
			var dataparticipant = bitStream.ReadIntegerRange(15, -9999);

			return new AuthorityTransfer
			(
				dataparticipant
			){};
		}
	}
}
