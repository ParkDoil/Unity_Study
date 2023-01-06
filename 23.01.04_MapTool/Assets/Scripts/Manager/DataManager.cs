using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MapData
{
    public GameObject NowMap;
    public Queue<GameObject> SetCube;
    public bool AlreadyExsit;
}


public class DataManager : SingletonBehaviour<DataManager>
{

    private string _path;
    private const string _fileName = "MapData.json";

    private void OnEnable()
    {
        _path = Path.Combine(Application.dataPath + "/Data/", _fileName);
    }

    public void SaveMap(MapData _nowMap)
    {
        string _data = JsonUtility.ToJson(_nowMap);
        File.WriteAllText(_path, _data);
    }

    public MapData LoadMap()
    {
        MapData _loadMap = new MapData();
        _loadMap.SetCube = new Queue<GameObject>();

        string _data = File.ReadAllText(_path);
        _loadMap = JsonUtility.FromJson<MapData>(_data);

        return _loadMap;
    }
}
