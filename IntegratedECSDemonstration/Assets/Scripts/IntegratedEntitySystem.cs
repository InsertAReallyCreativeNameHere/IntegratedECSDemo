using System.Collections.Generic;
using UnityEngine;

namespace IntegratedEntites
{
    public class IntegratedEntitySystem : MonoBehaviour
    {
        // This should be the only update function in the ECS System, every component should be managed from here, 
        // this reduces function call overhead and makes you more aware and able to optimise your code.
        // You may add an awake and start method as well.
        void Update()
        {
            // There should never be more than one call to the same Entities.ForEach,
            // that is wasted performance. This is why ECS is objectively better.
            // Better performance that is easier to achieve.
            /*Entities.ForEach<TestComponent>(compdata1 =>
            {
                Entities.ForEach<AnotherTestComponent>(compdata2 =>
                {

                });
            });
            Entities.ForEach<TestComponent>(compdata1 =>
            {
            });
            */

            Entities.ForEach<TestComponent>(comp =>
            {
                Debug.Log("Wow look I found a TestComponent script!");
            });

            // Never have 2 same Entitiies.ForEach calls with same parameters ever,
            // this is an example to show that both foreach calls work.
            /*
                If you want to achive what both these calls do into one merged, try:
                
                Entities.ForEach<TestComponent>(comp =>
                {
                    Entities.ForEach<AnotherTestComponent>(anotherComp =>
                    {
                        // Stuff.
                    });
                });
            */
            Entities.ForEach<TestComponent, AnotherTestComponent>((t, u) =>
            {
                t.transform.Translate(t.moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, t.moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
                // Some callback like this should be static,
                // I couldn't think of a better example.
                u.callback();
            });
        }
    }
}