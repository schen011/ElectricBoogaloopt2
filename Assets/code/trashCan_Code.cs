using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan_Code : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Food"))
            {
                Destroy(other.gameObject);
            }

   }
}
