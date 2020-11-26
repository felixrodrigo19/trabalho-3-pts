using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimationTarget : MonoBehaviour
{
    Animation Animation;
    AudioSource AudioSource;

    public AnimationData[] Clips;
    public int CurrentAnimationIndex = 0;

    private void Start()
    {
        Animation = this.GetComponentInThisOrParent<Animation>();
        AudioSource = this.GetComponentInThisOrParent<AudioSource>();
    }

    void OnInteract()
    {
        if (!Animation.isPlaying)
        {
            var clip = Clips[CurrentAnimationIndex];
            Animation.Play(clip.AnimationClip.name);
            if (AudioSource != null)
            {
                AudioSource.PlayClip(clip.AudioClip, clip.AudioDelay);
            }
            CurrentAnimationIndex = (CurrentAnimationIndex + 1) % Clips.Length;
        }
    }
}
