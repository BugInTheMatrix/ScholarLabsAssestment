using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationController : MonoBehaviour
{
    public PlayableDirector timeline;
    public Animator animationControllerForCharacter;
    void Start()
    {
        PauseTimline();
    }
    public void PauseTimline()
    {
        timeline.Pause();
    }
    public void PlayTimeline()
    {
        timeline.Play();
    }
    public void SetAnimationTrigger(string triggerName)
    {
        animationControllerForCharacter.SetTrigger(triggerName);
    }
}
