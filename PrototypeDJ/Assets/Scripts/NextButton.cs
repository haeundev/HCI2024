using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    private List<ScaleUpOnHover> _options;
    private Button _button;
    
    [SerializeField] private List<GameObject> activateOnClick;
    [SerializeField] private List<GameObject> deactivateOnClick;

    private void Awake()
    {
        _options = transform.parent.GetComponentsInChildren<ScaleUpOnHover>().ToList();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        GetComponent<AudioSource>().Play();
        
        deactivateOnClick.ForEach(obj => obj.SetActive(false));
        activateOnClick.ForEach(obj => obj.SetActive(true));
    }

    private void Update()
    {
        if (_options == null || _options.Count == 0) return;
        
        if (_options.Any(option => option.IsClicked) == false)
        {
            // No option is clicked. Deactivate the button.
            _button.interactable = false;
        }
        else
        {
            // At least one option is clicked. Activate the button.
            _button.interactable = true;
        }
    }
}