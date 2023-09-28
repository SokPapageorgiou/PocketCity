using UnityEngine;
using UnityEngine.AI;

namespace Controllers.Controllable
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class ControllableAxis : MonoBehaviour, IControllableAxis
    {
        protected NavMeshAgent Agent;
        protected Vector3 TargetDirection;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            TargetDirection = Vector3.zero;
        }

        public void Control(bool autopilot, float horizontal, float vertical)
        {
            SetTargetDirection(horizontal, vertical);
            
            if (autopilot)
            {
                RunAutopilot();
            }
            else
            {
                RunManual();
            }
        }
        
        private void RunAutopilot()
        {
            Agent.Move(TargetDirection);
        }

        private void SetTargetDirection(float horizontal, float vertical)
        {
            TargetDirection.x = horizontal;
            TargetDirection.z = vertical;
            TargetDirection.Normalize();
        }

        protected abstract void RunManual();
    }
}