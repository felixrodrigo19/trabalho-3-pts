using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : MonoBehaviour
{
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.position);
        transform.Translate(0, 0, 2f * Time.deltaTime);
    }
}
