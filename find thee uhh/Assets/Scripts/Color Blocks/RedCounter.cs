using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCounter : MonoBehaviour
{
    // Start is called before the first frame update


    public static float rCounter = 3f;
    public static float total = 0f;
    public int value;


    public GameObject mainCube;
    void Start()
    {
        
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            rCounter -= 1;
            total += value * Mathf.Pow(10, rCounter);
            print("total is : " +total);
            print("rCounter is : " + rCounter);


            if(rCounter == 0)
            {
                print("2nd if ");
                if (total == 123)
                {
                    print("3rd if ");
                    mainCube.GetComponent<MainCube>().DestoryME();
                }
                else
                {
                    print("else");
                    rCounter = 3;
                    total = 0; 
                }
            }
        }
    }

}
