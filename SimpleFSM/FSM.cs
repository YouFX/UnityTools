using System;
using System.Collections.Generic;
namespace FX.Tools
{
    public class FSM<T>
    {
        public T prevState;
        public T currentState;
        public Dictionary<T, Action[]> table;

        public FSM()
        {
            table = new Dictionary<T, Action[]>();
        }

        public void AddState(T state, Action onEnter, Action onLogicUpdate, Action onFixedUpdate = null, Action onExit = null)
        {
            if (table.ContainsKey(state))
            {
                //如果包含则覆盖
                table[state][0] = onEnter;
                table[state][1] = onLogicUpdate;
                table[state][2] = onFixedUpdate;
                table[state][3] = onExit;
                return;
            }
            table.Add(state, new[] { onEnter, onLogicUpdate, onFixedUpdate, onExit });
        }
        public void Transition(T target, bool repeat = false)
        {
            if (Equals(target, currentState) && !repeat) return;
            prevState = currentState;
            Exit();
            currentState = target;
            Enter();
        }
        private void Enter()
        {
            table[currentState][0]?.Invoke();
        }
        public void LogicUpdate()
        {
            table[currentState][1]?.Invoke();
        }
        public void FixedUpdate()
        {
            table[currentState][2]?.Invoke();
        }
        private void Exit()
        {
            table[currentState][3]?.Invoke();
        }
    }
}