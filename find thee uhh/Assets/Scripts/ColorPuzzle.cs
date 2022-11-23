using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject redBlock;
    public GameObject greenBlock;
    public GameObject blueBlock;

    public int i = 0;

    public int red, green, blue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet" && this.gameObject.tag == "red")
        {
            i++;
            i = red;
            RedHit();
        }

        else if(other.tag == "bullet" && this.gameObject.tag == "blue")
        {
            i++;
            i = blue;
            BlueHit();
        }
        else
        {
            i++;
            green = i;
            GreenHit();
        }
    }
   






    private void RedHit()
    {
        print("Red is : " + red);
    }

    private void BlueHit()
    {
        print("Blue is : " + blue);
    }


    private void GreenHit()
    {

        print("Green is : " + green);
    }

    
}
