using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomCard : MonoBehaviour
{
    //[SerializeField] Sprite[] suit;
    //[SerializeField] GameObject card;
    [SerializeField] List<GameObject> cards = new List<GameObject>();
    [SerializeField] List<GameObject> shuffledList = new List<GameObject>();
    [SerializeField] List<GameObject> discards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("PickCard", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shuffle();
            Debug.Log("Cards Shuffled");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(cards.Count > 5)
            {
                PickCard();
                Debug.Log("Card Drawn");
            }
            else 
            {
                Debug.Log("Out of Cards");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            discardToDraw();
        }
    }

    void PickCard()
    {
        GameObject destroy = Instantiate(cards[0], transform.position, Quaternion.identity) ;
        GameObject destroy1 = Instantiate(cards[1], transform.position + new Vector3(2,0,0) , Quaternion.identity);
        GameObject destroy2 = Instantiate(cards[2], transform.position + new Vector3(4, 0, 0), Quaternion.identity);
        GameObject destroy3 = Instantiate(cards[3], transform.position + new Vector3(6, 0, 0), Quaternion.identity);
        GameObject destroy4 = Instantiate(cards[4], transform.position + new Vector3(8, 0, 0), Quaternion.identity);
        var selected = cards[0];
        var selected1 = cards[1];
        var selected2 = cards[2];
        var selected3 = cards[3];
        var selected4 = cards[4];
        cards.Remove(selected);
        cards.Remove(selected1);
        cards.Remove(selected2);
        cards.Remove(selected3);
        cards.Remove(selected4);
        discards.Insert(discards.Count, selected);
        discards.Insert(discards.Count, selected1);
        discards.Insert(discards.Count, selected2);
        discards.Insert(discards.Count, selected3);
        discards.Insert(discards.Count, selected4);
        //Destroy(destroy, 1f);
    }

    void Shuffle()
    {
        shuffledList = cards.OrderBy(x => Random.value).ToList();
        cards.Clear();
        cards.AddRange(shuffledList);
        shuffledList.Clear();
    }
    
    void discardToDraw()
    {
        cards.AddRange(discards);
        discards.Clear();
    }
}
