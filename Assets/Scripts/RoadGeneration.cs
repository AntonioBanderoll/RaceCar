using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _road;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxRoadCount;
    
    private List<GameObject> _roads = new List<GameObject>();

    private void Start()
    {
        ResetLevel();
        StartLevel();
    }
    private void Update()
    {
        if (_speed == 0) return;

        foreach(GameObject road in _roads)
        {
            road.transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if (_roads[0].transform.position.z < -30)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
            CreatorRoad();
        }
    }

    public void StartLevel()
    {
        _speed = _maxSpeed;
    }

    public void CreatorRoad()
    {
        Vector3 pos = Vector3.zero;
        if (_roads.Count > 0)
        {
            pos = _roads[_roads.Count - 1].transform.position + new Vector3(0, 0, 30);
        }

        GameObject creartor = Instantiate(_road, pos, Quaternion.identity);
        creartor.transform.SetParent(transform);
        _roads.Add(creartor);
    }
    public void ResetLevel()
    {
        _speed = 0;
        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }

        for (int i = 0; i < _maxRoadCount; i++)
        {
            CreatorRoad();
        }
    }
}
