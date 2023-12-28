using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollider : MonoBehaviour
{
    public int gemValue = 10;
    public Text gemText; // UI Text ��ҿ� ���� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ Gem�� �Ծ��� �� GameManager�� �˸�
            GameManager.Instance.PlayerAteGem(gemValue);

            // UI Text ������Ʈ
            UpdateGemText();

            // Gem �ı�
            Destroy(gameObject);
        }
    }

    private void UpdateGemText()
    {
        if (gemText != null)
        {
            // UI Text ������Ʈ
            gemText.text = "Gems: " + GameManager.Instance.GetGemCount();
        }
    }
}
