using Controllers.AI.InterestLocations;
using ObjPool;
using UnityEngine;

namespace Commons
{
    public class SceneState : MBSingleton<SceneState>
    {
        [SerializeField] private PoolLibrary poolLibrary;
        
        public Pool Pool { get; private set; }
        public Locations Locations { get; private set; }
        
        protected override void LoadStates()
        {
            Pool = new PoolFactory().Create(poolLibrary);
            Locations = new Locations();
        }
    }
}