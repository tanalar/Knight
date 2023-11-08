using System;
using UnityEngine;

public class FillEffect : MonoBehaviour
{
    [SerializeField] private new Renderer renderer;
    [SerializeField] private float fill;
    private float randomFillStep;
    private bool switcher = false;
    public static Action onFilled;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_Fill", fill);
        randomFillStep = UnityEngine.Random.Range(0.015f, 0.03f);
    }

    private void OnEnable()
    {
        Goal.onPlayerHitGoal += StartFill;
    }
    private void OnDisable()
    {
        Goal.onPlayerHitGoal -= StartFill;
    }

    private void StartFill()
    {
        switcher = true;
    }

    private void Update()
    {
        if (switcher)
        {
            if (fill < 35)
            {
                fill += randomFillStep * Time.deltaTime * 800;
            }
            else
            {
                switcher = false;
                onFilled?.Invoke();
            }
            renderer.material.SetFloat("_Fill", fill);
        }
    }
}
