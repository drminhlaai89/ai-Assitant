using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEventButton : MonoBehaviour
{
    public GameObject previousPage;
    public GameObject previousButton;
    public GameObject currentPage;
    public GameObject currentButton;
    public GameObject nextPage;
    public GameObject nextButton;

    CatalogButtonNextManager catalogButtonNextManager;
    public float nextDelay1 = 1.1f;
    public float nextDelay2 = 2.2f;

    private void Awake()
    {
        catalogButtonNextManager = GetComponentInParent<CatalogButtonNextManager>();
    }

    public void NextPageStep0()
    {
        //catalogButtonNextManager.CloseInteractable();
    }

    public void NextPageStep1()
    {
        nextPage.SetActive(true);
        currentPage.SetActive(false);
        nextButton.SetActive(true);

    }    
    public void NextPageStep2()
    {
        currentButton.SetActive(false);
    }    

    public void PreviousPage()
    {
        previousButton.SetActive(true);
        previousPage.SetActive(true);
        currentPage.SetActive(false);
        currentButton.SetActive(false);
    }

    public void OnClick(Button _button)
    {
        _button.animator.Play("Pressed");
        //catalogButtonNextManager.CloseInteractable();
        StartCoroutine(NextPage1());
        StartCoroutine(NextPage2());
    }

    private IEnumerator NextPage1()
    {
        yield return new WaitForSeconds(nextDelay1);
        NextPageStep1();
    }
    private IEnumerator NextPage2()
    {
        yield return new WaitForSeconds(nextDelay2);
        NextPageStep2();
    }

}
