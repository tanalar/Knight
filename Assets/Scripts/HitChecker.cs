using System;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
    public static Action onBlackHit;
    public static Action onBlackLeft;

    public static Action onWhiteHit;
    public static Action onWhiteLeft;

    [SerializeField]private bool black = false;
    [SerializeField]private bool white = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlackID" && black)
        {
            onBlackHit?.Invoke();
        }
        if (other.gameObject.tag == "WhiteID" && white)
        {
            onWhiteHit?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlackID" && black)
        {
            onBlackLeft?.Invoke();
        }
        if (other.gameObject.tag == "WhiteID" && white)
        {
            onWhiteLeft?.Invoke();
        }
    }
}
