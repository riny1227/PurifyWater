using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform buttonScale;   // ��ư ũ��
    Vector3 defaultScale;   // ��ư �⺻ ũ��

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;   // ������ ��ư ũ�⸦ 1.2�� ũ��� �ٲ�
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;   // ������ ��ư ũ��� ���ƿ�
    }
}
