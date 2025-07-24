using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTubeInteraction : MonoBehaviour
{
    public AnimationController animationController;
    public AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnMouseUpAsButton()
    {
        animationController.PlayTimeline();
        GetComponent<BoxCollider>().enabled = false;
        audioManager.PlaySFX(audioManager.clickObjectSFX);
    }

}
