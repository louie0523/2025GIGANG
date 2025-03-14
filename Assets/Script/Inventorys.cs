using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventorys : MonoBehaviour
{
    public static Inventorys Instance;
    public List<GameObject> Inventory = new List<GameObject>();
    public List<int> ItemNums = new List<int>();
    public int SelectItem;
    public int CurretnWeight;
    public int MaxWeight = 250;
    public TextMeshProUGUI WightText;
    
    public bool VeryWeight = false;
    public Player player;


    private void Awake()
    {
        if(Instance == null)
        {
           Instance = this;
           DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SeTIconTest();
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            TestGetItem();
        }

        SelectingIcon();
    }

    public void SeTIconTest()
    {
        int Weight = 0;
        for (int i = 0; i< Inventory.Count; i++)
        {
            Icons icons = Inventory[i].transform.Find("Icon").GetComponent<Icons>();
            icons.IconSet();
            Weight += icons.Wieghts[ItemNums[int.Parse(icons.gameObject.transform.parent.gameObject.name) - 1]];
        }
        WeightTextGang(Weight);
    }


    public void InventorySet()
    {
        for(int i = 1; i <= 8; i++)
        {
            Inventory.Add(GameObject.Find("인벤토리").transform.Find("인벤박스").transform.Find(i.ToString()).gameObject);
            ItemNums.Add(0);
        }
        SelectItem = 0;
        SelectIcon();
    }

    void SelectIcon()
    {
        for(int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i] == Inventory[SelectItem])
            {
                Outline BackOutLine = Inventory[i].transform.Find((i+1) + "back").GetComponent<Outline>();
                Color OutLineColor = new Color(255, 255, 0, 255);
                BackOutLine.effectColor = OutLineColor;
            } else
            {
                Outline BackOutLine = Inventory[i].transform.Find((i + 1) + "back").GetComponent<Outline>();
                Color OutLineColor = new Color(0, 0, 0, 255);
                BackOutLine.effectColor = OutLineColor;
            }
        }
    }

    void SelectingIcon()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(SelectItem < 7)
            {
                SelectItem++;
            } else
            {
                SelectItem = 0;
            }
            SelectIcon();
        } else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(SelectItem == 0) {
                SelectItem = 7;
            } else
            {
                SelectItem--;
            }
            SelectIcon();
        }
    }

    void TestGetItem()
    {
        for (int i = 1; i <= Inventory.Count; i++)
        {
            if (ItemNums[i-1] == 0)
            {
                ItemNums[i - 1] = Random.Range(1, 7);
                SeTIconTest();
                break;
            }
        }
    }

    void WeightTextGang(int Weight)
    {
        CurretnWeight = Weight;
        WightText.text = "Weight : " + CurretnWeight + "/" + MaxWeight;
        if (CurretnWeight > MaxWeight)
        {
            Debug.Log("과중량 상태입니다.");
            VeryWeight = true;
            player.VeryWeight();
        }
        else
        {
            Debug.Log("과중량 상태가 아닙니다.");
            VeryWeight = false;
            player.VeryWeight();
        }
    }
    
}
