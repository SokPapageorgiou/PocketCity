using System.Collections.Generic;
using ObjPool;
using UnityEngine;

namespace Commons
{
    public class SceneState : MBSingleton<SceneState>
    {
        [SerializeField] private PoolLibrary poolLibraries;
        
        public Pool Pool { get; private set; }
        
        protected override void LoadStates()
        {
            Pool = new PoolFactory().Create(poolLibraries);
        }
    }
}