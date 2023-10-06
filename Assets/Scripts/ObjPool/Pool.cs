using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.Controllable;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjPool
{
   public class Pool 
   {
      private readonly Queue<Humanoid> _poolHumanoids;

      public Pool()
      {
         _poolHumanoids = new Queue<Humanoid>();
      }

      public void Load(PoolLibrary library)
      {
         library.Prefabs.ToList().ForEach( prefab =>
         {
            Enumerable.Range(0, library.Size).ToList().ForEach(_ =>
            {
               var instance = Object.Instantiate(prefab);
               EnqueueComponent(library.Type, instance); 
            });
         });
      }

      private void EnqueueComponent(PoolTypes poolType, GameObject gameObject)
      {
         gameObject.SetActive(false);
         
         switch (poolType)
         {
            case PoolTypes.Humanoid:
               var humanoid = gameObject.GetComponent<Humanoid>();

               if (humanoid == null)
               {
                  throw new NullReferenceException("Humanoid component not found"); 
               }
               
               _poolHumanoids.Enqueue(humanoid);
               
               break;
            
            default:
               throw new ArgumentOutOfRangeException(nameof(poolType), poolType, null);
         }
      }

      public void Deposit<T>(PoolTypes poolType, T component) where T : Component
      {
         component.gameObject.SetActive(false);
         switch (poolType)
         {
            case PoolTypes.Humanoid:
               _poolHumanoids.Enqueue(component as Humanoid);
               break;
            
            default:
               throw new ArgumentOutOfRangeException(nameof(poolType), poolType, null);
         }
      }
      
      public T Draw<T>(PoolTypes poolType) where T : Component
      {
         T component;
         switch (poolType)
         {
            case PoolTypes.Humanoid:
               component = _poolHumanoids.Dequeue() as T;
               break;
           
            default:
               throw new ArgumentOutOfRangeException(nameof(poolType), poolType, null);
         }
         
         component.gameObject.SetActive(true);

         return component;
      } 
   }
}
