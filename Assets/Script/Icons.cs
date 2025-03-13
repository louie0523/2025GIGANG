using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    public List<Sprite> icons = new List<Sprite>();
    

    public void IconSet()
    {
        Image imageCom = this.transform.GetComponent<Image>();
        imageCom.sprite = icons[Inventorys.Instance.ItemNums[int.Parse(this.transform.parent.gameObject.name)]];

    }
}
