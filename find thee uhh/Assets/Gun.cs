using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update



    

    [SerializeField]
    private GameObject _bullet;


    public int damage;
    public float timeBtweenShooting, range;


    bool shooting, readytoShoot;


    public Camera fpsCam;
    public Transform attackPoint;
    public LayerMask whatToHit;
    public RaycastHit rayHit;





    void Start()
    {
        readytoShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
            Invoke("ResetShot", timeBtweenShooting);
        }
    }



    private void Shoot()
    {
        readytoShoot = false;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward , out rayHit, range, whatToHit))
        {
            print("nigga balls");
        }

        Invoke("RestShot", timeBtweenShooting);

        Instantiate(_bullet, attackPoint.position, Quaternion.identity);


    }

}
