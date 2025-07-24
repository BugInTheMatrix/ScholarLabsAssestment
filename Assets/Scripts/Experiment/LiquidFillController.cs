using System.Collections;
using UnityEngine;

public class LiquidFillController : MonoBehaviour
{
    [SerializeField] private Renderer liquidRenderer;
    [SerializeField] private string propertyName = "_FillAmount";
    [SerializeField] private float duration = 2f;

    public float startValue;
    public float endValue;

    private MaterialPropertyBlock mpb;

    private void Awake()
    {
        mpb = new MaterialPropertyBlock();
    }

    public void ChangeFill()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFillRoutine());
    }

    private IEnumerator ChangeFillRoutine()
    {
        liquidRenderer.GetPropertyBlock(mpb);
        Debug.Log("Start Value " + startValue);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            float value = Mathf.Lerp(startValue, endValue, t);

            mpb.SetFloat(propertyName, value);
            liquidRenderer.SetPropertyBlock(mpb);

            yield return null;
        }

        mpb.SetFloat(propertyName, endValue);
        liquidRenderer.SetPropertyBlock(mpb);
    }
    public void ChangeIntialValueForTesTube()
    {
        startValue = endValue;
        endValue = 1;

    }
}