using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    #region BasicFunctions
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.gameObject.CompareTag("Player"))
        {
            if (c.transform.GetComponent<Player>().HasKey())
            {
                c.transform.GetComponent<Player>().GotWin();
                Destroy(this.gameObject);
            }
        }
    }
    #endregion
}
