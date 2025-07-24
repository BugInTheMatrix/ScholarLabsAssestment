using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class InteractionClip : MonoBehaviour
{
    public string animationName;
    public AnimationController animatorController;
    public ConicalFlaskShaker conicalFlaskShaker;
    public BoxCollider testTubeBoxCollider;
    public AudioManager audioManager;
    void Start()
    {
        conicalFlaskShaker = gameObject.GetComponent<ConicalFlaskShaker>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    protected virtual void OnMouseUpAsButton()
    {
        animatorController.SetAnimationTrigger(animationName);
        conicalFlaskShaker.ShakeFlask();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        testTubeBoxCollider.enabled = true;
        audioManager.PlaySFX(audioManager.clickObjectSFX);

        
    }
}
