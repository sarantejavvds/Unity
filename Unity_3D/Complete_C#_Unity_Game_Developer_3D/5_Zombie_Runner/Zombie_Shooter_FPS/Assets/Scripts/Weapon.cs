using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Camera First_Person_Camera; // Gives Main Camera from Player

    public float Raycast_Range = 100f; // Shoots for a distance

    [SerializeField] float Damage_by_Weapon = 30f;

    public ParticleSystem Gun_Effect; // Let's give Muzzle Flash

    public GameObject Hit_Impact; // give Hit_Impact_from_Gun

    public AMMO AMMUNITION_Slot;

    public Different_AMMUNITIONS ammo_Type;

    public float Time_Between_Each_Shot = 0.5f;

    public TextMeshProUGUI current_Ammo_Display_Text;

  //  bool Can_Shoot = true;


    void OnEnable()
    {
      //  Can_Shoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Play_Gun_Effect()
    {
        Gun_Effect.Play();
    }

    void Hit_Impact_From_GUN(RaycastHit Hit)
    {
        GameObject impact = Instantiate(Hit_Impact, Hit.point, Quaternion.LookRotation(Hit.normal));

        Destroy(impact, 0.2f);
    }

    void RayCasting_Process()
    {
        RaycastHit hit;

        if (Physics.Raycast(First_Person_Camera.transform.position, First_Person_Camera.transform.forward, out hit, Raycast_Range))
        {
            Hit_Impact_From_GUN(hit);

            Debug.Log("I hit the " + hit.transform.name);

            Enemy_Health target = hit.transform.GetComponent<Enemy_Health>();

            if (target == null)
            {
                return;
            }

            target.Damage_Taken_To_Zombie_From_Player_Weapon(Damage_by_Weapon);
        }
        else
        {
            return;
        }
    }

    IEnumerator Shoot_Bullets()
    {
       // Can_Shoot = false;

        if(AMMUNITION_Slot.Get_Current_AMMO(ammo_Type) > 0)
        {
            Play_Gun_Effect();

            RayCasting_Process();

            AMMUNITION_Slot.Reduce_AMMO_amount_for_every_Firing_of_Bullets(ammo_Type);
        }

        yield return new WaitForSeconds(Time_Between_Each_Shot);

       // Can_Shoot = true;
    }

    void Display_Current_AMMO()
    {
        int current_AMMO = AMMUNITION_Slot.Get_Current_AMMO(ammo_Type);

        current_Ammo_Display_Text.text = $"{name} has {current_AMMO} Ammo left";
    }

    // Update is called once per frame
    void Update()
    {
        Display_Current_AMMO();

       if(Input.GetButtonDown("Fire1"))
       {
           StartCoroutine( Shoot_Bullets() );
       }
        
    }

}
