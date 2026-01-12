using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

namespace GameAI.Lab4
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Update Perception", story: "Update Perception", category: "Action", id: "722fecdbaa757779d138b5673a379689")]
    public partial class UpdatePerceptionAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Target;
        [SerializeReference] public BlackboardVariable<bool> HasLineOfSight;
        [SerializeReference] public BlackboardVariable<Vector3> LastKnownPosition;

        protected override Status OnUpdate()
        {
            Debug.Log(HasLineOfSight.Value.ToString());
            var sensors = GameObject != null ? GameObject.GetComponent<GuardSensors>() : null;
            if (sensors == null)
            {
                if (HasLineOfSight != null)
                    HasLineOfSight.Value = false;

                return Status.Success;
            }

            bool sensed = sensors.TrySenseTarget(
                out GameObject sensedTarget,
                out Vector3 sensedPos,
                out bool hasLOS
            );

            if (sensed && hasLOS)
            {
                if (Target != null)
                    Target.Value = sensedTarget;

                if (HasLineOfSight != null)
                    HasLineOfSight.Value = true;

                if (LastKnownPosition != null)
                    LastKnownPosition.Value = sensedPos;
            }
            else
            {
                if (HasLineOfSight != null)
                    HasLineOfSight.Value = false;
            }
            return Status.Success;
        }
    }
}
   

