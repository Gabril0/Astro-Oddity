//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using UnityEngine;

//public class InactiveBulletDeleter : MonoBehaviour
//{
//    [SerializeField] string tagToDelete = "EnemyBullet";
//    [SerializeField] float deletionInterval = 10f;

//    private float timer = 0f;

//    void Update()
//    {
//        timer += Time.deltaTime;
//        if (timer >= deletionInterval)
//        {
//            deleteInactiveObjects();
//            timer = 0f;
//        }
//    }

//    private void deleteInactiveObjects()
//    {
//        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDelete);
//        int deletedCount = 0;

//        foreach (GameObject obj in objectsWithTag)
//        {
//            Debug.Log(obj.activeSelf);
//            if (!obj.activeSelf)
//            {
//                Debug.Log("Entered");
//                Destroy(obj);
//                deletedCount++;
//            }
//        }

//        Debug.Log("Deleted " + deletedCount + " inactive objects.");
//    }
//}
