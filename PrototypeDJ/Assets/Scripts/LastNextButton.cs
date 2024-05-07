using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastNextButton : MonoBehaviour
{
    // make the button interactable after 3 seconds
    private void Start()
    {
        GetComponent<Button>().interactable = false;
        StartCoroutine(EnableButton());
        
        GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Button>().interactable = true;
    }
    
    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClicked);
    }
}