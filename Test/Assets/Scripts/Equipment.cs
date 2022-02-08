using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    struct Node
    {
        public GameObject bone;
        public GameObject parentBone;
    }
    List<Node> boneList = new List<Node>();
    GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        Initialize(GameObject.Find("Player"));
        int asas = 11;
        int ass = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize(GameObject _player)
    {
        
        root = transform.transform.Find("Armature").transform.Find("Root").gameObject;

        ListAdd(root);
        BoneMove(_player.transform.Find("Mesh").gameObject.transform.GetChild(0).gameObject.transform.Find("Root").gameObject);
    }

    void ListAdd(GameObject _bone)
    {
        int childCount = _bone.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Node newNode = new Node();
            newNode.bone = _bone.transform.GetChild(i).gameObject;
            newNode.parentBone = _bone.transform.parent.gameObject;
            boneList.Add(newNode);
            ListAdd(_bone.transform.GetChild(i).gameObject);
        }
    }

    void BoneMove(GameObject _playerRoot)
    {
        foreach (Node _node in boneList)
        {
            GameObject searchBone = BoneSearch(_node.bone.name, _playerRoot);
            if (searchBone == _playerRoot)
                continue;

            _node.bone.transform.parent = searchBone.transform;
        }
    }

    GameObject BoneSearch(string _boneName, GameObject _playerBone, GameObject _searchBone = null)
    {
        int childCount = _playerBone.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            if (_searchBone != null)
                return _searchBone;

            if(_playerBone.transform.GetChild(i).name == _boneName)
            {
                _searchBone = _playerBone.transform.GetChild(i).gameObject;
            }
            else
            {
                _searchBone = BoneSearch(_boneName, _playerBone.transform.GetChild(i).gameObject);
            }
        }
        return _searchBone;
        //다음에 본 공통적인 이름으로 넣기 + 장착해제 구현해야함
    }
}
