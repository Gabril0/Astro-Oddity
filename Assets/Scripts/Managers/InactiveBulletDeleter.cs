using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveBulletDeleter : MonoBehaviour
{
    [SerializeField] string tagToDelete = "EnemyBullet";
    [SerializeField] float deletionInterval = 10f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= deletionInterval)
        {
            deleteInactiveObjects();
            timer = 0f;
        }
    }

    private void deleteInactiveObjects()
    { 
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDelete);
        foreach (GameObject obj in objectsWithTag)
        {
            if (!obj.activeSelf)
            {
                Destroy(obj);
            }
        }
    } 
}
