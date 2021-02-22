using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class RollingState
    {
        protected List<string> _stateList = new List<string>();
        protected int _currentState = -1;
        public virtual void AddState(string state)
        {
            if (!_stateList.Contains(state))
                _stateList.Add(state);
        }
        public virtual void RemoveState(string state)
        {
            _stateList.Remove(state);
        }
        public virtual void ClearStates()
        {
            _stateList.Clear();
        }
        public virtual string GetCurrentState()
        {
            if (_stateList.Count > 0 && _currentState < 0)
                _currentState = 0;
            if (_currentState < _stateList.Count && _currentState >= 0)
                return _stateList[_currentState];
            else
                return "";
        }
        public virtual void SetCurrentState(string state)
        {
            int index = _stateList.IndexOf(state);
            if (index != -1)
                _currentState = index;
        }
        public virtual void NextState()
        {
            if (_stateList.Count == 0)
            {
                _currentState = -1;
                return;
            }
            _currentState++;
            if (_currentState >= _stateList.Count)
                _currentState = 0;
        }
        public virtual void PreviousState()
        {
            if (_stateList.Count == 0)
            {
                _currentState = -1;
                return;
            }
            _currentState--;
            if (_currentState < 0)
                _currentState = _stateList.Count - 1;
        }
        public virtual string[] ToArray()
        {
            return _stateList.ToArray();
        }
    }
}
