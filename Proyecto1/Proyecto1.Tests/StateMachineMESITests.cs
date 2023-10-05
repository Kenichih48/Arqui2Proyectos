using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Tests
{
    [TestClass]
    public class StateMachineMESITests
    {
        [TestMethod]
        public void MESITest()
        {
            StateMachineMESI MESI = new StateMachineMESI();

            Assert.IsNotNull(MESI);
            Assert.AreEqual(StateMachineMESI.MesiState.Invalid, MESI.GetCurrentState());

            MESI.WriteHit();
            Assert.AreEqual(StateMachineMESI.MesiState.Modified, MESI.GetCurrentState());

            MESI.SnoopHitRead();
            Assert.AreEqual(StateMachineMESI.MesiState.Shared, MESI.GetCurrentState());

            

        }

    }
}
