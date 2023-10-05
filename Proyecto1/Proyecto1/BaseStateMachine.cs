using Stateless;

namespace Proyecto1
{
    /// <summary>
    /// Represents a base state machine with generic states and triggers.
    /// </summary>
    /// <typeparam name="TState">The type of states in the state machine.</typeparam>
    /// <typeparam name="TTrigger">The type of triggers in the state machine.</typeparam>
    public class BaseStateMachine<TState, TTrigger>
    {
        protected StateMachine<TState, TTrigger> stateMachine;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStateMachine{TState, TTrigger}"/> class with an initial state.
        /// </summary>
        /// <param name="initialState">The initial state of the state machine.</param>
        public BaseStateMachine(TState initialState)
        {
            stateMachine = new StateMachine<TState, TTrigger>(initialState);
        }

        /// <summary>
        /// Transitions the state machine to a new state based on a trigger.
        /// </summary>
        /// <param name="trigger">The trigger that causes the state transition.</param>
        public void Transition(TTrigger trigger)
        {
            stateMachine.Fire(trigger);
        }

        /// <summary>
        /// Gets the current state of the state machine.
        /// </summary>
        /// <returns>The current state of the state machine.</returns>
        public TState GetCurrentState()
        {
            return stateMachine.State;
        }
    }
}
