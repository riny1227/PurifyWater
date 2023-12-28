using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform buttonScale;   // 버튼 크기
    Vector3 defaultScale;   // 버튼 기본 크기

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;   // 기존의 버튼 크기를 1.2배 크기로 바꿈
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;   // 기존의 버튼 크기로 돌아옴
    }
}
