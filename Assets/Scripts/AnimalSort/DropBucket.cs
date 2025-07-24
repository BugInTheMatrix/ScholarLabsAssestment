using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropBucket : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public string bucketName;
    public RoundController roundController;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            if (bucketName == "Blue")
            {
                roundController.CheckTheAnswerForBlueBucket(dropped.GetComponent<Animal>());

            }
            else if (bucketName == "Red")
            {
                roundController.CheckTheAnswerForRedBucket(dropped.GetComponent<Animal>());

            }
            roundController.numberofObjectPlaced++;
            dropped.GetComponent<Image>().enabled = false;
            roundController.checkObjectsCount();
            roundController.PlaySFX(roundController.audioClipdropBucket);
        }

        // Reset scale on drop
        transform.localScale = originalScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // Enlarge when something is being dragged over it
            transform.localScale = originalScale * 1.1f; // or any desired scale
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Return to normal scale when the dragged item leaves the bucket
        transform.localScale = originalScale;
    }
}