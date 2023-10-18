using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Light directionalLight;
    public Color[] colors;
    private int currentIndex = 0;

    void Start()
    {
        if (directionalLight == null)
        {
            directionalLight = GetComponent<Light>();
        }

        if (colors.Length == 0)
        {
            Debug.LogError("Escolha no minimo uma cor");
            enabled = false;
        }

        // Start the color change coroutine
        StartCoroutine(ChangeColorEverySecond());
    }

    IEnumerator ChangeColorEverySecond()
    {
        while (true)
        {
            // Change the light color to the current color in the array
            directionalLight.color = colors[currentIndex];

            // Increment the current index and loop back to the beginning if needed
            currentIndex = (currentIndex + 1) % colors.Length;

            // Wait for 1 second before changing the color again
            yield return new WaitForSeconds(1.0f);
        }
    }
}
