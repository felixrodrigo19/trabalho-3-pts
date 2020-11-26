using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHook : MonoBehaviour
{
    HashSet<GameObject> m_HookedObjects = new HashSet<GameObject>();
    Vector3 m_OldPosition;

    private void OnTriggerEnter(Collider other)
    {
        m_HookedObjects.Add(other.gameObject);
        other.gameObject.BroadcastMessage("OnPlatformHook");
    }

    private void OnTriggerExit(Collider other)
    {
        m_HookedObjects.Remove(other.gameObject);
        other.gameObject.BroadcastMessage("OnPlatformUnhook");
    }

    private void Start()
    {
        m_OldPosition = transform.position;
    }

    private void Update()
    {
        var movement = transform.position - m_OldPosition;

        foreach(var hookedObject in m_HookedObjects)
        {
            hookedObject.BroadcastMessage("OnPlatformMove", movement);
        }

        m_OldPosition = transform.position;
    }
}
