using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class FactionMember : MonoBehaviour, IFactionMember
{
    public static int FactionsCount
    {
        get
        {
            lock (_membersCount)
            {
                return _membersCount.Count;
            }
        }
    }
    public static int GetWinner()
    {
        lock (_membersCount)
        {
            return _membersCount.Keys.First();
        }
    }
    private static Dictionary<int, List<int>> _membersCount = new Dictionary<int, List<int>>();

    public int FactionId => _factionId;
    [SerializeField] private int _factionId;
    [SerializeField] private bool _isSolder;
    private void Awake()
    {
        if (_factionId != 0 && _isSolder)
        {
            register();
        }
    }

    public void SetFaction(int factionId)
    {
        if (_isSolder)
        {
            _factionId = factionId;
            register();
        }
    }

    private void OnDestroy()
    {
        if (_isSolder)
        {
            unregister();
        }
    }

    private void register()
    {
        lock (_membersCount)
        {
            if (!_membersCount.ContainsKey(_factionId))
            {
                _membersCount.Add(_factionId, new List<int>());
            }
            if (!_membersCount[_factionId].Contains(GetInstanceID()))
            {
                _membersCount[_factionId].Add(GetInstanceID());
            }
        }
    }

    private void unregister()
    {
        lock (_membersCount)
        {
            if (_membersCount[_factionId].Contains(GetInstanceID()))
            {
                _membersCount[_factionId].Remove(GetInstanceID());
            }
            if (_membersCount[_factionId].Count == 0)
            {
                _membersCount.Remove(_factionId);
            }
        }
    }

}

