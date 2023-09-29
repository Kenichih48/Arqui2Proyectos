using Stateless;
namespace Proyecto1
{
    public class StateMachineMESI
    {
        private StateMachine<MesiState, MesiTrigger> stateMachine;

        public enum MesiState
        {
            Modified,
            Exclusive,
            Shared,
            Invalid
        }

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

        public StateMachineMESI()
        {
            stateMachine = new StateMachine<MesiState, MesiTrigger>(MesiState.Invalid);

            stateMachine.Configure(MesiState.Modified)
                .Permit(MesiTrigger.WriteHit, MesiState.Modified)
                .Permit(MesiTrigger.ReadHit, MesiState.Modified)
                .Permit(MesiTrigger.SnoopHitRead, MesiState.Shared)
                .Permit(MesiTrigger.SnoopHitWrite, MesiState.Invalid);

            stateMachine.Configure(MesiState.Exclusive)
                .Permit(MesiTrigger.ReadHit, MesiState.Exclusive)
                .Permit(MesiTrigger.WriteHit, MesiState.Modified)
                .Permit(MesiTrigger.SnoopHitWrite, MesiState.Invalid)
                .Permit(MesiTrigger.SnoopHitRead, MesiState.Shared);

            stateMachine.Configure(MesiState.Shared)
                .Permit(MesiTrigger.ReadHit, MesiState.Shared)
                .Permit(MesiTrigger.WriteHit, MesiState.Modified)
                .Permit(MesiTrigger.SnoopHitRead, MesiState.Shared)
                .Permit(MesiTrigger.SnoopHitWrite, MesiState.Invalid);

            stateMachine.Configure(MesiState.Invalid)
                .Permit(MesiTrigger.ReadMissShared, MesiState.Shared)
                .Permit(MesiTrigger.ReadMissExclusive, MesiState.Exclusive)
                .Permit(MesiTrigger.WriteMiss, MesiState.Modified);
        }

        public void ReadHit()
        {
            stateMachine.Fire(MesiTrigger.ReadHit);
        }
        public void WriteHit()
        {
            stateMachine.Fire(MesiTrigger.WriteHit);
        }
        public void ReadMissShared()
        {
            stateMachine.Fire(MesiTrigger.ReadMissShared);
        }
        public void ReadMissExclusive()
        {
            stateMachine.Fire(MesiTrigger.ReadMissExclusive);
        }
        public void WriteMiss()
        {
            stateMachine.Fire(MesiTrigger.WriteMiss);
        }
        public void SnoopHitWrite()
        {
            stateMachine.Fire(MesiTrigger.SnoopHitWrite);
        }
        public void SnoopHitRead()
        {
            stateMachine.Fire(MesiTrigger.SnoopHitRead);
        }


        public MesiState GetCurrentState()
        {
            return stateMachine.State.;
        }
    }
}