// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;

	public class Binding_7e3d37204c8666b4c937cb8f886bf046_4403516e_b7c1_442d_bc0d_6d530a39a292 : FloatBinding
	{
		private GameManager CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (GameManager)UnityComponent;
		}
		public override string CoherenceComponentName => "Canvas_GameManager_427223106663654601";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override float Value
		{
			get => (float)(System.Single)(CastedUnityComponent.totalProgress);
			set => CastedUnityComponent.totalProgress = (System.Single)(value);
		}

		protected override float ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Canvas_GameManager_427223106663654601)coherenceComponent;
			return update.totalProgress;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Canvas_GameManager_427223106663654601)coherenceComponent;
			update.totalProgress = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Canvas_GameManager_427223106663654601();
		}
	}

	public class Binding_7e3d37204c8666b4c937cb8f886bf046_a759db69_2333_4adc_8e11_b29d9d567c09 : FloatBinding
	{
		private Timer CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (Timer)UnityComponent;
		}
		public override string CoherenceComponentName => "Canvas_Timer_8893252593726448033";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override float Value
		{
			get => (float)(System.Single)(CastedUnityComponent._currentTime);
			set => CastedUnityComponent._currentTime = (System.Single)(value);
		}

		protected override float ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Canvas_Timer_8893252593726448033)coherenceComponent;
			return update._currentTime;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Canvas_Timer_8893252593726448033)coherenceComponent;
			update._currentTime = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Canvas_Timer_8893252593726448033();
		}
	}


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked 'Canvas' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSyncCanvas : CoherenceSyncBaked
	{
		private CoherenceSync coherenceSync;
		private Logger logger;

		// Cached targets for commands

		private IClient client;
		private CoherenceMonoBridge monoBridge => coherenceSync.MonoBridge;

		protected void Awake()
		{
			coherenceSync = GetComponent<CoherenceSync>();
			coherenceSync.usingReflection = false;

			logger = coherenceSync.logger.With<CoherenceSyncCanvas>();
			if (coherenceSync.TryGetBindingByGuid("4403516e-b7c1-442d-bc0d-6d530a39a292", "totalProgress", out Binding InternalCanvas_GameManager_427223106663654601_Canvas_GameManager_427223106663654601_totalProgress))
			{
				var clone = new Binding_7e3d37204c8666b4c937cb8f886bf046_4403516e_b7c1_442d_bc0d_6d530a39a292();
				InternalCanvas_GameManager_427223106663654601_Canvas_GameManager_427223106663654601_totalProgress.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalCanvas_GameManager_427223106663654601_Canvas_GameManager_427223106663654601_totalProgress)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (GameManager).totalProgress");
			}
			if (coherenceSync.TryGetBindingByGuid("a759db69-2333-4adc-8e11-b29d9d567c09", "_currentTime", out Binding InternalCanvas_Timer_8893252593726448033_Canvas_Timer_8893252593726448033__currentTime))
			{
				var clone = new Binding_7e3d37204c8666b4c937cb8f886bf046_a759db69_2333_4adc_8e11_b29d9d567c09();
				InternalCanvas_Timer_8893252593726448033_Canvas_Timer_8893252593726448033__currentTime.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalCanvas_Timer_8893252593726448033_Canvas_Timer_8893252593726448033__currentTime)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (Timer)._currentTime");
			}
		}

		public override List<ICoherenceComponentData> CreateEntity()
		{
			if (coherenceSync.UsesLODsAtRuntime && (Archetypes.IndexForName.TryGetValue(coherenceSync.Archetype.ArchetypeName, out int archetypeIndex)))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
			else
			{
				logger.Warning($"Unable to find archetype {coherenceSync.Archetype.ArchetypeName} in dictionary. Please, bake manually (coherence > Bake)");
			}

			return null;
		}

		public override void Initialize(CoherenceSync sync, IClient client)
		{
			if (coherenceSync == null)
			{
				coherenceSync = sync;
			}
			this.client = client;
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				default:
					logger.Warning($"[CoherenceSyncCanvas] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}