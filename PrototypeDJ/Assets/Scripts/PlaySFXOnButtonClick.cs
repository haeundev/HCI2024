using UnityEngine;
using UnityEngine.UI;

public class PlaySFXOnButtonClick : MonoBehaviour
{
    private Button _button;

    [SerializeField] private AudioClip sfx;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();

        _audioSource.clip = sfx;

        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        _audioSource.Play();
    }
    
    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClicked);
    }
}