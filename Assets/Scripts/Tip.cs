using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    [SerializeField] List<GameObject> tips;
    private int trigger = 0;

    private void Start()
    {
        tips[trigger].SetActive(true);
    }

    private void OnEnable()
    {
        TipTrigger.onTipTrigger += RefreshTipList;
    }
    private void OnDisable()
    {
        TipTrigger.onTipTrigger -= RefreshTipList;
    }

    private void RefreshTipList()
    {
        tips[trigger].SetActive(false);
        if(trigger < tips.Count - 1)
        {
            trigger++;
            tips[trigger].SetActive(true);
        }
    }
}
