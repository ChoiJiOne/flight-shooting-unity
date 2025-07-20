using System.Collections;
using UnityEngine;

public class Twinkle : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 0.1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        StartCoroutine(nameof(TwinkleLoop));
    }

    private IEnumerator TwinkleLoop()
    {
        while (true)
        {
            yield return StartCoroutine(FadeEffect(1, 0));
            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }

    private IEnumerator FadeEffect(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1.0f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / _fadeTime;

            Color color = _spriteRenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            _spriteRenderer.color = color;

            yield return null;
        }
    }
}
