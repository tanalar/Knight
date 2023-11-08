using UnityEngine;

public class TriggerSwitcher : MonoBehaviour
{
    [SerializeField] GameObject trigger;

    private void OnEnable()
    {
        trigger.SetActive(true);
    }
    private void OnDisable()
    {
        if(trigger != null)
        {
            trigger.SetActive(false);
        }
    }
}
