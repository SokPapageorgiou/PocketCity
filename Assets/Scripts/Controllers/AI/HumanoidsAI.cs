using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Commons;
using Controllers.Controllable;
using ObjPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.AI
{
    public class HumanoidsAI : MonoBehaviour
    {
        private const PoolTypes PoolType = PoolTypes.Humanoid;
        private const bool AutoPilot = true;

        private readonly Dictionary<Humanoid, Vector3> _humanoidsPositions = new ();
        
        private Pool _pool;
        
        [SerializeField]
        private uint spawnRateSec = 1;
        [SerializeField]
        private float distanceThreshold = 1.5f;

        private void Start()
        {
            _pool = SceneState.Instance.Pool;

            StartCoroutine(SpawnHumanoid());
        } 

        private void FixedUpdate()
        {
            RemoveDestinationReached();
        }

        private void RemoveDestinationReached()
        {
            _humanoidsPositions
                .Where(humanoid =>
                    Vector3.Distance(humanoid.Key.transform.position, humanoid.Value) < distanceThreshold)
                .ToList()
                .ForEach(humanoid =>
                {
                    _humanoidsPositions.Remove(humanoid.Key);
                    _pool.Deposit(PoolType, humanoid.Key);
                });
        }

        private IEnumerator SpawnHumanoid()
        {
            var human = _pool.Draw<Humanoid>(PoolType);
            var targetPosition = RandomPosition();
            
            human.transform.position = RandomPosition();
            _humanoidsPositions.Add(human, targetPosition);
            
            human.Control(AutoPilot, targetPosition.x, targetPosition.z);

            yield return new WaitForSeconds(spawnRateSec);

            StartCoroutine(SpawnHumanoid());
        }

        private static Vector3 RandomPosition() => new (Random.Range(-9, 9), 0, Random.Range(-9, 9));
    }
}