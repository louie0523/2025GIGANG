using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    Animator animator;
    public float speed = 4f;
    public float speed_Down = 0f;
    public int Maxhp = 100;
    public int Hp = 100;
    public float Air = 100f;

    bool Walk = false;
    bool Death = false;

    public Slider AirSlider;
    public Slider HpSlider;
    public GameObject Flash;
    public Light Flash_Light;

    public float SspeedUp = 3f;
    public float LspeedUp = 6f;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = this.transform.Find("플레이어").GetComponent<Animator>();
        AirSlider = GameObject.Find("플레이어UI").transform.Find("Air").GetComponent<Slider>();
        HpSlider = GameObject.Find("플레이어UI").transform.Find("HP").GetComponent<Slider>();
        Flash = this.transform.Find("손전등").gameObject;
        Flash_Light = Flash.transform.Find("Light").GetComponent<Light>();

        AirSlider.value = 1f;
        HpSlider.value = 1f;
        StartCoroutine(UpdateAir());
    }

    // Update is called once per frame
    void Update()
    {

        if(!Death)
        {
            Move();
            Rotation();
            ItemUse();
            LightOn();
        }
    }

    void Move()
    {
        Walk = false;
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, (speed - speed_Down) * Time.deltaTime);
            Walk = true;
        } else if(Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -(speed - speed_Down) * Time.deltaTime);
            Walk = true;
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate((speed - speed_Down) * Time.deltaTime, 0, 0);
            Walk = true;
        } else if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-(speed - speed_Down) * Time.deltaTime, 0, 0);
            Walk = true;
        }

        if(Walk)
        {
            animator.SetBool("Walk", true);
        } else
        {
            animator.SetBool("Walk", false);
        }
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;
        if (plane.Raycast(ray, out rayLength))
        {
            Vector3 mousePoint = ray.GetPoint(rayLength);

            this.transform.LookAt(new Vector3(mousePoint.x, this.transform.position.y, mousePoint.z));
        }
    }


    void ItemUse()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            if (Inventorys.Instance.ItemNums[Inventorys.Instance.SelectItem] != 0)
            {
                switch(Inventorys.Instance.ItemNums[Inventorys.Instance.SelectItem]-1)
                {
                    case 0:
                        Debug.Log("체력 회복");
                        Heal(30);
                        break;
                    case 1:
                        Debug.Log("산소 게이지 회복");
                        AirCharge(20f);
                        break;
                    case 2:
                        Debug.Log("보물 탐지기 발동");
                        break;
                    case 3:
                        Debug.Log("속도 소폭 증가");
                        StartCoroutine(SspeedTime());
                        break;
                    case 4:
                        Debug.Log("속도 대폭 증가");
                        StartCoroutine(LspeedTime());
                        break;
                    case 5:
                        Debug.Log("안개 은신술 발동!");
                        break;
                }
                Inventorys.Instance.ItemNums[Inventorys.Instance.SelectItem] = 0;
                Inventorys.Instance.SeTIconTest();
            } else
            {
                Debug.Log("해당 칸에 아이템이 없습니다.");
            }
        }
    }

    IEnumerator UpdateAir()
    {
        while (Air >= 1)
        {
            yield return new WaitForSeconds(2f);
            Air -= 0.25f;
            AirSlider.value = Air / 100f;
        }
        Debug.Log("산소가 모두 떨어졌습니다. 게임 오버!");
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Death = true;
            Debug.Log("사망하셨습니다. 게임 오버!");
        }
    }

    void LightOn()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(Flash_Light.enabled)
            {
                Flash_Light.enabled = false;
            } else
            {
                Flash_Light.enabled = true;
            }
        }
    }

    public void Heal(int heal)
    {
        Hp += heal;
        if(Hp > Maxhp)
        {
            Hp = Maxhp;
        }
    }
    
    public void AirCharge(float air)
    {
        Air += air;
        if(Air > 100)
        {
            Air = 100;
        }
        AirSlider.value = Air / 100f;
    }

    IEnumerator SspeedTime()
    {
        float Origin = SspeedUp;
        speed += Origin;
        yield return new WaitForSeconds(5f);
        speed -= Origin;
    }

    IEnumerator LspeedTime()
    {
        float Origin = LspeedUp;
        speed += Origin;
        yield return new WaitForSeconds(5f);
        speed -= Origin;
    }
    
    public void VeryWeight()
    {
        if (Inventorys.Instance.VeryWeight)
        {
            speed_Down = 3f;
        } else
        {
            speed_Down = 0f;
        }
    }

    

}
