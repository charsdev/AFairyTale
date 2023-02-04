namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Entity;
	using Coherence.Serializer;
	using System.Collections.Generic;

	public class Definition : IDefinition
	{
		public const uint InternalWorldPosition = 0;
		public const uint InternalWorldOrientation = 1;
		public const uint InternalLocalUser = 2;
		public const uint InternalWorldPositionQuery = 3;
		public const uint InternalArchetypeComponent = 4;
		public const uint InternalPersistence = 5;
		public const uint InternalConnectedEntity = 6;
		public const uint InternalUniqueID = 7;
		public const uint InternalConnection = 8;
		public const uint InternalGlobal = 9;
		public const uint InternalGlobalQuery = 10;
		public const uint InternalGenericPrefabReference = 11;
		public const uint InternalGenericScale = 12;
		public const uint InternalGenericFieldInt0 = 13;
		public const uint InternalGenericFieldInt1 = 14;
		public const uint InternalGenericFieldInt2 = 15;
		public const uint InternalGenericFieldInt3 = 16;
		public const uint InternalGenericFieldInt4 = 17;
		public const uint InternalGenericFieldInt5 = 18;
		public const uint InternalGenericFieldInt6 = 19;
		public const uint InternalGenericFieldInt7 = 20;
		public const uint InternalGenericFieldInt8 = 21;
		public const uint InternalGenericFieldInt9 = 22;
		public const uint InternalGenericFieldBool0 = 23;
		public const uint InternalGenericFieldBool1 = 24;
		public const uint InternalGenericFieldBool2 = 25;
		public const uint InternalGenericFieldBool3 = 26;
		public const uint InternalGenericFieldBool4 = 27;
		public const uint InternalGenericFieldBool5 = 28;
		public const uint InternalGenericFieldBool6 = 29;
		public const uint InternalGenericFieldBool7 = 30;
		public const uint InternalGenericFieldBool8 = 31;
		public const uint InternalGenericFieldBool9 = 32;
		public const uint InternalGenericFieldFloat0 = 33;
		public const uint InternalGenericFieldFloat1 = 34;
		public const uint InternalGenericFieldFloat2 = 35;
		public const uint InternalGenericFieldFloat3 = 36;
		public const uint InternalGenericFieldFloat4 = 37;
		public const uint InternalGenericFieldFloat5 = 38;
		public const uint InternalGenericFieldFloat6 = 39;
		public const uint InternalGenericFieldFloat7 = 40;
		public const uint InternalGenericFieldFloat8 = 41;
		public const uint InternalGenericFieldFloat9 = 42;
		public const uint InternalGenericFieldVector0 = 43;
		public const uint InternalGenericFieldVector1 = 44;
		public const uint InternalGenericFieldVector2 = 45;
		public const uint InternalGenericFieldVector3 = 46;
		public const uint InternalGenericFieldString0 = 47;
		public const uint InternalGenericFieldString1 = 48;
		public const uint InternalGenericFieldString2 = 49;
		public const uint InternalGenericFieldString3 = 50;
		public const uint InternalGenericFieldString4 = 51;
		public const uint InternalGenericFieldQuaternion0 = 52;
		public const uint InternalGenericFieldEntity0 = 53;
		public const uint InternalGenericFieldEntity1 = 54;
		public const uint InternalGenericFieldEntity2 = 55;
		public const uint InternalGenericFieldEntity3 = 56;
		public const uint InternalGenericFieldEntity4 = 57;
		public const uint InternalGenericFieldEntity5 = 58;
		public const uint InternalGenericFieldEntity6 = 59;
		public const uint InternalGenericFieldEntity7 = 60;
		public const uint InternalGenericFieldEntity8 = 61;
		public const uint InternalGenericFieldEntity9 = 62;
		public const uint InternalAuthorityTransfer = 0;
		public const uint InternalGenericCommand = 1;
		public const uint InternalTransferAction = 0;

		private static readonly Dictionary<uint, string> componentNamesForTypeIds = new Dictionary<uint, string>() {
			{ 0, "WorldPosition" },
			{ 1, "WorldOrientation" },
			{ 2, "LocalUser" },
			{ 3, "WorldPositionQuery" },
			{ 4, "ArchetypeComponent" },
			{ 5, "Persistence" },
			{ 6, "ConnectedEntity" },
			{ 7, "UniqueID" },
			{ 8, "Connection" },
			{ 9, "Global" },
			{ 10, "GlobalQuery" },
			{ 11, "GenericPrefabReference" },
			{ 12, "GenericScale" },
			{ 13, "GenericFieldInt0" },
			{ 14, "GenericFieldInt1" },
			{ 15, "GenericFieldInt2" },
			{ 16, "GenericFieldInt3" },
			{ 17, "GenericFieldInt4" },
			{ 18, "GenericFieldInt5" },
			{ 19, "GenericFieldInt6" },
			{ 20, "GenericFieldInt7" },
			{ 21, "GenericFieldInt8" },
			{ 22, "GenericFieldInt9" },
			{ 23, "GenericFieldBool0" },
			{ 24, "GenericFieldBool1" },
			{ 25, "GenericFieldBool2" },
			{ 26, "GenericFieldBool3" },
			{ 27, "GenericFieldBool4" },
			{ 28, "GenericFieldBool5" },
			{ 29, "GenericFieldBool6" },
			{ 30, "GenericFieldBool7" },
			{ 31, "GenericFieldBool8" },
			{ 32, "GenericFieldBool9" },
			{ 33, "GenericFieldFloat0" },
			{ 34, "GenericFieldFloat1" },
			{ 35, "GenericFieldFloat2" },
			{ 36, "GenericFieldFloat3" },
			{ 37, "GenericFieldFloat4" },
			{ 38, "GenericFieldFloat5" },
			{ 39, "GenericFieldFloat6" },
			{ 40, "GenericFieldFloat7" },
			{ 41, "GenericFieldFloat8" },
			{ 42, "GenericFieldFloat9" },
			{ 43, "GenericFieldVector0" },
			{ 44, "GenericFieldVector1" },
			{ 45, "GenericFieldVector2" },
			{ 46, "GenericFieldVector3" },
			{ 47, "GenericFieldString0" },
			{ 48, "GenericFieldString1" },
			{ 49, "GenericFieldString2" },
			{ 50, "GenericFieldString3" },
			{ 51, "GenericFieldString4" },
			{ 52, "GenericFieldQuaternion0" },
			{ 53, "GenericFieldEntity0" },
			{ 54, "GenericFieldEntity1" },
			{ 55, "GenericFieldEntity2" },
			{ 56, "GenericFieldEntity3" },
			{ 57, "GenericFieldEntity4" },
			{ 58, "GenericFieldEntity5" },
			{ 59, "GenericFieldEntity6" },
			{ 60, "GenericFieldEntity7" },
			{ 61, "GenericFieldEntity8" },
			{ 62, "GenericFieldEntity9" },
		};

		public static string ComponentNameForTypeId(uint typeId)
		{
			if(componentNamesForTypeIds.TryGetValue(typeId, out string componentName))
			{
				return componentName;
			}
			else
			{
				return "";
			}
		}

		public (ICoherenceComponentData, uint, uint) ReadComponentUpdate(uint componentType, IInBitStream bitStream)
		{
			_ = Deserialize.ReadComponentOwnership(bitStream); // Read and discard unused bit from stream.
			var inProtocolStream = new InProtocolBitStream(bitStream);

			switch (componentType)
			{
				case InternalWorldPosition:
					return WorldPosition.Deserialize(inProtocolStream);
				case InternalWorldOrientation:
					return WorldOrientation.Deserialize(inProtocolStream);
				case InternalLocalUser:
					return LocalUser.Deserialize(inProtocolStream);
				case InternalWorldPositionQuery:
					return WorldPositionQuery.Deserialize(inProtocolStream);
				case InternalArchetypeComponent:
					return ArchetypeComponent.Deserialize(inProtocolStream);
				case InternalPersistence:
					return Persistence.Deserialize(inProtocolStream);
				case InternalConnectedEntity:
					return ConnectedEntity.Deserialize(inProtocolStream);
				case InternalUniqueID:
					return UniqueID.Deserialize(inProtocolStream);
				case InternalConnection:
					return Connection.Deserialize(inProtocolStream);
				case InternalGlobal:
					return Global.Deserialize(inProtocolStream);
				case InternalGlobalQuery:
					return GlobalQuery.Deserialize(inProtocolStream);
				case InternalGenericPrefabReference:
					return GenericPrefabReference.Deserialize(inProtocolStream);
				case InternalGenericScale:
					return GenericScale.Deserialize(inProtocolStream);
				case InternalGenericFieldInt0:
					return GenericFieldInt0.Deserialize(inProtocolStream);
				case InternalGenericFieldInt1:
					return GenericFieldInt1.Deserialize(inProtocolStream);
				case InternalGenericFieldInt2:
					return GenericFieldInt2.Deserialize(inProtocolStream);
				case InternalGenericFieldInt3:
					return GenericFieldInt3.Deserialize(inProtocolStream);
				case InternalGenericFieldInt4:
					return GenericFieldInt4.Deserialize(inProtocolStream);
				case InternalGenericFieldInt5:
					return GenericFieldInt5.Deserialize(inProtocolStream);
				case InternalGenericFieldInt6:
					return GenericFieldInt6.Deserialize(inProtocolStream);
				case InternalGenericFieldInt7:
					return GenericFieldInt7.Deserialize(inProtocolStream);
				case InternalGenericFieldInt8:
					return GenericFieldInt8.Deserialize(inProtocolStream);
				case InternalGenericFieldInt9:
					return GenericFieldInt9.Deserialize(inProtocolStream);
				case InternalGenericFieldBool0:
					return GenericFieldBool0.Deserialize(inProtocolStream);
				case InternalGenericFieldBool1:
					return GenericFieldBool1.Deserialize(inProtocolStream);
				case InternalGenericFieldBool2:
					return GenericFieldBool2.Deserialize(inProtocolStream);
				case InternalGenericFieldBool3:
					return GenericFieldBool3.Deserialize(inProtocolStream);
				case InternalGenericFieldBool4:
					return GenericFieldBool4.Deserialize(inProtocolStream);
				case InternalGenericFieldBool5:
					return GenericFieldBool5.Deserialize(inProtocolStream);
				case InternalGenericFieldBool6:
					return GenericFieldBool6.Deserialize(inProtocolStream);
				case InternalGenericFieldBool7:
					return GenericFieldBool7.Deserialize(inProtocolStream);
				case InternalGenericFieldBool8:
					return GenericFieldBool8.Deserialize(inProtocolStream);
				case InternalGenericFieldBool9:
					return GenericFieldBool9.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat0:
					return GenericFieldFloat0.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat1:
					return GenericFieldFloat1.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat2:
					return GenericFieldFloat2.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat3:
					return GenericFieldFloat3.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat4:
					return GenericFieldFloat4.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat5:
					return GenericFieldFloat5.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat6:
					return GenericFieldFloat6.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat7:
					return GenericFieldFloat7.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat8:
					return GenericFieldFloat8.Deserialize(inProtocolStream);
				case InternalGenericFieldFloat9:
					return GenericFieldFloat9.Deserialize(inProtocolStream);
				case InternalGenericFieldVector0:
					return GenericFieldVector0.Deserialize(inProtocolStream);
				case InternalGenericFieldVector1:
					return GenericFieldVector1.Deserialize(inProtocolStream);
				case InternalGenericFieldVector2:
					return GenericFieldVector2.Deserialize(inProtocolStream);
				case InternalGenericFieldVector3:
					return GenericFieldVector3.Deserialize(inProtocolStream);
				case InternalGenericFieldString0:
					return GenericFieldString0.Deserialize(inProtocolStream);
				case InternalGenericFieldString1:
					return GenericFieldString1.Deserialize(inProtocolStream);
				case InternalGenericFieldString2:
					return GenericFieldString2.Deserialize(inProtocolStream);
				case InternalGenericFieldString3:
					return GenericFieldString3.Deserialize(inProtocolStream);
				case InternalGenericFieldString4:
					return GenericFieldString4.Deserialize(inProtocolStream);
				case InternalGenericFieldQuaternion0:
					return GenericFieldQuaternion0.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity0:
					return GenericFieldEntity0.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity1:
					return GenericFieldEntity1.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity2:
					return GenericFieldEntity2.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity3:
					return GenericFieldEntity3.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity4:
					return GenericFieldEntity4.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity5:
					return GenericFieldEntity5.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity6:
					return GenericFieldEntity6.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity7:
					return GenericFieldEntity7.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity8:
					return GenericFieldEntity8.Deserialize(inProtocolStream);
				case InternalGenericFieldEntity9:
					return GenericFieldEntity9.Deserialize(inProtocolStream);
				default:
					return (null, 0, 0);
			}
		}

		public void WriteComponentUpdate(ICoherenceComponentData data, uint mask, IOutProtocolBitStream protocolStream)
		{
			switch (data.GetComponentType())
			{
				case InternalWorldPosition:
					WorldPosition.Serialize((WorldPosition)data, mask, protocolStream);
					break;
				case InternalWorldOrientation:
					WorldOrientation.Serialize((WorldOrientation)data, mask, protocolStream);
					break;
				case InternalLocalUser:
					LocalUser.Serialize((LocalUser)data, mask, protocolStream);
					break;
				case InternalWorldPositionQuery:
					WorldPositionQuery.Serialize((WorldPositionQuery)data, mask, protocolStream);
					break;
				case InternalArchetypeComponent:
					ArchetypeComponent.Serialize((ArchetypeComponent)data, mask, protocolStream);
					break;
				case InternalPersistence:
					Persistence.Serialize((Persistence)data, mask, protocolStream);
					break;
				case InternalConnectedEntity:
					ConnectedEntity.Serialize((ConnectedEntity)data, mask, protocolStream);
					break;
				case InternalUniqueID:
					UniqueID.Serialize((UniqueID)data, mask, protocolStream);
					break;
				case InternalConnection:
					Connection.Serialize((Connection)data, mask, protocolStream);
					break;
				case InternalGlobal:
					Global.Serialize((Global)data, mask, protocolStream);
					break;
				case InternalGlobalQuery:
					GlobalQuery.Serialize((GlobalQuery)data, mask, protocolStream);
					break;
				case InternalGenericPrefabReference:
					GenericPrefabReference.Serialize((GenericPrefabReference)data, mask, protocolStream);
					break;
				case InternalGenericScale:
					GenericScale.Serialize((GenericScale)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt0:
					GenericFieldInt0.Serialize((GenericFieldInt0)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt1:
					GenericFieldInt1.Serialize((GenericFieldInt1)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt2:
					GenericFieldInt2.Serialize((GenericFieldInt2)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt3:
					GenericFieldInt3.Serialize((GenericFieldInt3)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt4:
					GenericFieldInt4.Serialize((GenericFieldInt4)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt5:
					GenericFieldInt5.Serialize((GenericFieldInt5)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt6:
					GenericFieldInt6.Serialize((GenericFieldInt6)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt7:
					GenericFieldInt7.Serialize((GenericFieldInt7)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt8:
					GenericFieldInt8.Serialize((GenericFieldInt8)data, mask, protocolStream);
					break;
				case InternalGenericFieldInt9:
					GenericFieldInt9.Serialize((GenericFieldInt9)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool0:
					GenericFieldBool0.Serialize((GenericFieldBool0)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool1:
					GenericFieldBool1.Serialize((GenericFieldBool1)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool2:
					GenericFieldBool2.Serialize((GenericFieldBool2)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool3:
					GenericFieldBool3.Serialize((GenericFieldBool3)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool4:
					GenericFieldBool4.Serialize((GenericFieldBool4)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool5:
					GenericFieldBool5.Serialize((GenericFieldBool5)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool6:
					GenericFieldBool6.Serialize((GenericFieldBool6)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool7:
					GenericFieldBool7.Serialize((GenericFieldBool7)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool8:
					GenericFieldBool8.Serialize((GenericFieldBool8)data, mask, protocolStream);
					break;
				case InternalGenericFieldBool9:
					GenericFieldBool9.Serialize((GenericFieldBool9)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat0:
					GenericFieldFloat0.Serialize((GenericFieldFloat0)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat1:
					GenericFieldFloat1.Serialize((GenericFieldFloat1)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat2:
					GenericFieldFloat2.Serialize((GenericFieldFloat2)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat3:
					GenericFieldFloat3.Serialize((GenericFieldFloat3)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat4:
					GenericFieldFloat4.Serialize((GenericFieldFloat4)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat5:
					GenericFieldFloat5.Serialize((GenericFieldFloat5)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat6:
					GenericFieldFloat6.Serialize((GenericFieldFloat6)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat7:
					GenericFieldFloat7.Serialize((GenericFieldFloat7)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat8:
					GenericFieldFloat8.Serialize((GenericFieldFloat8)data, mask, protocolStream);
					break;
				case InternalGenericFieldFloat9:
					GenericFieldFloat9.Serialize((GenericFieldFloat9)data, mask, protocolStream);
					break;
				case InternalGenericFieldVector0:
					GenericFieldVector0.Serialize((GenericFieldVector0)data, mask, protocolStream);
					break;
				case InternalGenericFieldVector1:
					GenericFieldVector1.Serialize((GenericFieldVector1)data, mask, protocolStream);
					break;
				case InternalGenericFieldVector2:
					GenericFieldVector2.Serialize((GenericFieldVector2)data, mask, protocolStream);
					break;
				case InternalGenericFieldVector3:
					GenericFieldVector3.Serialize((GenericFieldVector3)data, mask, protocolStream);
					break;
				case InternalGenericFieldString0:
					GenericFieldString0.Serialize((GenericFieldString0)data, mask, protocolStream);
					break;
				case InternalGenericFieldString1:
					GenericFieldString1.Serialize((GenericFieldString1)data, mask, protocolStream);
					break;
				case InternalGenericFieldString2:
					GenericFieldString2.Serialize((GenericFieldString2)data, mask, protocolStream);
					break;
				case InternalGenericFieldString3:
					GenericFieldString3.Serialize((GenericFieldString3)data, mask, protocolStream);
					break;
				case InternalGenericFieldString4:
					GenericFieldString4.Serialize((GenericFieldString4)data, mask, protocolStream);
					break;
				case InternalGenericFieldQuaternion0:
					GenericFieldQuaternion0.Serialize((GenericFieldQuaternion0)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity0:
					GenericFieldEntity0.Serialize((GenericFieldEntity0)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity1:
					GenericFieldEntity1.Serialize((GenericFieldEntity1)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity2:
					GenericFieldEntity2.Serialize((GenericFieldEntity2)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity3:
					GenericFieldEntity3.Serialize((GenericFieldEntity3)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity4:
					GenericFieldEntity4.Serialize((GenericFieldEntity4)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity5:
					GenericFieldEntity5.Serialize((GenericFieldEntity5)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity6:
					GenericFieldEntity6.Serialize((GenericFieldEntity6)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity7:
					GenericFieldEntity7.Serialize((GenericFieldEntity7)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity8:
					GenericFieldEntity8.Serialize((GenericFieldEntity8)data, mask, protocolStream);
					break;
				case InternalGenericFieldEntity9:
					GenericFieldEntity9.Serialize((GenericFieldEntity9)data, mask, protocolStream);
					break;
			}
		}

		private IEntityCommand ReadCommand(uint commandType, IInProtocolBitStream bitStream)
		{
			switch (commandType)
			{
				case Definition.InternalAuthorityTransfer:
					return AuthorityTransfer.Deserialize(bitStream);
				case Definition.InternalGenericCommand:
					return GenericCommand.Deserialize(bitStream);
				default:
					break;
			}

			return default;
		}

		private IEntityEvent ReadEvent(uint eventType, IInProtocolBitStream bitStream)
		{
			switch (eventType)
			{
				case Definition.InternalTransferAction:
					return TransferAction.Deserialize(bitStream);
				default:
					break;
			}

			return default;
		}

		private IEntityInput ReadInput(uint inputType, IInProtocolBitStream bitStream)
		{
			switch (inputType)
			{
				default:
					break;
			}

			return default;
		}

		public (IEntityCommand command, SerializeEntityID entityId, MessageTarget messageTarget)[]
			ReadCommands(IInBitStream bitStream)
		{
			var numMessages = bitStream.ReadUint8();

			var commandData = new (IEntityCommand command, SerializeEntityID entityId, MessageTarget messageTarget)[numMessages];

			for (var i = 0; i < numMessages; i++)
			{
				commandData[i].entityId = DeserializerTools.DeserializeEntityID(bitStream);
				commandData[i].messageTarget = DeserializerTools.DeserializeMessageTarget(bitStream);
				var componentType = DeserializerTools.DeserializeComponentTypeID(bitStream);
				var inBitStream = new Coherence.Serializer.InProtocolBitStream(bitStream);
				commandData[i].command = ReadCommand(componentType, inBitStream);
			}

			return commandData;
		}

		public (IEntityEvent[], SerializeEntityID[]) ReadEvents(IInBitStream bitStream)
		{
			var numMessages = bitStream.ReadUint8();

			var ids = new SerializeEntityID[numMessages];
			var messages = new IEntityEvent[numMessages];

			for (var i = 0; i < numMessages; i++)
			{
				ids[i] = DeserializerTools.DeserializeEntityID(bitStream);
				_ = DeserializerTools.DeserializeMessageTarget(bitStream);
				var componentType = DeserializerTools.DeserializeComponentTypeID(bitStream);
				var inBitStream = new Coherence.Serializer.InProtocolBitStream(bitStream);
				messages[i] = ReadEvent(componentType, inBitStream);
			}

			return (messages, ids);
		}

		public (IEntityInput[], SerializeEntityID[]) ReadInputs(IInBitStream bitStream)
		{
			var numMessages = bitStream.ReadUint8();

			var ids = new SerializeEntityID[numMessages];
			var messages = new IEntityInput[numMessages];

			for (var i = 0; i < numMessages; i++)
			{
				ids[i] = DeserializerTools.DeserializeEntityID(bitStream);
				_ = DeserializerTools.DeserializeMessageTarget(bitStream);
				var componentType = DeserializerTools.DeserializeComponentTypeID(bitStream);
				var inBitStream = new Coherence.Serializer.InProtocolBitStream(bitStream);
				messages[i] = ReadInput(componentType, inBitStream);
			}

			return (messages, ids);
		}

		public void WriteCommand(IEntityCommand data, uint commandType, IOutProtocolBitStream bitStream)
		{
			switch (commandType)
			{
				case Definition.InternalAuthorityTransfer:
					AuthorityTransfer.Serialize((AuthorityTransfer)data, bitStream);
					break;
				case Definition.InternalGenericCommand:
					GenericCommand.Serialize((GenericCommand)data, bitStream);
					break;
				default:
					break;
			}
		}

		public void WriteEvent(IEntityEvent data, uint eventType, IOutProtocolBitStream bitStream)
		{
			switch (eventType)
			{
				case Definition.InternalTransferAction:
					TransferAction.Serialize((TransferAction)data, bitStream);
					break;
				default:
					break;
			}
		}

		public void WriteInput(IEntityInput data, uint inputType, IOutProtocolBitStream bitStream)
		{
			switch (inputType)
			{
				default:
					break;
			}
		}

		public bool IsAuthorityRequest(IEntityCommand entityCommand)
		{
			return entityCommand.GetComponentType() == Definition.InternalAuthorityTransfer;
		}

		public ushort GetAuthorityRequestParticipant(IEntityCommand entityCommand)
		{
			var command = (AuthorityTransfer)entityCommand;
			return (ushort)command.participant;
		}

		public bool IsTransferAction(IEntityEvent entityEvent)
		{
			return entityEvent.GetComponentType() == Definition.InternalTransferAction;
		}

		public bool IsTransferActionAuthorized(IEntityEvent entityEvent)
		{
			var action = (TransferAction)entityEvent;
			return action.accepted;
		}

		public IEntityCommand CreateAuthorityTransferRequest(ushort participant)
		{
			return new AuthorityTransfer(participant);
		}

		public IEntityEvent CreateTransferAction(ushort participant, bool accepted)
		{
			return new TransferAction(participant, accepted);
		}

		public ICoherenceComponentData GeneratePersistenceData()
		{
			var persistence = new Persistence();

			return persistence;
		}

		public ICoherenceComponentData GenerateCoherenceUUIDData(string uuid)
		{
			var uniqueID = new UniqueID();
			uniqueID.uuid = CoherenceToUnityConverters.ToUnityFixedString64(uuid);

			return uniqueID;
		}

		public ICoherenceComponentData GenerateGlobalQueryComponent()
		{
			return new GlobalQuery();
		}

		public string ExtractCoherenceUUID(ICoherenceComponentData data)
		{
			var uniqueID = (UniqueID)data;

			return CoherenceToUnityConverters.FromUnityFixedString64(uniqueID.uuid);
		}

		public bool IsConnectedEntity(ICoherenceComponentData data)
		{
			return data.GetComponentType() == Definition.InternalConnectedEntity;
		}

		public SerializeEntityID ExtractConnectedEntityID(ICoherenceComponentData data)
		{
			var connectedEntity = (ConnectedEntity)data;

			return connectedEntity.value;
		}
	}
}