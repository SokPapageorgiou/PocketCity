using System.Collections.Generic;
using Controllers.AI;
using ObjPool;
using UnityEngine;

namespace Commons
{
    public class SceneState : MBSingleton<SceneState>
    {
        [SerializeField] private PoolLibrary poolLibrary;
        
        public Pool Pool { get; private set; }
        public InterestPoints InterestPoints { get; private set; }
        
        protected override void LoadStates()
        {
            Pool = new PoolFactory().Create(poolLibrary);
            InterestPoints = new InterestPoints();
        }
    }
}