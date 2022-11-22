using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulltScript : MonoBehaviour
{

    public Rigidbody rb;
    private Gun rr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DIEE());
    }
    

    // Update is called once per frame
    void Update()
    {
        this.transform.position = transform.position + Camera.main.transform.forward * 2;
        rb.velocity = Camera.main.transform.forward * 4;
    }

    IEnumerator DIEE()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
