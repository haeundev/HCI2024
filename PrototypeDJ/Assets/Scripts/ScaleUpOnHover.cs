using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleUpOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Vector3 targetScale = new(1.1f, 1.1f, 1f);
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private GameObject fx;
    [SerializeField] private GameObject check;
    [SerializeField] private ScaleUpOnHover other;
    
    private bool _isHovered;
    private Vector3 _initialScale;
    private Coroutine _scaleCoroutine;
    private bool _isClicked;
    public bool IsClicked => _isClicked;
    
    private void Awake()
    {
        _initialScale = transform.localScale;
    }

    private void Start()
    {
        check.SetActive(false);
        fx.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isHovered)
            return;
        if (_scaleCoroutine != null)
            StopCoroutine(_scaleCoroutine);
        _scaleCoroutine = StartCoroutine(ScaleTo(targetScale));
        fx.SetActive(true);
        
        _isHovered = true;
        //Debug.Log("Hovered!");
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isHovered)
            return;
        if (_scaleCoroutine != null)
            StopCoroutine(_scaleCoroutine);
        _scaleCoroutine = StartCoroutine(ScaleTo(_initialScale));
        fx.SetActive(false);
        
        _isHovered = false;
        //Debug.Log("Unhovered!");
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked!");
        
        if (_isClicked == false)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }
    
    private void Select()
    {
        other.Deselect();

        check.SetActive(true);
        GetComponent<AudioSource>().Play();
        
        _isClicked = true;
        
        switch (gameObject.name)
        {
            case "E":
                GlobalInfo.CurrentEI = GlobalInfo.EI.E;
                break;
            case "I":
                GlobalInfo.CurrentEI = GlobalInfo.EI.I;
                break;
            case "S":
                GlobalInfo.CurrentSN = GlobalInfo.SN.S;
                break;
            case "N":
                GlobalInfo.CurrentSN = GlobalInfo.SN.N;
                break;
            case "T":
                GlobalInfo.CurrentTF = GlobalInfo.TF.T;
                break;
            case "F":
                GlobalInfo.CurrentTF = GlobalInfo.TF.F;
                break;
            case "J":
                GlobalInfo.CurrentJP = GlobalInfo.JP.J;
                break;
            case "P":
                GlobalInfo.CurrentJP = GlobalInfo.JP.P;
                break;
        }
        
        Debug.Log($"Selection MBTI: {GlobalInfo.CurrentEI.ToString()}{GlobalInfo.CurrentSN.ToString()}{GlobalInfo.CurrentTF.ToString()}{GlobalInfo.CurrentJP.ToString()}");
    }
    
    private void Deselect()
    {
        check.SetActive(false);
        
        _isClicked = false;
        
        Debug.Log("Deselected!");
    }
    
    private IEnumerator ScaleTo(Vector3 target)
    {
        var elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var percentageComplete = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(_initialScale, target, percentageComplete);
            yield return null;
        }
        transform.localScale = target;
    }
}