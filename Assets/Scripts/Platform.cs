using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������μ� �ʿ��� ������ ���� ��ũ��Ʈ
public class Platform : MonoBehaviour
{
    // ��ֹ� ������Ʈ��
    public GameObject[] obstacles;
    // �÷��̾� ĳ���Ͱ� ��Ҵ°�
    private bool stepped = false;

    // ������Ʈ�� Ȱ��ȭ�� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        // ������ �����ϴ� ó��
        stepped = false;

        // ��ֹ��� ����ŭ ����
        for (int i = 0; i < obstacles.Length; i++)
        {
            // ���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
            if (Random.Range(0,3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    // �÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������ �±װ� Player�̰� ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        if (collision.collider.tag == "Player" && !stepped)
        {
            // ������ �߰��ϰ�, ���� ���¸� ������ ����
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
