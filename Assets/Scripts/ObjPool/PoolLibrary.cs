using System.Collections.Generic;
using UnityEngine;

namespace ObjPool
{
    [CreateAssetMenu(fileName = "NewPoolLibrary", menuName = "Pool/Library", order = 0)]
    public class PoolLibrary : ScriptableObject
    {
        [SerializeField] private PoolTypes type;
        [SerializeField] private int size;
        [SerializeField] private GameObject[] prefabs;
        
        public PoolTypes Type => type;
        public int Size => size;
        public IEnumerable<GameObject> Prefabs => prefabs;
    }
}