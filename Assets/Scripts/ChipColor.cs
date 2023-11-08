using System.Collections;
using UnityEngine;

public class ChipColor : MonoBehaviour
{
    private new Renderer renderer;

    [SerializeField] private float rFrom;
    [SerializeField] private float gFrom;
    [SerializeField] private float bFrom;

    [SerializeField] private float rTo;
    [SerializeField] private float gTo;
    [SerializeField] private float bTo;

    private float r;
    private float g;
    private float b;
    private int currentStep = 0;
    private int minStep = 0;
    private int maxStep = 10;
    private bool colorSwitcher = true;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(rTo, gTo, bTo);
    }

    private IEnumerator ColorChanger()
    {
        if (colorSwitcher)
        {
            if(currentStep < maxStep)
            {
                currentStep++;
            }
            if(currentStep >= maxStep)
            {
                StopAllCoroutines();
            }
        }
        else
        {
            if (currentStep > minStep)
            {
                currentStep--;
            }
            if (currentStep <= minStep)
            {
                StopAllCoroutines();
            }
        }

        r = rFrom - ((rFrom - rTo) / maxStep * (maxStep - currentStep));
        g = gFrom - ((gFrom - gTo) / maxStep * (maxStep - currentStep));
        b = bFrom - ((bFrom - bTo) / maxStep * (maxStep - currentStep));
        renderer.material.color = new Color(r, g, b);

        yield return new WaitForSeconds(0.025f);
        StartCoroutine(ColorChanger());
    }

    public void FlashOn()
    {
        colorSwitcher = true;
        StartCoroutine(ColorChanger());
    }
    public void FlashOff()
    {
        colorSwitcher = false;
        StartCoroutine(ColorChanger());
    }
}
