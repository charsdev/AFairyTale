
namespace Coherence.Toolkit
{
	using Unity.Collections;
	using UnityEngine;
	using System;
	using System.Collections.Generic;
	using global::Coherence.Generated;
	using Coherence.Entity;
	using Coherence.ProtocolDef;

	public class CoherenceSyncImpl
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void OnRuntimeMethodLoad()
		{
			CoherenceSync.ComponentNameFromTypeId = ComponentNameFromTypeId;
			CoherenceSync.CreateInitialComponents = CreateInitialComponents;
			CoherenceSync.ReceiveGenericCommand = ReceiveGenericCommand;
			CoherenceSync.SendGenericCommand = SendGenericCommand;
			CoherenceSync.CreateConnectedEntityUpdateInternal = CreateConnectedEntityUpdateInternal;
		}

		private static string ComponentNameFromTypeId(uint componentTypeId)
		{
			var componentName = Definition.ComponentNameForTypeId(componentTypeId);

			if (string.IsNullOrEmpty(componentName))
			{
				throw new Exception($"Unhandled component type id: {componentTypeId}");
			}

			return componentName;
		}

		private static ICoherenceComponentData[] CreateInitialComponents(CoherenceSync self)
		{
			//Debug.Log($"[CoherenceImplSync.CreateInitialComponents] {self} ({self.remoteVersionPrefabName})");

			var comps = new List<ICoherenceComponentData>();
			comps.Add(new WorldPosition() { value = self.coherencePosition });
			comps.Add(new GenericPrefabReference() { prefab = new FixedString64(self.remoteVersionPrefabName) });

			if (!string.IsNullOrEmpty(self.coherenceUUID))
			{
				comps.Add(new UniqueID() { uuid = self.coherenceUUID });
			}

			if (self.lifetimeType != CoherenceSync.LifetimeType.SessionBased)
			{
				comps.Add(new Persistence());
			}

			return comps.ToArray();
		}

		private static void SendGenericCommand(CoherenceSync self, string commandName, MessageTarget messageTarget, params object[] args)
		{
			SerializeEntityID targetEntity = self.EntityID;
			GenericCommand command = GenericCommandFromObjects(self.MonoBridge, commandName, args);

			if (messageTarget == MessageTarget.AuthorityOnly && self.Client.EntityIsOwned(targetEntity))
			{
				Debug.LogWarning($"Can't send {MessageTarget.AuthorityOnly} command to entity that is owned. Command={commandName} EntityId={targetEntity}");
				return;
			}

			if (!self.Client.EntityExists(targetEntity))
			{
				Debug.LogWarning($"Can't send command to entity that doesn't exist. Command={commandName} EntityId={targetEntity}");
				return;
			}

			self.Client.SendCommand(command, messageTarget, targetEntity);
		}

		private static GenericCommand GenericCommandFromObjects(CoherenceMonoBridge bridge, string commandName, object[] args)
		{
			var (paramInt, paramFloat, paramBool, paramString, paramBytes, paramEntity) =
				TypeArrays.ExtractTypedArraysFromObjects(args, bridge);

			var genericCommand = new GenericCommand
			{
				name = String.IsNullOrEmpty(commandName) ? "" : commandName,

				paramInt1 = paramInt[0],
				paramInt2 = paramInt[1],
				paramInt3 = paramInt[2],
				paramInt4 = paramInt[3],

				paramFloat1 = paramFloat[0],
				paramFloat2 = paramFloat[1],
				paramFloat3 = paramFloat[2],
				paramFloat4 = paramFloat[3],

				paramBool1 = paramBool[0],
				paramBool2 = paramBool[1],
				paramBool3 = paramBool[2],
				paramBool4 = paramBool[3],

				paramEntity1 = paramEntity[0],
				paramEntity2 = paramEntity[1],
				paramEntity3 = paramEntity[2],
				paramEntity4 = paramEntity[3],

				paramString = String.IsNullOrEmpty(paramString[0]) ? "" : paramString[0],
				paramBytes = paramBytes[0] != null && paramBytes[0].Length > 0 ? CoherenceToUnityConverters.ToUnityFixedListByte4096(paramBytes[0]) : new FixedListByte4096()
			};

			return genericCommand;
		}

		private static void ReceiveGenericCommand(CoherenceSync self, IEntityCommand command, MessageTarget target)
		{
			if(!(command is GenericCommand))
			{
				Debug.LogWarning($"[coherenceSync] Received unknown type of command in reflected mode: {command.GetType()}.", self) ;
			}

			var genericCommand = (GenericCommand)command;
			var commandName = genericCommand.name.ToString();
			self.ProcessGenericNetworkCommand(commandName, FromGenericCommand(genericCommand), target);
		}

		private static GenericNetworkCommandArgs FromGenericCommand(GenericCommand command)
		{
			return new GenericNetworkCommandArgs
			{
				Name = command.name.ToString(),

				ParamInt1 = command.paramInt1,
				ParamInt2 = command.paramInt2,
				ParamInt3 = command.paramInt3,
				ParamInt4 = command.paramInt4,

				ParamFloat1 = command.paramFloat1,
				ParamFloat2 = command.paramFloat2,
				ParamFloat3 = command.paramFloat3,
				ParamFloat4 = command.paramFloat4,

				ParamBool1 = command.paramBool1,
				ParamBool2 = command.paramBool2,
				ParamBool3 = command.paramBool3,
				ParamBool4 = command.paramBool4,

				ParamEntity1 = command.paramEntity1,
				ParamEntity2 = command.paramEntity2,
				ParamEntity3 = command.paramEntity3,
				ParamEntity4 = command.paramEntity4,

				ParamString = command.paramString.ToString(),
				ParamBytes = CoherenceToUnityConverters.FromUnityFixedListByte4096(command.paramBytes)
			};
		}

		/*
		private static Type GetGenericScaleType() {
			return typeof(GenericScale);
		}
		*/

		private static (ICoherenceComponentData[], uint[]) CreateConnectedEntityUpdateInternal(CoherenceSync sync, SerializeEntityID parentID)
		{
			var updates = new ICoherenceComponentData[]
			{
				new ConnectedEntity()
				{
					value = parentID,
				},
			};

			var masks = new uint[]
			{
				0b1,
			};

			return (updates, masks);
		}

	}
}