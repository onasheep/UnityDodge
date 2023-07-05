using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();

        rigid.velocity = this.transform.forward * speed;
        Destroy(this.gameObject, 5.0f);
    }

    private void Update()
    {
        this.transform.Rotate(new Vector3(180 * Time.deltaTime, 180 * Time.deltaTime, 180 * Time.deltaTime));
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == ("Player"))
        {

            PlayerController playerControler = other.GetComponent<PlayerController>();

            if(playerControler != null)
            {
                playerControler.Die();
            }
        }
    }
  
}
