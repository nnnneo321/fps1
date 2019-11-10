using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_script : MonoBehaviour
{   public Camera camera;
    public static int bulletHP=100;
    public AudioSource audiosource;
    private float timeBetweenShot = 0.5f;
    private float timer;
    private float timeleft;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletHP>0)
        {
            timer += Time.deltaTime;
            if(Input.GetMouseButton(0) && timer > timeBetweenShot)
            {
            Shot();
            }
        }
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;
             bulletHP += 10;
             Debug.Log(bulletHP);
        }




    }
    void Shot(){
            bulletHP -=1;
            audiosource.Play();
            int distance  = 100;
            Vector3 center =new Vector3(Screen.width/2,Screen.height/2,0);
            Ray ray = camera.ScreenPointToRay(center);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, distance)){
                if(hitInfo.collider.tag =="Enemy")
                {
                    hitInfo.collider.SendMessage("Damage");
                }
            }
    }
}
