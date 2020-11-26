using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public Collider[] WallsColliders;

    private void Update()
    {
        var isFire1Activated = Input.GetButton("Fire1");
        foreach (var collider in WallsColliders)
        {
            collider.enabled = !isFire1Activated;
        }
    }
}
