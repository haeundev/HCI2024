using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private List<GameObject> characters;
    private readonly List<string> _animations = new() { "Idle", "Run", "SongJump", "Walk", "Win" };

    [SerializeField] private bool isPet;
    
    private int _currentCharacterIndex;

    private void Awake()
    {
        if (previousButton != null && nextButton != null)
        {
            previousButton.onClick.AddListener(OnPreviousButtonClicked);
            nextButton.onClick.AddListener(OnNextButtonClicked);
        }
    }

    private void Start()
    {
        characters.ForEach(character => character.SetActive(false));
        
        if (isPet)
        {
            if (GlobalInfo.CurrentPetIndex != 999)
            {
                _currentCharacterIndex = GlobalInfo.CurrentPetIndex;
            }
            else
            {
                var randomIndex = Random.Range(0, characters.Count);
                _currentCharacterIndex = randomIndex;
                GlobalInfo.CurrentPetIndex = randomIndex;
            }
        }
        else
        {
            if (GlobalInfo.CurrentCharacterIndex != 999)
            {
                _currentCharacterIndex = GlobalInfo.CurrentCharacterIndex;
            }
            else
            {
                var randomIndex = Random.Range(0, characters.Count);
                _currentCharacterIndex = randomIndex;
                GlobalInfo.CurrentCharacterIndex = randomIndex;
            }
        }
        
        characters[_currentCharacterIndex].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) OnPreviousButtonClicked();
        if (Input.GetKeyDown(KeyCode.E)) OnNextButtonClicked();
    }

    private void OnPreviousButtonClicked()
    {
        characters[_currentCharacterIndex].SetActive(false);
        _currentCharacterIndex--;
        if (_currentCharacterIndex < 0) _currentCharacterIndex = characters.Count - 1;
        characters[_currentCharacterIndex].SetActive(true);
        
        PlayRandomAnimation();
    }

    private void OnNextButtonClicked()
    {
        characters[_currentCharacterIndex].SetActive(false);
        _currentCharacterIndex++;
        if (_currentCharacterIndex >= characters.Count) _currentCharacterIndex = 0;
        characters[_currentCharacterIndex].SetActive(true);

        PlayRandomAnimation();
    }
    
    private void PlayRandomAnimation()
    {
        var animator = characters[_currentCharacterIndex].GetComponent<Animator>();
        if (animator.parameters.Length == 0)
        {
            animator.Play("Walk");
        }
        else
        {
            var randomAnimation = _animations[Random.Range(0, _animations.Count)];
            animator.SetTrigger(randomAnimation);
        }
    }
    
    private void OnDestroy()
    {
        if (previousButton != null && nextButton != null)
        {
            previousButton.onClick.RemoveListener(OnPreviousButtonClicked);
            nextButton.onClick.RemoveListener(OnNextButtonClicked);
        }
    }
}