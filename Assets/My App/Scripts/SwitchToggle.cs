using UnityEngine ;
using UnityEngine.UI ;
using TMPro;
using DG.Tweening ;

public class SwitchToggle : MonoBehaviour {
    [SerializeField] RectTransform uiHandleRectTransform ;
    [SerializeField] Color backgroundActiveColor ;
    [SerializeField] Color handleActiveColor ;

    public Image backgroundImage, handleImage ;

    Color backgroundDefaultColor, handleDefaultColor ;

    Toggle toggle ;

    Vector2 handlePosition ;

    public Animator indoorAni;
    public Animator outdoorAni;
    public Animator curtainAni;

    public TMP_Text textSelect;
    public bool On;

    void Awake ( ) {
        toggle = GetComponent <Toggle> ( ) ;

        handlePosition = uiHandleRectTransform.anchoredPosition ;
        handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;

        backgroundDefaultColor = backgroundImage.color ;
        handleDefaultColor = handleImage.color ;

        toggle.onValueChanged.AddListener (OnSwitch) ;
        
        if (toggle.isOn)
        {
            OnSwitch(true);
        }
        else
        {
            OnSwitch(false);
        }   
    }
    private void Start()
    {
        textSelect.text = "Indoor";
        if(On == true)
        {
            curtainAni.Play("CurtainOn");
        }
        
    }

    void OnSwitch (bool on) {
        //uiHandleRectTransform.anchoredPosition = on ? handlePosition *4 : handlePosition ; // no anim
        uiHandleRectTransform.DOAnchorPos (on ? handlePosition * 4 : handlePosition, .4f).SetEase (Ease.InOutBack) ;

        //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor ; // no anim
        backgroundImage.DOColor (on ? backgroundActiveColor : backgroundDefaultColor, .6f) ;

        //handleImage.color = on ? handleActiveColor : handleDefaultColor ; // no anim
        handleImage.DOColor (on ? handleActiveColor : handleDefaultColor, .4f) ;
        if(!toggle.isOn)
        {
            indoorAni.Play("On");
            outdoorAni.Play("Empty");
            curtainAni.Play("CurtainOff");
            textSelect.text = "Indoor";
            On = false;
        }
        else
        {
            indoorAni.Play("Empty");
            outdoorAni.Play("On");
            curtainAni.Play("CurtainOn");
            textSelect.text = "Outdoor";
            On = true;
        }
            
    }

    void OnDestroy ( ) {
        toggle.onValueChanged.RemoveListener (OnSwitch) ;
    }
}
