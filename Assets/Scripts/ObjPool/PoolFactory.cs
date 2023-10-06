using System.Collections.Generic;

namespace ObjPool
{
    public class PoolFactory
    {
        public Pool Create(PoolLibrary library)
        {
            var pool = new Pool();
            pool.Load(library);
            
            return pool;
        }
    }
}