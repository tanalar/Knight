using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MenuBloom : MonoBehaviour
{
    //bloom
    [SerializeField] private Volume volume;
    private Bloom bloom;

    private float currentBloom = 0.75f;
    private float minBloom = 0.75f;
    private float maxBloom = 1f;
    private bool switcher = true;

    private float rFrom = 1;
    private float gFrom = 1;
    private float bFrom = 1;

    private float rTo = 0.49f;
    private float gTo = 0.67f;
    private float bTo = 0.81f;

    private float r;
    private float g;
    private float b;
    private int maxStep = 290;
    private float currentStep = 0;



    //color
    [SerializeField] private Material material;

    private float rColorFrom = 1;
    private float gColorFrom = 1;
    private float bColorFrom = 1;

    private float rColorTo = 0;
    private float gColorTo = 0.4729459f;
    private float bColorTo = 0.8018868f;

    //[SerializeField] private float changeSpeed;

    private float rColor;
    private float gColor;
    private float bColor;


    private void Start()
    {
        //bloom
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out bloom);

        //color
        material.color = new Color(rColorTo, gColorTo, bColorTo);
    }
    private void OnApplicationQuit()
    {
        material.color = new Color(rColorTo, gColorTo, bColorTo);
    }

    private void Update()
    {
        if (switcher)
        {
            if (currentBloom < maxBloom)
            {
                currentBloom += 0.00025f * Time.deltaTime * 400;
                bloom.intensity.value = currentBloom;
                currentStep += 0.25f * Time.deltaTime * 400;
            }

            if (currentBloom >= maxBloom)
            {
                switcher = false;
            }
        }
        else
        {
            if (currentBloom > minBloom)
            {
                currentBloom -= 0.00025f * Time.deltaTime * 400;
                bloom.intensity.value = currentBloom;
                currentStep -= 0.25f * Time.deltaTime * 400;
            }

            if (currentBloom <= minBloom)
            {
                switcher = true;
            }
        }

        //bloom
        r = rFrom - ((rFrom - rTo) / maxStep * currentStep);
        g = gFrom - ((gFrom - gTo) / maxStep * currentStep);
        b = bFrom - ((bFrom - bTo) / maxStep * currentStep);
        bloom.tint.value = new Color(r, g, b);

        //color
        rColor = rColorFrom - ((rColorFrom - rColorTo) / maxStep * (maxStep - currentStep));
        gColor = gColorFrom - ((gColorFrom - gColorTo) / maxStep * (maxStep - currentStep));
        bColor = bColorFrom - ((bColorFrom - bColorTo) / maxStep * (maxStep - currentStep));
        material.color = new Color(rColor, gColor, bColor);
    }
}
