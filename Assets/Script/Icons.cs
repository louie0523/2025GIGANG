using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    public List<Sprite> icons = new List<Sprite>();
    public List<int> Wieghts = new List<int>();

    public TextMeshProUGUI Wtext;



    public void IconSet()
    {
        Image imageCom = this.transform.GetComponent<Image>();
        imageCom.sprite = icons[Inventorys.Instance.ItemNums[int.Parse(this.transform.parent.gameObject.name)-1]];
        Wtext.text = Wieghts[Inventorys.Instance.ItemNums[int.Parse(this.transform.parent.gameObject.name)-1]].ToString();
        //Debug.Log(Wieghts[Inventorys.Instance.ItemNums[int.Parse(this.transform.parent.gameObject.name) - 1]].ToString());
    }
}
