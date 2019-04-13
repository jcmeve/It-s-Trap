using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType {
    Score,
    Normalgun_Bullet,
}
public class Item : MonoBehaviour
{
    public ItemType itemType;
    public int extraScore;
    public int extraBullet;
    void Update() {
            transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime);
    }
    
}
