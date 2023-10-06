using System.Collections.Generic;
using Controllers.Controllable;
using UnityEngine;

namespace ObjPool
{
    [CreateAssetMenu(fileName = "NewPoolLibrary", menuName = "Pool/Library", order = 0)]
    public class PoolLibrary : ScriptableObject
    {
        [Header("Humanoid Pool")]
        [SerializeField] private int sizeHumanoids;
        [SerializeField] private Humanoid[] humanoids;
        
        public int SizeHumanoids => sizeHumanoids;
        public IEnumerable<Humanoid> Humanoids => humanoids;
    }
}