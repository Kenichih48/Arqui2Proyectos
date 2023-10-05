using Stateless;
namespace Proyecto1
{
    /// <summary>
    /// Represents a MESI/MOESI state machine for cache coherence management.
    /// </summary>
    public class StateMachine
    {
        private StateMachine<State, Trigger> stateMachine;

        /// <summary>
        /// Enumerates the possible states of the state machine.
        /// </summary>
        public enum State
        {
            Modified,
            Exclusive,
            Shared,
            Invalid,
            Owned
        }

        /// <summary>
        /// Enumerates the possible triggers for the state machine transitions.
        /// </summary>
        public enum Trigger
        {
            ReadHit,
            WriteHit,
            ReadMissShared,
            ReadMissExclusive,
            WriteMiss,
            SnoopHitWrite,
            SnoopHitRead        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateMachine"/> class with an initial state.
        /// </summary>
        public StateMachine(string type)
        {
            stateMachine = new StateMachine<State, Trigger>(State.Invalid);
            if (type.Equals("MESI"))
            {
                CreateMESI();
            }
            else
            {
                CreateMOESI();
            }
        }

        /// <summary>
        /// Configures the transitions for the MESI state machine.
        /// </summary>
        private void CreateMESI()
        {
            stateMachine = new StateMachine<State, Trigger>(State.Invalid);

            stateMachine.Configure(State.Modified)
                .PermitReentry(Trigger.WriteHit)
                .PermitReentry(Trigger.ReadHit)
                .Permit(Trigger.SnoopHitRead, State.Shared)
                .Permit(Trigger.SnoopHitWrite, State.Invalid)
                .Permit(Trigger.ReadMissExclusive, State.Exclusive);

            stateMachine.Configure(State.Exclusive)
                .PermitReentry(Trigger.ReadHit)
                .Permit(Trigger.WriteHit, State.Modified)
                .Permit(Trigger.SnoopHitWrite, State.Invalid)
                .Permit(Trigger.SnoopHitRead, State.Shared);

            stateMachine.Configure(State.Shared)
                .PermitReentry(Trigger.ReadHit)
                .PermitReentry(Trigger.SnoopHitRead)

                .Permit(Trigger.WriteHit, State.Modified)

                .Permit(Trigger.SnoopHitWrite, State.Invalid);

            stateMachine.Configure(State.Invalid)
                .Permit(Trigger.ReadMissShared, State.Shared)
                .Permit(Trigger.ReadMissExclusive, State.Exclusive)
                .Permit(Trigger.WriteMiss, State.Modified)
                .Permit(Trigger.WriteHit, State.Modified);
        }

        public void CreateMOESI()
        {
            stateMachine.Configure(State.Modified)
                .PermitReentry(Trigger.WriteHit)
                .PermitReentry(Trigger.ReadHit)
                .Permit(Trigger.SnoopHitRead, State.Shared)
                .Permit(Trigger.SnoopHitWrite, State.Invalid)
                .Permit(Trigger.ReadMissExclusive, State.Exclusive);

            stateMachine.Configure(State.Exclusive)
                .PermitReentry(Trigger.ReadHit)
                .Permit(Trigger.WriteHit, State.Modified)   
                .Permit(Trigger.SnoopHitWrite, State.Invalid)
                .Permit(Trigger.SnoopHitRead, State.Shared);

            stateMachine.Configure(State.Shared)
                .PermitReentry(Trigger.ReadHit)
                .PermitReentry(Trigger.SnoopHitRead)

                .Permit(Trigger.WriteHit, State.Modified)

                .Permit(Trigger.SnoopHitWrite, State.Invalid);

            stateMachine.Configure(State.Invalid)
                .Permit(Trigger.ReadMissShared, State.Shared)
                .Permit(Trigger.ReadMissExclusive, State.Exclusive)
                .Permit(Trigger.WriteMiss, State.Modified)
                .Permit(Trigger.WriteHit, State.Modified);
        }

        /// <summary>
        /// Gets the current state for the state machine.
        /// </summary>
        /// <returns>The current state.</returns>
        public State GetCurrentState()
        {
            return stateMachine.State;
        }

        /// <summary>
        /// Fires the Read Hit trigger in the MESI state machine.
        /// </summary>
        public void ReadHit()
        {
            stateMachine.Fire(Trigger.ReadHit);
        }

        /// <summary>
        /// Fires the Write Hit trigger in the MESI state machine.
        /// </summary>
        public void WriteHit()
        {
            stateMachine.Fire(Trigger.WriteHit);
        }

        /// <summary>
        /// Fires the Read Miss Shared trigger in the MESI state machine.
        /// </summary>
        public void ReadMissShared()
        {
            stateMachine.Fire(Trigger.ReadMissShared);
        }

        /// <summary>
        /// Fires the Read Miss Exclusive trigger in the MESI state machine.
        /// </summary>
        public void ReadMissExclusive()
        {
            stateMachine.Fire(Trigger.ReadMissExclusive);
        }

        /// <summary>
        /// Fires the Write Miss trigger in the MESI state machine.
        /// </summary>
        public void WriteMiss()
        {
            stateMachine.Fire(Trigger.WriteMiss);
        }

        /// <summary>
        /// Fires the Snooping Hit Write trigger in the MESI state machine.
        /// </summary>
        public void SnoopHitWrite()
        {
            stateMachine.Fire(Trigger.SnoopHitWrite);
        }
        /// <summary>
        /// Fires the Snooping Hit Read trigger in the MESI state machine.
        /// </summary>
        public void SnoopHitRead()
        {
            stateMachine.Fire(Trigger.SnoopHitRead);
        }
    }
}