using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public float Coins { get; private set; }
    public Text CoinText;

    [SerializeField] private GameObject NotEnoughCoinPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        CoinText.text = "Coins: $" + Coins.ToString();
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
        UpdateCoinText();
    }

    public bool DeductCoins(float amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            UpdateCoinText();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShowNotEnoughCoinPanel()
    {
        NotEnoughCoinPanel.SetActive(true);
    }
}
