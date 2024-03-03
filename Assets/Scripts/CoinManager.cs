using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Text coinsUI;
    public float Coins;

    

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
/*
    public bool CanBuyItem()
    {
        if () ;
    }*/

}
