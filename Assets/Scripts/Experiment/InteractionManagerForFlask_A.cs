using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManagerForFlask_A : InteractionClip
{

    protected override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        gameObject.transform.GetChild(0).GetComponent<MaterialColorChanger>().ChangeColorToRed();



    }
}
