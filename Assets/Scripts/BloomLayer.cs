using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BloomLayer : MonoBehaviour
{
    public float bloomIntensity;
    private PostProcessVolume postProcessVolume;
    private Bloom bloomLayer;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out bloomLayer);
        bloomLayer.intensity.value = bloomIntensity;
    }
}
