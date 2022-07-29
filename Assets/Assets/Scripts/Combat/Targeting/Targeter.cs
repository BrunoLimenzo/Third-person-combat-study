using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> _targetlist = new List<Target>();

    public Target _CurrentTarget { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Target target))
        {
            _targetlist.Add(target);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Target target))
        {
            _targetlist.Remove(target);
        }
    }

    public void SelectTarget()
    {
        if(_targetlist.Count == 0) { return; }

        _CurrentTarget = _targetlist[0];
    }

    public void Cancel()
    {
        _CurrentTarget = null;
    }

    public bool HasTarget()
    {
        return _CurrentTarget == null;
    }
}
