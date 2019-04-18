using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Player p = other.GetComponent<Player>();
            p?.Attack(p);
        }

        if(!other.gameObject.GetComponent<Fireball>())
        Destroy(this.gameObject);
    }
}
