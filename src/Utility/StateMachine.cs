using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilFarmingGame.Utility
{
    /// <summary>
    /// Finite state machine. Useful for AI and scripted events.
    /// </summary>
    public class StateMachine
    {
        private IState currentState;

        public void Update()
        {
            currentState?.Update();
        }

        public void SetState(IState state)
        {
            IState prevState = currentState;
            currentState?.OnExit(state);
            currentState = state;
            currentState?.OnEnter(prevState);
        }
    }

    // TODO: Abstract class?
    /// <summary>
    /// Represents a state in a finite state machine.
    /// </summary>
    public interface IState
    {
        /// <summary>Called when the state is entered.</summary>
        void OnEnter(IState previousState);

        /// <summary>Called each time the state machine is updated.</summary>
        void Update();

        /// <summary>Called when the state is exited.</summary>
        void OnExit(IState nextState);
    }
}
