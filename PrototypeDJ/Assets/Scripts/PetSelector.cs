using System.Collections.Generic;
using UnityEngine;

public class PetSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> pets;

    private void Start()
    {
        SelectRandomPet();
    }

    private void SelectRandomPet()
    {
        pets.ForEach(pet => pet.SetActive(false));
        var randomIndex = Random.Range(0, pets.Count);
        pets[randomIndex].SetActive(true);

        GlobalInfo.CurrentPetIndex = randomIndex;
        
        Debug.Log($"Selected pet index: {randomIndex}");
    }
}