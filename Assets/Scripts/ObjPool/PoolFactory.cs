using System.Collections.Generic;

namespace ObjPool
{
    public class PoolFactory
    {
        public Pool Create(List<PoolLibrary> poolLibraries)
        {
            var pool = new Pool();
            poolLibraries.ForEach(library => pool.Load(library));
            
            return pool;
        }
    }
}