using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int _money;
    public static int Money { get; set; }
    public int startMoney = 400;

    private static int _lives;
    public static int Lives { get; set; }
    public int startLives = 20;


    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}