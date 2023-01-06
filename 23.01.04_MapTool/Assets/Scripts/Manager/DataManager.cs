using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MapData
{
    public bool AlreadyExist;

    public List<Vector3> ObjPosition = new List<Vector3>();
    public List<string> Type = new List<string>();
}


public class DataManager : SingletonBehaviour<DataManager>
{
    private string _path;
    private const string _editorFilePath = "/Resources/MapData.json";
    private const string _buildFilePath = "MapData.json";

    private void OnEnable()
    {
#if UNITY_EDITOR
        _path = Application.dataPath + _editorFilePath;
#else
         _path = Application.dataPath + _buildFilePath; 
#endif
        print(_path);
    }

    public void SaveMap(MapData _nowMap)
    {
        string _data = JsonUtility.ToJson(_nowMap,true);
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
