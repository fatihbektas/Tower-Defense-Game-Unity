using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int _money;

    public static int Money { get; set; }

    public int startMoney = 400;

    private void Start()
    {
        Money = startMoney;
    }
}