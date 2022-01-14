using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCard : MonoBehaviour
{
    [SerializeField] Sprite[] suit;
    [SerializeField] GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PickCard", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickCard()
    {
        GameObject destroy = Instantiate(card, transform.position, Quaternion.identity);
        card.GetComponent<SpriteRenderer>().sprite = suit[Random.Range(0, suit.Length)];
        Destroy(destroy, 5f);
    }
}
