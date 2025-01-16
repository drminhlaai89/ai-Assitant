using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightController : MonoBehaviour
{
    public float transitionDuration = 1.0f;
    public Light directionalLight;

    private float targetIntensity = 0.0f;
    private Coroutine transitionCoroutine;

    public bool isOFF;

    public void ToggleDirectionalLight()
    {
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }

        targetIntensity = isOFF ? 1.0f : 0.0f;
        transitionCoroutine = StartCoroutine(TransitionDirectionalLight());
        isOFF = !isOFF;
    }

    private IEnumerator TransitionDirectionalLight()
    {
        float initialIntensity = directionalLight.intensity;
        float elapsedTime = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            directionalLight.intensity = Mathf.Lerp(initialIntensity, targetIntensity, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        directionalLight.intensity = targetIntensity;
        transitionCoroutine = null;
    }
}
