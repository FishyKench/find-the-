using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update



    

    [SerializeField]
    private GameObject _bullet;

    public float timeBtweenShooting, range;


    public Camera fpsCam;
    public Transform attackPoint;
    public LayerMask whatToHit;
    public RaycastHit rayHit;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }



    private void Shoot()
    {

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward , out rayHit, range, whatToHit))
        {
            print("nigga balls");
        }


        Instantiate(_bullet, attackPoint.position, Quaternion.identity);


    }


}
