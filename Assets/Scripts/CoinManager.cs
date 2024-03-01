using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Text coinsUI;
    public float Coins;




    [SerializeField] private GameObject NotEnoughCoinPanel;

    

    private void Start()
    {
     
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

    public void ShowNotEnoughCoinPanel()
    {
        NotEnoughCoinPanel.SetActive(true);
    }

}
