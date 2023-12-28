using System.Collections;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public Transform objectToMove; // �̵��� ������Ʈ
    public float moveDistance = 1.0f; // �̵� �Ÿ�
    public float moveSpeed = 2.0f; // �̵� �ӵ�
    public float waitTime = 0.05f; // ���� �̵��� �����ϱ� �� ��� �ð�

    private Vector3 originalPosition; // �ʱ� ��ġ ����

    private void Start()
    {
        // �ʱ� ��ġ ����
        if (objectToMove != null)
        {
            originalPosition = objectToMove.position;
            StartCoroutine(MoveObject());
        }
    }

    // ArrowMove ��ũ��Ʈ�� originalPosition�� �����ϴ� �޼���
    public void UpdateOriginalPosition()
    {
        if (objectToMove.position.y < 3.07f)
            originalPosition += new Vector3(0f, 1.6f, 0f); // y�� �� ����
    }

    // ������Ʈ�� �̵���Ű�� �ڷ�ƾ �Լ�
    private IEnumerator MoveObject()
    {
        while (true) // ���� �ݺ�
        {
            yield return new WaitForSeconds(waitTime); // ���� �̵� ���� �� ���

            Vector3 targetPosition = originalPosition + Vector3.left * moveDistance; // �̵��� ��ǥ ��ġ ���

            // �̵��� ��ġ���� �̵�
            while (Vector3.Distance(objectToMove.position, targetPosition) > 0.01f)
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime); // �ٽ� �̵��ϱ� �� ���

            // �ʱ� ��ġ�� �ǵ��ư���
            while (Vector3.Distance(objectToMove.position, originalPosition) > 0.01f)
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, originalPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            objectToMove.position = originalPosition; // �ʱ� ��ġ�� ���ƿ��� �� ��ġ ����
        }
    }
}
