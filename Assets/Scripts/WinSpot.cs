using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinSpot : MonoBehaviour
{

    #region BasicFunctions
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    #endregion
}
