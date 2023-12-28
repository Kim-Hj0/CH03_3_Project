using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollider : MonoBehaviour
{
    public int gemValue = 10;
    public Text gemText; // UI Text 요소에 대한 참조

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 Gem을 먹었을 때 GameManager에 알림
            GameManager.Instance.PlayerAteGem(gemValue);

            // UI Text 업데이트
            UpdateGemText();

            // Gem 파괴
            Destroy(gameObject);
        }
    }

    private void UpdateGemText()
    {
        if (gemText != null)
        {
            // UI Text 업데이트
            gemText.text = "Gems: " + GameManager.Instance.GetGemCount();
        }
    }
}
