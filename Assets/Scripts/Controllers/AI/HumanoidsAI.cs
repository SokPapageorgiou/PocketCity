using System.Collections.Generic;
using Controllers.Controllable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.AI
{
    public class HumanoidsAI : MonoBehaviour
    {
        private const bool AutoPilot = true;

        [SerializeField]
        private List<Humanoid> humanoids;

        private readonly Dictionary<Humanoid, Vector3> _humanoidsPositions = new ();

        private void Awake()
        {
            foreach (var humanoid in humanoids)
            {
                _humanoidsPositions.Add(humanoid,RandomPosition());
            }
        }

        private void FixedUpdate()
        {
            foreach (var humanoid in _humanoidsPositions)
            {
                humanoid.Key.Control(AutoPilot, humanoid.Value.x, humanoid.Value.z);
            }
        }
        
        private Vector3 RandomPosition() => new (Random.Range(-9, 9), 0, Random.Range(-9, 9));
    }
}