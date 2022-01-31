using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTING_SPACE : MonoBehaviour
{
    public int initHandSize;

    public GameObject cardPrefab;
    public PlaySpace playSpace;


    List<GameObject> p1_hand = new List<GameObject>();

    public float diff;

    private void Start()
    {
        StartCoroutine(SpawnCards(2));
    }


    GameObject lastSelected;
    Color c;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit info, Mathf.Infinity, LayerMask.GetMask("Card"));
        if (info.collider && info.collider.gameObject != lastSelected)
        {
            Renderer r = info.collider.gameObject.GetComponent<Renderer>();
            if (!lastSelected)
            {
                c = r.material.color;
            }
            info.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            if (lastSelected)
            {
                lastSelected.GetComponent<Renderer>().material.color = c;

            }
            lastSelected = info.collider.gameObject;
        }
    }



    IEnumerator SpawnCards(float delay)
    {
        for (int i = 0; i < initHandSize; i++)
        {
            var card = Instantiate(cardPrefab);
            card.transform.position = playSpace.transform.position + playSpace.editorData.handCenter;
            p1_hand.Add(card);
            CardPositionHelper.DistributeCards(p1_hand, playSpace.editorData.handCenter, 1.1f);
            yield return new WaitForSeconds(delay);
        }
    }
}


public static class CardPositionHelper
{
    public static void DistributeCards(List<GameObject> cards, Vector3 center, float offset)
    {
        int count = cards.Count;

        float i = -offset * (count / 2);
        foreach (var card in cards)
        {

            float pos = center.z + i;
            Vector3 newPosition = new Vector3(card.transform.position.x, card.transform.position.y, pos);
            card.transform.position = newPosition;

            i += offset;
        }
    }
}
