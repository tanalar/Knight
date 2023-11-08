using System;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    public static Action onTipTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tip")
        {
            onTipTrigger?.Invoke();
        }
    }
}
