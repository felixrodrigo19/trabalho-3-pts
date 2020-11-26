using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    bool Rotating = true;


    void Update()
    {
        if (Rotating) {
            transform.Rotate(0f, 5f* Time.deltaTime, 0f);   
        }
    }

    void OnMouseDown() {
        enabled = false;
        // Rotating = !Rotating
    }
}

