using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScence : MonoBehaviour
{
    public GameObject StorUI;
    public GameObject panel;

    private void Start()
    {
        StorUI = GameObject.Find("Canvas").transform.Find("ªÛ¡°UI").gameObject;
        panel = StorUI.transform.Find("panel").gameObject;
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Inventorys.Instance.ItemAllSell();
            panel.SetActive(true);
        }
    }
}
