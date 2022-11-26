using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPattren : MonoBehaviour
{
    // Start is called before the first frame update


    public static float counter = 4f;
    public static float total = 0f;
    public int value;


    void Start()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            counter -= 1;
            total += value * Mathf.Pow(10, counter);
            print("total is : " + total);
            print("rCounter is : " + counter);


            if (counter == 0)
            {
                print("2nd if ");
                if (total == 4423)
                {
                    
                    print("YAAAY YOU DID IT");
                }
                else
                {
                    print("else");
                    counter = 4f;
                    total = 0;
                }
            }
        }
    }

}
