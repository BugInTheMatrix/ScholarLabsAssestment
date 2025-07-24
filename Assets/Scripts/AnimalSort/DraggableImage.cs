using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Vector3 originalPosition;
    private RoundController roundController;
    public string animalName;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent;
        originalPosition = rectTransform.localPosition;
        roundController = FindObjectOfType<RoundController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root); // Optional: Bring to top
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.root.GetComponent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(originalParent);
        rectTransform.localPosition = originalPosition;

        // If not dropped into a valid container, go back to original
        if (transform.parent == transform.root)
        {

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Image clicked: " + gameObject.name);
        roundController.DisplayInfo(animalName);
        roundController.PlaySFX(roundController.clickButtonAudio);
    }
}
