using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private PlayerHandler TakeDamage = new PlayerHandler();
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            TakeDamage.DamagePlayer(30, false); 
            Debug.Log("Damaging player");
            Destroy(this.gameObject);
            //Player p = other.GetComponent<Player>();
            //p?.Attack(p)
        }

        if(!other.gameObject.GetComponent<Fireball>())
        Destroy(this.gameObject);
    }
}
