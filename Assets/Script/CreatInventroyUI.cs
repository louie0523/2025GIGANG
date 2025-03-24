using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatInventroyUI : MonoBehaviour
{
    public static CreatInventroyUI instance;
    public GameObject InventoryBox;
    public GameObject Parents;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(instance);
        }
    }
    private void Start()
    {
        Parents = GameObject.Find("인벤토리").transform.Find("인벤박스").gameObject;
        CreateBox(Inventorys.Instance.CreatInvenBoxNum);
    }

    public void CreateBox(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            GameObject invenBox = Instantiate(InventoryBox, Parents.transform);
            invenBox.name = i.ToString();
            GameObject ChildBox = invenBox.transform.Find("1back").gameObject;
            ChildBox.name = i + "back";
            //GameObject icon = invenBox.transform.Find("Icon").gameObject;
            //Icons icons = icon.GetComponent<Icons>();
            //icons.ItemNum = Random.Range(1, 4);
            //icons.IconSet();

        }

        Inventorys.Instance.InventorySet();
    }

    public void InvenBoxClear()
    {
        foreach (Transform box in Parents.transform)
        {
            Destroy(box.gameObject);
        }
    }
}
