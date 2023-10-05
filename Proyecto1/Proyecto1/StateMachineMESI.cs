using Stateless;
namespace Proyecto1
{
    /// <summary>
    /// Represents a MESI state machine for cache coherence management.
    /// </summary>
    public class StateMachineMESI : BaseStateMachine<StateMachineMESI.MesiState, StateMachineMESI.MesiTrigger>
    {
        /// <summary>
        /// Enumerates the possible states of the MESI state machine.
        /// </summary>
        public enum MesiState
        {
            Modified,
            Exclusive,
            Shared,
            Invalid
        }

        /// <summary>
        /// Enumerates the possible triggers for the MESI state machine transitions.
        /// </summary>
        public enum MesiTrigger
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
        /// Initializes a new instance of the <see cref="StateMachineMESI"/> class with an initial state.
        /// </summary>
        public StateMachineMESI() : base(MesiState.Invalid)
        {
            ConfigureTransitions();
        }

        /// <summary>
        /// Configures the transitions for the MESI state machine.
        /// </summary>
        private void ConfigureTransitions()
        {
            stateMachine = new StateMachine<MesiState, MesiTrigger>(MesiState.Invalid);

            stateMachine.Configure(MesiState.Modified)
                .PermitReentry(MesiTrigger.WriteHit)
                .PermitReentry(MesiTrigger.ReadHit)
                .Permit(MesiTrigger.SnoopHitRead, MesiState.Shared)
                .Permit(MesiTrigger.SnoopHitWrite, MesiState.Invalid);

            stateMachine.Configure(MesiState.Exclusive)
                .PermitReentry(MesiTrigger.ReadHit)
                .Permit(MesiTrigger.WriteHit, MesiState.Modified)
                .Permit(MesiTrigger.SnoopHitWrite, MesiState.Invalid)
                .Permit(MesiTrigger.SnoopHitRead, MesiState.Shared);

            stateMachine.Configure(MesiState.Shared)
                .PermitReentry(MesiTrigger.ReadHit)
                .PermitReentry(MesiTrigger.SnoopHitRead)

                .Permit(MesiTrigger.WriteHit, MesiState.Modified)

                .Permit(MesiTrigger.SnoopHitWrite, MesiState.Invalid);

            stateMachine.Configure(MesiState.Invalid)
                .Permit(MesiTrigger.ReadMissShared, MesiState.Shared)
                .Permit(MesiTrigger.ReadMissExclusive, MesiState.Exclusive)
                .Permit(MesiTrigger.WriteMiss, MesiState.Modified)
                .Permit(MesiTrigger.WriteHit, MesiState.Modified);
        }

        /// <summary>
        /// Fires the Read Hit trigger in the MESI state machine.
        /// </summary>
        public void ReadHit()
        {
            stateMachine.Fire(MesiTrigger.ReadHit);
        }

        /// <summary>
        /// Fires the Write Hit trigger in the MESI state machine.
        /// </summary>
        public void WriteHit()
        {
            stateMachine.Fire(MesiTrigger.WriteHit);
        }

        /// <summary>
        /// Fires the Read Miss Shared trigger in the MESI state machine.
        /// </summary>
        public void ReadMissShared()
        {
            stateMachine.Fire(MesiTrigger.ReadMissShared);
        }

        /// <summary>
        /// Fires the Read Miss Exclusive trigger in the MESI state machine.
        /// </summary>
        public void ReadMissExclusive()
        {
            stateMachine.Fire(MesiTrigger.ReadMissExclusive);
        }

        /// <summary>
        /// Fires the Write Miss trigger in the MESI state machine.
        /// </summary>
        public void WriteMiss()
        {
            stateMachine.Fire(MesiTrigger.WriteMiss);
        }

        /// <summary>
        /// Fires the Snooping Hit Write trigger in the MESI state machine.
        /// </summary>
        public void SnoopHitWrite()
        {
            stateMachine.Fire(MesiTrigger.SnoopHitWrite);
        }
        /// <summary>
        /// Fires the Snooping Hit Read trigger in the MESI state machine.
        /// </summary>
        public void SnoopHitRead()
        {
            stateMachine.Fire(MesiTrigger.SnoopHitRead);
        }
    }
}