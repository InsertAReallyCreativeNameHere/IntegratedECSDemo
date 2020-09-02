using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using IntegratedEntites;

// These should have a static constructor that registers this script as a valid component.
// Not doing so won't make Entity calls work.
public class TestComponent : MonoBehaviour
{
    void Awake()
    {
        // This should come first...
        IntegratedEntityRegister<TestComponent>.entityDataInstances.Add(this);
    }

    void OnDestroy()
    {
        // This instruction should come last...
        IntegratedEntityRegister<TestComponent>.entityDataInstances.Remove(this);
    }

    // Components should only have fields and properties,
    // as well as GameObject specific functions like OnEnable.
    [SerializeField] // Woah look I know how to use attributes!
    internal float moveSpeed = 0.2f; // (Example) We don't want external dlls and mods to modify this value, just an example of how.
}