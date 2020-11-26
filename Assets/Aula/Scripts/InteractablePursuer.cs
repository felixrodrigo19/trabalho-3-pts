using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePursuer : MonoBehaviour
{
    void OnInteract()
    {
        var pursuerComponent = GetComponent<Pursuer>();
        if (pursuerComponent != null)
        {
            pursuerComponent.enabled = !pursuerComponent.enabled;
        }
    }
}
