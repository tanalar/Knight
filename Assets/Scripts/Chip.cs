using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField] private ChipColor ChipColor;
    private int counter = 0;
    private bool tipIsActive = false;
    private int tipCounter = 0;

    private void Start()
    {
        ChipColor = GetComponent<ChipColor>();
    }

    private void OnEnable()
    {
        UI.onHelp += TipIsActive;
    }
    private void OnDisable()
    {
        UI.onHelp -= TipIsActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            counter++;
            tipCounter = 0;
            ChipColor.FlashOff();
        }

        if(other.gameObject.tag == "TurnVariant" && counter == 0 && !tipIsActive)
        {
            gameObject.layer = 6;
            ChipColor.FlashOn();
        }
        if(other.gameObject.tag == "TurnVariant" && tipIsActive)
        {
            tipCounter++;
            if (tipCounter == 2)
            {
                gameObject.layer = 6;
                ChipColor.FlashOn();
            }
        }
        if(other.gameObject.tag == "Tip" && tipIsActive)
        {
            tipCounter++;
            if (tipCounter == 2)
            {
                gameObject.layer = 6;
                ChipColor.FlashOn();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            counter--;
        }

        if (other.gameObject.tag == "TurnVariant" || counter > 0)
        {
            tipCounter--;
            if(tipCounter < 0)
            {
                tipCounter = 0;
            }
            gameObject.layer = 0;
            ChipColor.FlashOff();
        }
        if(other.gameObject.tag == "Tip")
        {
            tipCounter--;
            if (tipCounter < 0)
            {
                tipCounter = 0;
            }
        }
    }

    private void TipIsActive()
    {
        if (!tipIsActive)
        {
            tipIsActive = true;
        }
        else
        {
            tipIsActive = false;
        }
    }
}
