using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    public List<Chest> chests = new List<Chest>();
    public List<Doors> doors = new List<Doors>();
    public bool haveKey = false;
    public GameObject toolTipKey;
    public float currentScore;
    public float highScore;
    public static bool boolTryAgain = false;
    [SerializeField] Buttons buttons;



    private void Start()
    {
        RandomChest();
        RandomDoors();
        Time.timeScale = 0;
        if(boolTryAgain)
        {
            buttons.ClickButtonStart();
        }
    }

    void RandomChest()
    {
        int random = Random.Range(0, chests.Count);
        int temp = 0;
        foreach (var c in chests)
        {
            c.gameObject.SetActive(random == temp);
            temp++;
        }
    }

    void RandomDoors()
    {
        int random = Random.Range(0, doors.Count);
        int temp = 0;
        foreach (var d in doors)
        {
            d.parentObject.SetActive(random == temp);
            temp++;
        }
    }
}
