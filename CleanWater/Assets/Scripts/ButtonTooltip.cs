using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip; // 설명창을 나타내는 UI 요소

    // 마우스를 버튼 위에 올렸을 때 호출되는 메서드
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.SetActive(true); // 설명창을 활성화하여 보여줍니다.
    }

    // 마우스가 버튼에서 벗어났을 때 호출되는 메서드
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false); // 설명창을 비활성화하여 숨깁니다.
    }
}
