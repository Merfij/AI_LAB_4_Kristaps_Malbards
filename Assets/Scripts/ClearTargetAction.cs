using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

namespace GameAI.Lab4
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Clear Target", story: "Clear [Target]", category: "Action", id: "9132afd6345f6a5dd4ac1a4032f599e7")]
    public partial class ClearTargetAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Target;
        [SerializeReference] public BlackboardVariable<bool> HasLineOfSight;
        [SerializeReference] public BlackboardVariable<bool> LastPOSExists;

        protected override Status OnUpdate()
        {
            if (Target != null)
            {
                Target.Value = null;
            }
            if (HasLineOfSight != null)
            {
                HasLineOfSight.Value = false;
            }
            if (LastPOSExists != null)
            {
                LastPOSExists.Value = false;
            }
            return Status.Success;
        }
    }
}

