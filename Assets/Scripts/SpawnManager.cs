using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnManager : MonoBehaviour
{
   #region Editor Variables
   public EnemySpawnInfo[] m_EnemyTypes;
   #endregion

   #region Non-Editor Variables
   // look into coroutines
   private float[] m_EnemySpawnTimers;
   #endregion

   #region First Time Initialization and Set Up
   private void Awake()
   {
      m_EnemySpawnTimers = new float[m_EnemyTypes.Length];

      for (int i = 0; i < m_EnemyTypes.Length; i++) {
         m_EnemySpawnTimers[i] = m_EnemyTypes[i].FirstSpawnTime;
      }
   }
   #endregion

   #region Main Updates
   private void Update()
   {
      for (int i = 0; i < m_EnemyTypes.Length; i++) {
         m_EnemySpawnTimers[i] -= Time.deltaTime;
         if (m_EnemySpawnTimers[i] < 0) {
            Instantiate(m_EnemyTypes[i].EnemyPrefab);
            m_EnemySpawnTimers[i] = m_EnemyTypes[i].SpawnRate;

            m_EnemyTypes[i].ChangeSpawnRate(m_EnemyTypes[i].SpawnRate * 1.1f);
         }
      }
   }
   #endregion
}

public struct EnemySpawnInfo
{
   #region Editor Variables
   public GameObject m_EnemyPrefab;

   public float m_FirstSpawnTime;

   public float m_SpawnRate;
   #endregion

   #region Accessors and Mutators
   public GameObject EnemyPrefab
   {
      get { return m_EnemyPrefab; }
   }

   public float FirstSpawnTime
   {
      get { return m_FirstSpawnTime; }
   }

   public float SpawnRate
   {
      get { return m_SpawnRate; }
   }

   public void ChangeSpawnRate(float sr)
   {
      m_SpawnRate = sr;
   }
   #endregion
}