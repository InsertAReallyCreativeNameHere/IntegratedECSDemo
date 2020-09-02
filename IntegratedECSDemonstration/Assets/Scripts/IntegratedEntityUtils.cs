using System.Collections.Generic;
using UnityEngine;

namespace IntegratedEntites
{
    public static class IntegratedEntityRegister<T>
    {
        public static List<T> entityDataInstances = new List<T>();
    }

    public static class Entities
    {
        public static void ForEach<T>(System.Action<T> action) where T : MonoBehaviour
        {
            for (int i = 0; i < IntegratedEntityRegister<T>.entityDataInstances.Count; i++)
                action(IntegratedEntityRegister<T>.entityDataInstances[i]);
        }
        
        public static void ForEach<T, U>(System.Action<T, U> action) where T : MonoBehaviour where U : MonoBehaviour
        {
            for (int i = 0; i < IntegratedEntityRegister<T>.entityDataInstances.Count; i++)
            {
                T t = IntegratedEntityRegister<T>.entityDataInstances[i];
                GameObject entity = t.gameObject;
                for (int j = 0; j < IntegratedEntityRegister<U>.entityDataInstances.Count; j++)
                {
                    U u = IntegratedEntityRegister<U>.entityDataInstances[j];
                    if (entity == u.gameObject)
                        action(t, u);
                }
            }
        }

        // You can expand these functions to support more if you want!
    }
}