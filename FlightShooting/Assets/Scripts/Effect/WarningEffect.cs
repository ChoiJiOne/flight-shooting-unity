using System.Collections;
using UnityEngine;
using TMPro;


public class WarningEffect : MonoBehaviour
{
    [SerializeField] private float _lerpTime = 0.1f;
    [SerializeField] TextMeshProUGUI _warningText;

    private void OnEnable()
    {
        StartCoroutine(nameof(ColorLerpLoop));
    }

    private IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1.0f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / _lerpTime;

            _warningText.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }
}
