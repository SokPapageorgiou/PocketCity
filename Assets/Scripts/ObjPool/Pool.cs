using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjPool
{
   public class Pool 
   {
      private readonly Dictionary<PoolTypes, Queue<GameObject>> _poolDictionary;

      public Pool()
      {
         _poolDictionary = new Dictionary<PoolTypes, Queue<GameObject>>();
         
         foreach (PoolTypes poolType in System.Enum.GetValues(typeof(PoolTypes)))
         {
            _poolDictionary.Add(poolType, new Queue<GameObject>());
         }
      }

      public void Load(PoolLibrary library)
      {
         library.Prefabs.ToList().ForEach( prefab =>
         {
            Enumerable.Range(0, library.Size).ToList().ForEach(_ =>
            {
               var instance = Object.Instantiate(prefab);
               Deposit(library.Type, instance); 
            });
         });
      }
      
      public void Deposit(PoolTypes poolType, GameObject gameObject)
      {
         gameObject.SetActive(false);
         _poolDictionary[poolType].Enqueue(gameObject);
      } 
      
      public GameObject Draw(PoolTypes poolType)
      {
         var gameObject = _poolDictionary[poolType].Dequeue();
         gameObject.SetActive(true);
         
         return gameObject;
      } 
   }
}
