using UnityEngine;

using IntegratedEntites;

public class AnotherTestComponent : MonoBehaviour
{
    public System.Action callback = () => { Debug.Log("Wow this was called as a callback function!"); };

    void Awake()
    {
        // This should come first...
        IntegratedEntityRegister<AnotherTestComponent>.entityDataInstances.Add(this);
    }

    void OnDestroy()
    {
        // This instruction should come last...
        IntegratedEntityRegister<AnotherTestComponent>.entityDataInstances.Remove(this);
    }
}
