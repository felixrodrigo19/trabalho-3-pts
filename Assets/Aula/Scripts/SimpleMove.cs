using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float Speed;
    public int SomeInt;
    public string SomeString = "Este é um teste";
    public bool SomeSetting = true;
    public GameObject SomeObject;
    public Transform SomeTransform;
    public SimpleRotate SomeRotate;

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0f, 0f);
    }
}
