using UnityEngine;

public class Player : MonoBehaviour
{
    private Coin _coin;

    private int _totalCoins;

    private void Start()
    {
        _coin = FindObjectOfType<Coin>();
    }

    public void AddCoin()
    {
        _totalCoins++;
        Debug.Log("У вас: " + _totalCoins + " монеток.");
    }
}
