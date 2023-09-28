using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Controllers.Controllable
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Humanoid : MonoBehaviour, IControllableAxis
    {
        private NavMeshAgent _agent;
        private Vector3 _targetDirection;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _targetDirection = Vector3.zero;
        }

        public void Control(bool autopilot, float horizontal, float vertical)
        {
            SetTargetDirection(horizontal, vertical);
            _agent.velocity = _targetDirection * _agent.speed;
        }

        private void SetTargetDirection(float horizontal, float vertical)
        {
            _targetDirection.x = horizontal;
            _targetDirection.z = vertical;
            _targetDirection.Normalize();
        }
    }
}
