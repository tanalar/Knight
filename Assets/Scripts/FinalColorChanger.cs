using UnityEngine;

public class FinalColorChanger : MonoBehaviour
{
    [SerializeField] private Material material;

    [SerializeField] private float rFrom;
    [SerializeField] private float gFrom;
    [SerializeField] private float bFrom;

    private float rTo = 1;
    private float gTo = 1;
    private float bTo = 1;

    [SerializeField] private float changeSpeed;

    private float r;
    private float g;
    private float b;
    private bool switcher = false;
    private float currentStep = 100;
    private float maxStep = 100;

    private int fillCounter = 0;

    private bool winSwitcher = false;

    private void Start()
    {
        material.color = new Color(rFrom, gFrom, bFrom);
    }

    private void OnApplicationQuit()
    {
        material.color = new Color(rFrom, gFrom, bFrom);
    }

    private void OnEnable()
    {
        FillEffect.onFilled += ColorChanger;
        BloomEffect.onMaxBloom += TurnOffSwitcher;
    }
    private void OnDisable()
    {
        FillEffect.onFilled -= ColorChanger;
        BloomEffect.onMaxBloom -= TurnOffSwitcher;
    }

    private void ColorChanger()
    {
        fillCounter++;
        if(fillCounter >= 5)
        {
            switcher = true;
        }
    }

    private void Update()
    {
        if (switcher && !winSwitcher)
        {
            currentStep -= changeSpeed * Time.deltaTime * 300;
            r = rFrom - ((rFrom - rTo) / maxStep * (maxStep - currentStep));
            g = gFrom - ((gFrom - gTo) / maxStep * (maxStep - currentStep));
            b = bFrom - ((bFrom - bTo) / maxStep * (maxStep - currentStep));
            material.color = new Color(r, g, b);
        }
    }

    private void TurnOffSwitcher()
    {
        winSwitcher = true;
    }
}
