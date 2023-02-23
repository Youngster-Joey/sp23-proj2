using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    #region TorchVariables
    public float lightGain;
    #endregion

    #region TorchFunctions
    private void OnCollisionEnter2D(Collision2D c) {
        Debug.Log("yo?" + c.transform.gameObject.name);
        if (c.transform.gameObject.CompareTag("Player")) {
            Debug.Log("yo??");
            c.transform.GetComponent<Player>().ChangeLight(lightGain);
            Destroy(this.gameObject);
        }
    }
    #endregion
}
