using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class g_script : MonoBehaviour
{   public Camera camera;
    public static int bulletHP=100;
    public AudioSource audiosource;
    private float timeBetweenShot = 0.5f;
    private float timer;
    private float healtimer;
    Slider slider;
    GameObject gameobject;






    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   gameobject=GameObject.Find("Slider");
        slider=gameobject.GetComponent<Slider>();
        slider.value = bulletHP;

        if(bulletHP>100){
            bulletHP = 100;
        }

        if(bulletHP>0)
        {
            timer += Time.deltaTime;
            if(Input.GetMouseButton(0) && timer > timeBetweenShot)
            {
            Shot();

            }
        }
        healtimer += Time.deltaTime;
       if (healtimer >=2f && bulletHP<100)
        {   bulletheal();

             Debug.Log(bulletHP);
        }

    }
    void bulletheal(){
        bulletHP += 10;
        healtimer=0;
        if(bulletHP<100){
            Invoke("bulletheal",0.5f);
        }

    }
    void Shot(){
        audiosource.Play();
            healtimer = 0;
            bulletHP -=1;

            int distance  = 100;
            Vector3 center =new Vector3(Screen.width/2,Screen.height/2,0);
            Ray ray = camera.ScreenPointToRay(center);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, distance)){
                if(hitInfo.collider.name == "FPSController")
                {
                    hitInfo.collider.SendMessage("PlayerDamage");
                }
            }
    }
}
