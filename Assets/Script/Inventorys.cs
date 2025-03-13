using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventorys : MonoBehaviour
{
    public static Inventorys Instance;
    public List<GameObject> Inventory = new List<GameObject>();
    public List<int> ItemNums = new List<int>();
    public int SelectItem;


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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SeTIconTest();
        }

        SelectingIcon();
    }

    public void SeTIconTest()
    {
        for (int i = 0; i< Inventory.Count; i++)
        {
            Icons icons = Inventory[i].transform.Find("Icon").GetComponent<Icons>();
            icons.IconSet();
        }
    }


    public void InventorySet()
    {
        for(int i = 1; i <= 8; i++)
        {
            Inventory.Add(GameObject.Find("인벤토리").transform.Find(i.ToString()).gameObject);
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
}
