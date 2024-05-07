using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private List<GameObject> activeObjectsOnStart;
    [SerializeField] private List<GameObject> deactiveObjectsOnStart;
    

    private void Awake()
    {
        activeObjectsOnStart.ForEach(obj => obj.SetActive(true));
        deactiveObjectsOnStart.ForEach(obj => obj.SetActive(false));
    }
}