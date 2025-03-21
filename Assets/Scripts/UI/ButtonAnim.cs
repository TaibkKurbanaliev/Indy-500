using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonAnim : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 0.2f;
    [SerializeField] private float _scale = 0.9f;
    [SerializeField] private float _hoverScale = 0.95f;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _hoverSound;

    private AudioSource _audioSource;
    private Button _button;
    private Vector3 _originalScale;
    private Color _originalColor;
    private TMP_Text _text;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TMP_Text>();

        _originalScale = transform.localScale;
        _originalColor = _text.color;
    }

    public void Highlight()
    {
        _text.DOColor(Color.white, _fadeTime);
        _button.transform.DOScale(_originalScale * _hoverScale, _fadeTime);
        _audioSource.PlayOneShot(_hoverSound);
    }

    public void UnHighlight()
    {
        _text.DOColor(_originalColor, _fadeTime);
        _button.transform.DOScale(_originalScale, _fadeTime);
    }

    public void Select()
    {
        _button.transform.DOScale(_originalScale * _scale, _fadeTime);
        _audioSource.PlayOneShot(_clickSound);
    }

    public void DeSelect()
    {
        _button.transform.DOScale(_originalScale, _fadeTime);
    }
}
