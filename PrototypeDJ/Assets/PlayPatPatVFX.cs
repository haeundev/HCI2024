using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPatPatVFX : MonoBehaviour
{
    [SerializeField] private List<GameObject> patPatVFXs;
    [SerializeField] private Button patButton;

    private void Awake()
    {
        patButton.onClick.AddListener(PlayRandomPatPatVFX);
        patPatVFXs.ForEach(vfx => vfx.SetActive(false));
    }

    private void PlayRandomPatPatVFX()
    {
        Debug.Log("Pat Pat!");
        patPatVFXs.ForEach(vfx => vfx.SetActive(false));
        var randomIndex = Random.Range(0, patPatVFXs.Count);
        patPatVFXs[randomIndex].SetActive(true);
    }

    private void OnDestroy()
    {
        patButton.onClick.RemoveListener(PlayRandomPatPatVFX);
    }
}