using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGallery : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private float timePerImage = 4f;
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade effect
    [SerializeField] private Vector3 zoomScale = new(1.1f, 1.1f, 1f); // Target scale when zoomed in

    private int _currentIndex;

    private void OnEnable()
    {
        StartCoroutine(ChangeImage());
    }

    private IEnumerator ChangeImage()
    {
        while (true)
        {
            _currentIndex++;
            if (_currentIndex >= sprites.Count) _currentIndex = 0;
            image.sprite = sprites[_currentIndex];

            // Start the fade in and zoom in coroutine
            StartCoroutine(FadeImage(true));
            yield return new WaitForSeconds(timePerImage - fadeDuration);

            // Start the fade out coroutine
            StartCoroutine(FadeImage(false));
            yield return new WaitForSeconds(fadeDuration);
        }
    }

    private IEnumerator FadeImage(bool fadeIn)
    {
        var elapsedTime = 0f;
        var fadeStep = fadeIn ? 0f : 1f;

        // Determine starting and ending scales
        var startScale = fadeIn ? Vector3.one : zoomScale;
        var endScale = fadeIn ? zoomScale : Vector3.one;

        // Perform the fade and zoom effect
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            var percentageComplete = elapsedTime / fadeDuration;

            // Update image transparency
            var color = image.color;
            color.a = fadeIn ? Mathf.Lerp(0f, 1f, percentageComplete) : Mathf.Lerp(1f, 0f, percentageComplete);
            image.color = color;

            // Update image scale
            image.transform.localScale = Vector3.Lerp(startScale, endScale, percentageComplete);

            yield return null;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}