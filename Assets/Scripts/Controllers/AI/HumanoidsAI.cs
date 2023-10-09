using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Commons;
using Controllers.AI.InterestLocations;
using Controllers.Controllable;
using ObjPool;
using UnityEngine;

namespace Controllers.AI
{
    public class HumanoidsAI : MonoBehaviour
    {
        private const AITypes PoolType = AITypes.Humanoid;
        private const bool AutoPilot = true;

        private readonly Dictionary<Humanoid, Vector3> _humanoidsPositions = new ();
        
        private Pool _pool;
        private Locations _locations;
        
        [SerializeField]
        private uint spawnRateSec = 1;
        [SerializeField]
        private float distanceThreshold = 1.5f;

        private void Start()
        {
            _pool = SceneState.Instance.Pool;
            _locations = SceneState.Instance.Locations;
            StartCoroutine(SpawnHumanoid());
        } 

        private void FixedUpdate()
        {
            RemoveWhenDestinationReached();
        }

        private void RemoveWhenDestinationReached()
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
            var targetPosition = _locations.GetRandomPoint(PoolType);
            
            human.transform.position = _locations.GetRandomPoint(PoolType);
            _humanoidsPositions.Add(human, targetPosition);
            
            human.Control(AutoPilot, targetPosition.x, targetPosition.z);

            yield return new WaitForSeconds(spawnRateSec);

            StartCoroutine(SpawnHumanoid());
        }
    }
}