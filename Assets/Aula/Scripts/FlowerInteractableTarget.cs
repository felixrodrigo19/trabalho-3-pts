using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteractableTarget : MonoBehaviour
{
    public Collider LayingCollider;
    public Collider StandingCollider;

    void OnInteract()
    {
        var animator = this.GetComponentInThisOrParent<Animator>();

        //var state = animator.GetCurrentAnimatorStateInfo(0);
        //if (state.IsName("idle"))
        //{
        //    LayingCollider.enabled = true;
        //    StandingCollider.enabled = false;
        //}
        //else if (state.IsName("die"))
        //{
        //    LayingCollider.enabled = false;
        //    StandingCollider.enabled = true;
        //}
        animator.SetTrigger("selected");
    }

    void ReviveBegins()
    {
        var animator = this.GetComponentInThisOrParent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.speed * state.speedMultiplier < 0)
        {
            LayingCollider.enabled = true;
            StandingCollider.enabled = false;
        }
    }

    void ReviveEnds()
    {
        var animator = this.GetComponentInThisOrParent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.speed * state.speedMultiplier > 0)
        {
            LayingCollider.enabled = false;
            StandingCollider.enabled = true;
        }
    }

    void PlaySound(UnityEngine.Object audioClip)
    {
        var animator = this.GetComponentInThisOrParent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.speed * state.speedMultiplier > 0)
        {
            var trueSoundClip = (AudioClip)audioClip;
            var audioSource = this.GetComponentInThisOrParent<AudioSource>();
            audioSource.pitch = 1;
            audioSource.clip = trueSoundClip;
            audioSource.time = 0;
            audioSource.Play();
        }
    }

    void PlaySoundInReverse(UnityEngine.Object audioClip)
    {
        var animator = this.GetComponentInThisOrParent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.speed * state.speedMultiplier < 0)
        {
            var trueSoundClip = (AudioClip)audioClip;
            var audioSource = this.GetComponentInThisOrParent<AudioSource>();
            audioSource.pitch = -1;
            audioSource.clip = trueSoundClip;
            audioSource.time = trueSoundClip.length - 0.01f;
            audioSource.Play();
        }
    }
}
