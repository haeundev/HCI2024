using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private List<GameObject> activeObjectsOnStart;
    [SerializeField] private List<GameObject> deactiveObjectsOnStart;
    

    private void Start()
    {
        activeObjectsOnStart.ForEach(obj => obj.SetActive(true));
        deactiveObjectsOnStart.ForEach(obj => obj.SetActive(false));
    }
}