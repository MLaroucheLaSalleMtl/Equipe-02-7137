using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossRed : MonoBehaviour
{
    [SerializeField] GameObject Fireball;
    public Transform Throat;
    [SerializeField] Transform Player;
    [Header("Fireball")]
    [SerializeField]
    float fireballRange = 3;
    [SerializeField]
    Vector3 offset;
    [SerializeField] GameObject ArenaWall;
    public string MoveToPlayer;
    [SerializeField] private float Range = 30;
    [SerializeField] private float Melee = 5;
    [SerializeField] private float Distance;
    private RaycastHit Cast;
    
    public  bool isclose;
    private bool ismelee;
    private bool isdead;
    private Animator DragonAnim;
    private void Start()
    {
        DragonAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.position);


        if (Distance <= Melee)
        {
            ismelee = true;
            isclose = false;
        }
        else if(Distance <= Range)
        {
            isclose = true;
            ismelee = false;
        }
        else
        {
            ismelee = false;
            isclose = false;
        }
     
        if (isclose== false && ismelee == false)    
        {
            DragonAnim.SetTrigger("isnthere");
        }
     if(isclose==true && ismelee == false)
        {
            DragonAnim.SetBool("isclose", true);
            DragonAnim.SetBool("ismelee", false);
            transform.LookAt(Player.transform);
            ArenaWall.SetActive(true);
           
        }
     if(isclose==false && ismelee == true)
        {
            DragonAnim.SetBool("ismelee", true);
            DragonAnim.SetBool("isclose", false);
            Fireball.SetActive(false);
        }
      if(isdead==true)
        {
            DragonAnim.SetTrigger("isdead");
            ArenaWall.SetActive(false);
        }


      
    }

    public void Fire()
    {
        var rot = (Player.transform.position + offset )- Throat.position;
        rot.Normalize();
        Rigidbody t = Instantiate(Fireball, Throat.transform.position, Quaternion.Euler(rot)).AddComponent<Rigidbody>();
        t.useGravity = false;
        t.drag = 0;


        foreach (var item in t.GetComponentsInChildren<Transform>())
        {
            item.gameObject.SetActive(true);
        }
        t.AddForce(rot * fireballRange , ForceMode.Acceleration);
        
    }
    
}
