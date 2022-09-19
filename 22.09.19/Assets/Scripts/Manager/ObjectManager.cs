using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : SingletonBehaviour<ObjectManager>
{
    [SerializeField]
    GameObject _player;

    public float PrevDistance = 5f;

    public List<GameObject> InAreaObjects;

    void Start()
    {
        InAreaObjects = new List<GameObject>();
    }

    public void AddList(GameObject _gameObject)
    {
        if (false == InAreaObjects.Contains(_gameObject))
        {
            InAreaObjects.Add(_gameObject);
        }
        else
        {
            return;
        }
    }

    public void RemoveList(GameObject _gameObject)
    {
        if (InAreaObjects.Contains(_gameObject))
        {
            InAreaObjects.Remove(_gameObject);
        }
        else
        {
            return;
        }
    }

    void FixedUpdate()
    {
        float ShortestDistance = 5f;

        foreach (GameObject _gameObject in InAreaObjects)
        {
            float Distance = Vector3.Distance(_gameObject.transform.position, _player.transform.position);
            
            if (Distance <= ShortestDistance)
            {
                ShortestDistance = Distance;

                for (int i = 0; i < InAreaObjects.Count; ++i)
                {
                    InAreaObjects[i].GetComponent<CapsuleStatus>().SetNormal();
                }

                _gameObject.GetComponent<CapsuleStatus>().ChangeColor();
            }
        }
    }
}
