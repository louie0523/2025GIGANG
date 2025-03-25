using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public static Store Instance;

    public GameObject StoreUI;

    public Slider AirSlider;
    public Slider BagSlider;

    public int AirNeedGold = 1500;
    public int BagNeedGold = 2500;

    public Text myGold;
    public Text AirGoldText;
    public Text BagGoldText;

    public int AirLevel = 1;
    public int BagLevel = 1;

    public int SNum = 2;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(this);  
        }
    }

    public void SetGoldText()
    {
        myGold.text = GameManager.Instance.Gold + "G";
    }

    public void UpGradeAir()
    {
        if(GameManager.Instance.Gold >= AirNeedGold && AirLevel < 3)
        {
            GameManager.Instance.Gold -= AirNeedGold;
            AirLevel++;
            AirNeedGold += 750;
            AirGoldText.text = AirNeedGold.ToString();
            AirSlider.value += 0.34f;
            SetGoldText();
        } else
        {
            Debug.Log("이미 최대 레벨이거나, 골드가 부족합니다.");
        }
    }

    public void UpGradeBag()
    {
        if (GameManager.Instance.Gold >= BagNeedGold && BagLevel < 2)
        {
            GameManager.Instance.Gold -= BagNeedGold;
            BagLevel++;
            BagNeedGold = 0;
            BagGoldText.text = BagNeedGold.ToString();
            BagSlider.value += 0.5f;
            SetGoldText();
            Inventorys.Instance.MaxWeight += 150;
            Inventorys.Instance.CreatInvenBoxNum = 8;
            Inventorys.Instance.InventoryUp();
        }
        else
        {
            Debug.Log("이미 최대 레벨이거나, 골드가 부족합니다.");
        }
    }


    public void NextScence()
    {
        StoreUI.SetActive(false);
        SceneManager.LoadScene(SNum);
        SNum++;
    }


}
