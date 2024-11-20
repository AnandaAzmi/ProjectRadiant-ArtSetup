using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnShieldRipples : MonoBehaviour
{
    public GameObject shieldRipples;
    private VisualEffect shieldRipplesVFX;
    private void OnMouseDown()
    {
        var ripples = Instantiate(shieldRipples, transform.position, Quaternion.identity, transform) as GameObject;
        shieldRipplesVFX = ripples.GetComponent<VisualEffect>();
        shieldRipplesVFX.SetVector3("SphereCenter", transform.position);
        Destroy(ripples, 2);
    }
    // private void OnCollisionEnter(Collision co)
    // {
    //     if (co.gameObject.tag == "Bullet")
    //     {
    //         var ripples = Instantiate(shieldRipples, transform) as GameObject;
    //         shieldRipplesVFX = ripples.GetComponent<VisualEffect>();
    //         shieldRipplesVFX.SetVector3("SphereCenter", co.contacts[0].point);

    //         Destroy(ripples, 2);
    //     }
    // }
}
