using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    #region TorchFunctions
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.gameObject.CompareTag("Player"))
        {
            if (c.transform.GetComponent<Player>().HasKey())
            {
                Destroy(this.gameObject);
            }
        }
    }
    #endregion
}
