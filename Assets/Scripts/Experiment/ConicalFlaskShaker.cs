using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class ConicalFlaskShaker : MonoBehaviour
{
    [SerializeField] private float shakeAmount = 2f;  // Smaller angle
    [SerializeField] private float shakeSpeed = 8f;   // Slower oscillation
    [SerializeField] private float shakeTime = 1.0f;  // Duration

    private Vector3 initialRotation;
    private UIController uIController;
    private AnimationController animatorController;
    private AudioManager audioManager;

    private void Start()
    {
        initialRotation = transform.localEulerAngles;
        uIController = FindObjectOfType<UIController>();
        animatorController = FindObjectOfType<AnimationController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void ShakeFlask()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float elapsed = 0f;
        while (elapsed < shakeTime)
        {
            float angle = Mathf.Sin(elapsed * shakeSpeed) * shakeAmount;
            transform.localRotation = Quaternion.Euler(initialRotation + new Vector3(0, 0, angle));
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localEulerAngles = initialRotation;
        animatorController.SetAnimationTrigger("Ideal");
        if (gameObject.CompareTag("FlaskB"))
        {
            uIController.particleEffectexplode.SetActive(true);
            audioManager.PlaySFX(audioManager.experimentFailed);
            StartCoroutine(uIController.GameOverStart());
            yield return null;
        }
        
        uIController.ChnageTheTaskToTesTube();
         

    }
}