using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject gameOver;
    public GameObject particleEffectexplode;
    void Start()
    {
        ChnageTheTaskToTesTube();
    }
    public void ChnageTheTaskToTesTube()
    {
        textMeshProUGUI.text = ExperimentStaticValues.touchThetestTube;

    }
    public void ChnageTheTaskToFlask()
    {
        textMeshProUGUI.text = ExperimentStaticValues.touchtheconicalflask;

    }
    public IEnumerator GameOverStart()
    {
        yield return new WaitForSeconds(3);
        EnableGameOver();

     }
    public void EnableGameOver()
    {
        gameOver.SetActive(true);
    }

}
