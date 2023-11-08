using UnityEngine;

public class FirstTip : MonoBehaviour
{
    [SerializeField] GameObject plane;
    [SerializeField] GameObject tipText;
    [SerializeField] GameObject turnCounter;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject help;
    [SerializeField] GameObject restart;
    [SerializeField] GameObject closeTipButton;
    [SerializeField] Material goalMaterialEmis;
    [SerializeField] Material goalMaterial;
    [SerializeField] MeshRenderer goal1;
    [SerializeField] MeshRenderer goal2;



    private bool switcher = true;
    private int maxStep = 125;
    private float currentStep = 0;

    private float r;
    private float g;
    private float b;

    private float rFrom = 0.2735849f;
    private float gFrom = 0.2735849f;
    private float bFrom = 0.2735849f;

    private float rTo = 1;
    private float gTo = 1;
    private float bTo = 1;



    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstTip") == 0)
        {
            CloseTip();
        }
    }

    public void CloseTip()
    {
        plane.SetActive(false);
        tipText.SetActive(false);
        turnCounter.SetActive(true);
        pause.SetActive(true);
        help.SetActive(true);
        restart.SetActive(true);
        closeTipButton.SetActive(false);
        goal1.material = goalMaterial;
        goal2.material = goalMaterial;

        PlayerPrefs.SetInt("FirstTip", 0);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (switcher)
        {
            if (currentStep < maxStep)
            {
                currentStep += 0.25f * Time.deltaTime * 400;
            }

            if (currentStep >= maxStep)
            {
                switcher = false;
            }
        }
        else
        {
            if (currentStep > 0)
            {
                currentStep -= 0.25f * Time.deltaTime * 400;
            }

            if (currentStep <= 0)
            {
                switcher = true;
            }
        }

        r = rFrom - ((rFrom - rTo) / maxStep * (maxStep - currentStep));
        g = gFrom - ((gFrom - gTo) / maxStep * (maxStep - currentStep));
        b = bFrom - ((bFrom - bTo) / maxStep * (maxStep - currentStep));
        goalMaterialEmis.color = new Color(r, g, b);
    }
}
