using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ActionProgressSlider : MonoBehaviour
{
    private Slider _slider;

    public void Initialize() => _slider = GetComponent<Slider>();

    public void Fill(float percentFillValue)
    {
        percentFillValue = Mathf.Clamp(percentFillValue, 0.0f, 1.0f);

        _slider.value = percentFillValue;
    }

    public void Show()
    {
        _slider.value = 0f;

        _slider.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _slider.gameObject.SetActive(false);
    }
}
