using System.Collections;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public Transform objectToMove; // 이동할 오브젝트
    public float moveDistance = 1.0f; // 이동 거리
    public float moveSpeed = 2.0f; // 이동 속도
    public float waitTime = 0.05f; // 다음 이동을 시작하기 전 대기 시간

    private Vector3 originalPosition; // 초기 위치 저장

    private void Start()
    {
        // 초기 위치 저장
        if (objectToMove != null)
        {
            originalPosition = objectToMove.position;
            StartCoroutine(MoveObject());
        }
    }

    // ArrowMove 스크립트의 originalPosition을 변경하는 메서드
    public void UpdateOriginalPosition()
    {
        if (objectToMove.position.y < 3.07f)
            originalPosition += new Vector3(0f, 1.6f, 0f); // y축 값 증가
    }

    // 오브젝트를 이동시키는 코루틴 함수
    private IEnumerator MoveObject()
    {
        while (true) // 무한 반복
        {
            yield return new WaitForSeconds(waitTime); // 다음 이동 시작 전 대기

            Vector3 targetPosition = originalPosition + Vector3.left * moveDistance; // 이동할 목표 위치 계산

            // 이동할 위치까지 이동
            while (Vector3.Distance(objectToMove.position, targetPosition) > 0.01f)
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime); // 다시 이동하기 전 대기

            // 초기 위치로 되돌아가기
            while (Vector3.Distance(objectToMove.position, originalPosition) > 0.01f)
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, originalPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            objectToMove.position = originalPosition; // 초기 위치로 돌아왔을 때 위치 보정
        }
    }
}
