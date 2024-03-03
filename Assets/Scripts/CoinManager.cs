using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Text coinsUI;
    public float Coins;

    private void Update()
    {
        UpdateCoins();
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
    }

    public bool DeductCoins(float amount)
    {

        Coins -= amount;
        return true;
    }

    public void UpdateCoins()
    {
        if (coinsUI != null)
        {
            coinsUI.text = "$ " + Coins.ToString();
        }
    }


}
