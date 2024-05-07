using UnityEngine;
using UnityEngine.UI;

public class ScreenshotButton : MonoBehaviour
{
    [SerializeField] private GameObject screenshotFxPanel;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        screenshotFxPanel.SetActive(false);
        screenshotFxPanel.SetActive(true);
    }
   
    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClicked);
    }
}