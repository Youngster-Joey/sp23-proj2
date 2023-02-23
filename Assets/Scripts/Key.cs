using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    #region KeyFunctions
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.gameObject.CompareTag("Player"))
        {
            c.transform.GetComponent<Player>().GotKey();
            Destroy(this.gameObject);
        }
    }
    #endregion
}
