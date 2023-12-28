using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public int gemValue = 10;
    public Text gemText;


    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerAteGem(int gemValue)
    {
        // Gem�� �ش��ϴ� ������ ����
        gemValue += gemValue;

        // UI Text ������Ʈ
        UpdateGemText();
    }

    public int GetGemCount()
    {
        return gemValue;
    }

    private void UpdateGemText()
    {
        if (gemText != null)
        {
            // UI Text ������Ʈ
            gemText.text = "Gems: " + gemValue;
        }
    }
}
