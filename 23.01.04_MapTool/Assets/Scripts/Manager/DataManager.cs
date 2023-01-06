using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MapData
{
    public bool AlreadyExist;

    public List<float> X = new List<float>();
    public List<float> Y = new List<float>();
    public List<float> Z = new List<float>();
    public List<string> Type = new List<string>();
}


public class DataManager : SingletonBehaviour<DataManager>
{
    private string _path;
    private const string _fileName = "MapData";

    private void OnEnable()
    {
        _path = Path.Combine(Application.dataPath + "/Data/", _fileName);
        print(_path);
    }

    public void SaveMap(MapData _nowMap)
    {
        string _data = JsonUtility.ToJson(_nowMap);
        print(_data);
        File.WriteAllText(_path, _data);
    }

    public MapData LoadMap()
    {
        MapData _loadMap = new MapData();

        string _data = File.ReadAllText(_path);
        print(_data);

        if(_loadMap.AlreadyExist == true)
        {
            JsonUtility.FromJsonOverwrite(_data, _loadMap);
        }
        else
        {
            _loadMap = JsonUtility.FromJson<MapData>(_data);
        }

        return _loadMap;
    }
}
