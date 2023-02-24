using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnManager : MonoBehaviour
{
   public GameObject wisp;
   public GameObject shade;
   public GameObject torch;

   public float shadeCap;
   public float wispTimer;
   public float torchTimer;

   private float nextWisp;
   private float nextTorch;
   private int shadeCount;

   public void Start() {
      nextWisp = wispTimer;
      shadeCount = 0;
   }

   public void Update() {
      nextWisp -= Time.deltaTime;
      nextTorch -= Time.deltaTime;
      shadeCap = shadeCap + Time.deltaTime * 0.1f;

      if (nextWisp < 0) {
         wispTimer = wispTimer * 0.95f;
         nextWisp = wispTimer;
         SpawnWisp();
      }
      
      if (nextTorch < 0) {
         torchTimer = torchTimer * 1.1f;
         nextTorch = torchTimer;
         Instantiate(torch, new Vector3(Random.Range(-15, 13), Random.Range(-6, 11), 0), Quaternion.identity);
      }

      if (shadeCount + 1 < shadeCap) {
         SpawnShade();
      }
   }

   public void SpawnWisp() {
      Instantiate(wisp, new Vector3(Random.Range(-15, 13), Random.Range(-6, 11), 0), Quaternion.identity);
   }
   
   public void SpawnShade() {
      shadeCount++;
      Instantiate(shade, new Vector3(Random.Range(-15, 13), Random.Range(-6, 11), 0), Quaternion.identity);
   }
}