using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Tests
{
    [TestClass]
    public class StateMachineTests
    {
        [TestMethod]
        public void MESITest()
        {
            StateMachine MESI = new StateMachine("MESI");

            Assert.IsNotNull(MESI);
            Assert.AreEqual(StateMachine.State.Invalid, MESI.GetCurrentState());

            MESI.WriteMiss();
            Assert.AreEqual(StateMachine.State.Modified, MESI.GetCurrentState());

            MESI.SnoopHitRead();
            Assert.AreEqual(StateMachine.State.Shared, MESI.GetCurrentState());

            

        }

    }
}
