using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fading : MonoBehaviour
{
    CanvasGroup panelCanvasGroup;
    void Start()
    {
        panelCanvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(PanelAnimation());
    }
    void FadeInPanel()
    {
        panelCanvasGroup.DOFade(1, 3.0f);
    }
    void FadeOutPanel()
    {
        panelCanvasGroup.DOFade(0, 3.0f);
    }

    IEnumerator PanelAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        FadeInPanel();
        yield return new WaitForSeconds(2.0f);
        FadeOutPanel();
    }
}
