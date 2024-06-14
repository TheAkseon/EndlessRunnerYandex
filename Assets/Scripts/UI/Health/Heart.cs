using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;
    private float _maxValue = 1.0f;
    private float _minValue = 0.0f;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1.0f;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(_minValue, _maxValue, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(_maxValue, _minValue, _lerpDuration, Destroy));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsedTime = 0;
        float nextValue;

        while (elapsedTime < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _image.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
}
