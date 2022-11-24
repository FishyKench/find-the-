using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCube : MonoBehaviour
{

    public int numOne, numTwo, numThree;
    public GameObject greenCube;

    private void Start()
    {
          
    }



    public void DestoryME()
    {
        Destroy(this.gameObject);
    }


}
