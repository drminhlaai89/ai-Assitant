using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MQ
{
    public class ButtonAnimationController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject button;
        //public bool angry, greats, love, happy, sad, wow;
        public Image mainIcon;
        public Image icon;

        public void OnPointerEnter(PointerEventData eventData)
        {
            button.GetComponent<Animator>().Play("On");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            button.GetComponent<Animator>().Play("Off");
        }

        public void SelectButton()
        {         
                icon.sprite = mainIcon.sprite;   
        }    
    }
}
