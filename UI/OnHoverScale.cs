
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform target;
    public Ease ease = Ease.Linear;
    public float duration = 0.1f;
    public Vector3 baseScale = Vector3.one;
    public Vector3 hoverScale = Vector3.one * 1.1f;

    private void Awake()
    {
        if (target == null)
        {
            target = transform;
        }
    }
    private void OnEnable()
    {
        target.localScale = baseScale;
    }
    private void OnDisable()
    {
        target.localScale = baseScale;
    }
    private void OnDestroy()
    {
        DOTween.Kill(target);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        target.DOScale(hoverScale, duration).SetEase(ease);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target.DOScale(baseScale, duration).SetEase(ease);
    }
}