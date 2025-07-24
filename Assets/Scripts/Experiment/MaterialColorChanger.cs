using UnityEngine;
using System.Collections;

public class MaterialColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private string colorProperty = "_Tint"; // Usually "_Color" in most shaders
    [SerializeField] private float duration = 2f;             // Time to complete transition

    private MaterialPropertyBlock mpb;
    private AudioManager audioManager;

    private void Awake()
    {
        mpb = new MaterialPropertyBlock();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeColorToRed()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColorRoutine(Color.red));

    }

    private IEnumerator ChangeColorRoutine(Color targetColor)
    {
        targetRenderer.GetPropertyBlock(mpb);
        Color startColor = mpb.GetColor(colorProperty);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            Color currentColor = Color.Lerp(startColor, targetColor, t);
            mpb.SetColor(colorProperty, currentColor);
            targetRenderer.SetPropertyBlock(mpb);
            yield return null;
        }

        mpb.SetColor(colorProperty, targetColor);
        targetRenderer.SetPropertyBlock(mpb);
        audioManager.PlaySFX(audioManager.experimentDone);
        
    }
}