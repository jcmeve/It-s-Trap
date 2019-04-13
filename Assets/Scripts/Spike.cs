using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float force;
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player")) {
            Debug.Log(damage + "플레이어에게 줌");
            //폭발에 의한 밀쳐내기 메소드
            collision.transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5f);
            collision.transform.GetComponent<StatusManager>().DecreaseHP(damage);
        }
    }
}
