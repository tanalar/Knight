using UnityEngine;

public class SnapScroll : MonoBehaviour
{
    RectTransform content;
    private Vector2 contentVector;
    private float nextSnapPosition;
    private bool isScrolling;

    private void Start()
    {
        content = GetComponent<RectTransform>();
        nextSnapPosition = 0;
        isScrolling = false;
    }

    private void OnEnable()
    {
        MenuColorChanger.onSnap += ChangeSnapPosition;
    }
    private void OnDisable()
    {
        MenuColorChanger.onSnap -= ChangeSnapPosition;
    }

    private void FixedUpdate()
    {
        if (isScrolling) return;

        contentVector.x = Mathf.SmoothStep(content.anchoredPosition.x, nextSnapPosition, 7.5f * Time.deltaTime);
        content.anchoredPosition = contentVector;
    }

    private void ChangeSnapPosition(float snapPosition)
    {
        nextSnapPosition = -snapPosition;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }
}
