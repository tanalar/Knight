using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class MenuColorChanger : MonoBehaviour
{
    [SerializeField] List<Image> images;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Material emisMenu;
    [SerializeField] Color blueColor;
    [SerializeField] Color blueEmis;
    [SerializeField] Color purpleColor;
    [SerializeField] Color purpleEmis;
    [SerializeField] Color redColor;
    [SerializeField] Color redEmis;

    [SerializeField] Color blue;
    [SerializeField] Color purple;
    [SerializeField] Color red;

    [SerializeField] GameObject blueLoc;
    [SerializeField] GameObject purpleLoc;
    [SerializeField] GameObject redLoc;

    [SerializeField] GameObject bluePoint;
    [SerializeField] GameObject purplePoint;
    [SerializeField] GameObject redPoint;

    public static Action<float> onSnap;



    private float r;
    private float g;
    private float b;

    private float rFrom;
    private float gFrom;
    private float bFrom;

    private float rTo;
    private float gTo;
    private float bTo;



    private float rColor;
    private float gColor;
    private float bColor;

    private float rColorFrom;
    private float gColorFrom;
    private float bColorFrom;

    private float rColorTo;
    private float gColorTo;
    private float bColorTo;



    private float rEmis;
    private float gEmis;
    private float bEmis;

    private float rEmisFrom;
    private float gEmisFrom;
    private float bEmisFrom;

    private float rEmisTo;
    private float gEmisTo;
    private float bEmisTo;



    private float step = 0.9f;
    private float currentStep = 0;
    private float maxStep = 100;

    private void Start()
    {
        r = blue.r;
        g = blue.g;
        b = blue.b;

        rColor = blueColor.r;
        gColor = blueColor.g;
        bColor = blueColor.b;

        rEmis = blueEmis.r;
        gEmis = blueEmis.g;
        bEmis = blueEmis.b;
    }

    private void OnEnable()
    {
        Menu.onStart += SetBlueColor;
    }
    private void OnDisable()
    {
        Menu.onStart -= SetBlueColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BlueLevels")
        {
            onSnap?.Invoke(0f);
            SetBlueColor();
        }
        if (other.gameObject.tag == "PurpleLevels")
        {
            onSnap?.Invoke(1920f);
            SetPurpleColor();
        }
        if (other.gameObject.tag == "RedLevels")
        {
            onSnap?.Invoke(3840f);
            SetRedColor();
        }
    }

    private void SetBlueColor()
    {
        //scroll points change
        bluePoint.SetActive(true);
        purplePoint.SetActive(false);
        redPoint.SetActive(false);

        //location models change
        blueLoc.SetActive(true);
        purpleLoc.SetActive(false);
        redLoc.SetActive(false);

        rFrom = r;
        gFrom = g;
        bFrom = b;
        rTo = blue.r;
        gTo = blue.g;
        bTo = blue.b;

        rColorFrom = rColor;
        gColorFrom = gColor;
        bColorFrom = bColor;
        rColorTo = blueColor.r;
        gColorTo = blueColor.g;
        bColorTo = blueColor.b;

        rEmisFrom = rEmis;
        gEmisFrom = gEmis;
        bEmisFrom = bEmis;
        rEmisTo = blueEmis.r;
        gEmisTo = blueEmis.g;
        bEmisTo = blueEmis.b;

        currentStep = 100;
    }
    private void SetPurpleColor()
    {
        //scroll points change
        bluePoint.SetActive(false);
        purplePoint.SetActive(true);
        redPoint.SetActive(false);

        //location models change
        blueLoc.SetActive(false);
        purpleLoc.SetActive(true);
        redLoc.SetActive(false);

        rFrom = r;
        gFrom = g;
        bFrom = b;
        rTo = purple.r;
        gTo = purple.g;
        bTo = purple.b;

        rColorFrom = rColor;
        gColorFrom = gColor;
        bColorFrom = bColor;
        rColorTo = purpleColor.r;
        gColorTo = purpleColor.g;
        bColorTo = purpleColor.b;

        rEmisFrom = rEmis;
        gEmisFrom = gEmis;
        bEmisFrom = bEmis;
        rEmisTo = purpleEmis.r;
        gEmisTo = purpleEmis.g;
        bEmisTo = purpleEmis.b;

        currentStep = 100;
    }
    private void SetRedColor()
    {
        //scroll points change
        bluePoint.SetActive(false);
        purplePoint.SetActive(false);
        redPoint.SetActive(true);

        //location models change
        blueLoc.SetActive(false);
        purpleLoc.SetActive(false);
        redLoc.SetActive(true);

        rFrom = r;
        gFrom = g;
        bFrom = b;
        rTo = red.r;
        gTo = red.g;
        bTo = red.b;

        rColorFrom = rColor;
        gColorFrom = gColor;
        bColorFrom = bColor;
        rColorTo = redColor.r;
        gColorTo = redColor.g;
        bColorTo = redColor.b;

        rEmisFrom = rEmis;
        gEmisFrom = gEmis;
        bEmisFrom = bEmis;
        rEmisTo = redEmis.r;
        gEmisTo = redEmis.g;
        bEmisTo = redEmis.b;

        currentStep = 100;
    }

    private void Update()
    {
        if(currentStep > 0)
        {
            currentStep -= step * Time.deltaTime * 500;
            r = rFrom - ((rFrom - rTo) / maxStep * (maxStep - currentStep));
            g = gFrom - ((gFrom - gTo) / maxStep * (maxStep - currentStep));
            b = bFrom - ((bFrom - bTo) / maxStep * (maxStep - currentStep));
            Color rgb = new Color(r, g, b);

            rColor = rColorFrom - ((rColorFrom - rColorTo) / maxStep * (maxStep - currentStep));
            gColor = gColorFrom - ((gColorFrom - gColorTo) / maxStep * (maxStep - currentStep));
            bColor = bColorFrom - ((bColorFrom - bColorTo) / maxStep * (maxStep - currentStep));
            Color rgbColor = new Color(rColor, gColor, bColor);

            rEmis = rEmisFrom - ((rEmisFrom - rEmisTo) / maxStep * (maxStep - currentStep));
            gEmis = gEmisFrom - ((gEmisFrom - gEmisTo) / maxStep * (maxStep - currentStep));
            bEmis = bEmisFrom - ((bEmisFrom - bEmisTo) / maxStep * (maxStep - currentStep));
            Color rgbEmis = new Color(rEmis, gEmis, bEmis);

            //text color
            text.color = rgb;

            //images color
            for (int i = 0; i < images.Count; i++)
            {
                images[i].color = rgb;
            }

            //material color
            emisMenu.color = rgbColor;
            emisMenu.SetColor("_EmissionColor", rgbEmis);
        }
    }
}
