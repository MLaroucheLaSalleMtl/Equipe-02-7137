using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField] float speed=2;
    public Transform owner;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        Vector3 direction =target.transform.position- transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Monster")
        {
            //monster loses hp
        }
        Destroy(this.gameObject);
    }

}
