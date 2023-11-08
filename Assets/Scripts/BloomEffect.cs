using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomEffect : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private Bloom bloom;

    public static Action onMaxBloom;
    private float minBloom = 0.4f;
    private float currentBloom = 0.75f;
    private float maxBloom = 1f;
    private bool switcher = false;
    private int fillCounter = 0;

    private float rFrom = 1;
    private float gFrom = 1;
    private float bFrom = 1;

    [SerializeField] private float rTo;
    [SerializeField] private float gTo;
    [SerializeField] private float bTo;

    private float r;
    private float g;
    private float b;
    private int maxStep = 290;
    private float currentStep = 0;

    private bool winBloom = false;
    private bool winSwitcher = true;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out bloom);
    }

    private void OnEnable()
    {
        FillEffect.onFilled += Filled;
    }
    private void OnDisable()
    {
        FillEffect.onFilled -= Filled;
    }

    private void Filled()
    {
        fillCounter++;
        if (fillCounter >= 5)
        {
            switcher = true;
        }
    }

    private void Update()
    {
        if (switcher && !winBloom)
        {
            if (currentBloom < maxBloom)
            {
                currentBloom += 0.0004f * Time.deltaTime * 400;
                bloom.intensity.value = currentBloom;

                currentStep += 0.5f * Time.deltaTime * 400;
                r = rFrom - ((rFrom - rTo) / maxStep * currentStep);
                g = gFrom - ((gFrom - gTo) / maxStep * currentStep);
                b = bFrom - ((bFrom - bTo) / maxStep * currentStep);
                bloom.tint.value = new Color(r, g, b);
            }
            
            if(currentBloom >= maxBloom)
            {
                onMaxBloom?.Invoke();
                switcher = false;
                winBloom = true;
            }
        }

        if (winBloom)
        {
            if (winSwitcher)
            {
                if (currentBloom < maxBloom)
                {
                    currentBloom += 0.0005f * Time.deltaTime * 600;
                    bloom.intensity.value = currentBloom;
                }

                if (currentBloom >= maxBloom)
                {
                    winSwitcher = false;
                }
            }
            else
            {
                if (currentBloom > minBloom)
                {
                    currentBloom -= 0.0005f * Time.deltaTime * 600;
                    bloom.intensity.value = currentBloom;
                }

                if (currentBloom <= minBloom)
                {
                    winSwitcher = true;
                }
            }
        }
    }
}
