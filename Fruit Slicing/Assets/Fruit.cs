using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public float startForce = 12f;

    Rigidbody2D rb;
    Blade blade;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        blade = GetComponent<Blade>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Blade")
        {
            
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            Vector2 normalize = Blade.direction;
            Quaternion rotation2 = Quaternion.LookRotation(normalize);
            
            //try to get rigidbody on childs
            GameObject fruitSlice = Instantiate(fruitSlicedPrefab,transform.position,rotation2);
            Component[] trans = fruitSlice.GetComponents(typeof(Rigidbody));

            Debug.Log(trans.Length);
            Destroy(gameObject);
            Destroy(fruitSlice,5f);
        }
    }

}
