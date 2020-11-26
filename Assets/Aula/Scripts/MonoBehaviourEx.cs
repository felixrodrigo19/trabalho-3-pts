using System;
using UnityEngine;

public static class MonoBehaviourEx
{
    public static T GetComponentInThisOrParent<T>(this MonoBehaviour behaviour)
        where T : Behaviour
    {
        T component = default(T);
        return behaviour.TryGetComponent(out component)
            ? component
            : behaviour.GetComponentInParent<T>();
    }

    public static void PlayClip(this AudioSource source, AudioClip clip, float delay = 0)
    {
        source.clip = clip;
        source.PlayDelayed(delay);
    }
}