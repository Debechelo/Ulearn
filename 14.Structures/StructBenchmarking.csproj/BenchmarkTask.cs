using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;

namespace StructBenchmarking
{
    public class Benchmark : IBenchmark
	{
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            GC.Collect();                   // Эти две строчки нужны, чтобы уменьшить вероятность того,
            GC.WaitForPendingFinalizers();  // что Garbadge Collector вызовется в середине измерений
                                            // и как-то повлияет на них.

            Stopwatch st = new Stopwatch();

            task.Run();
            
            st.Restart();
            for(int i = 0; i < repetitionCount; i++) { 
                task.Run();
            
            }
            st.Stop();

            return st.Elapsed.TotalMilliseconds / repetitionCount;
		}
	}

    class Builder: ITask {
        public void Run() {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < 10000; i++) {
                stringBuilder.Append('a');
            }
            var str = stringBuilder.ToString();
        }
    }

    class Constr: ITask {
        public void Run() {
            var str = new string('a', 10000);
        }
    }

    [TestFixture] 
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            Benchmark b = new Benchmark();
            var sb = b.MeasureDurationInMs(new Builder(), 10000);
            var st = b.MeasureDurationInMs(new Constr(), 10000);
            Assert.Less(st, sb);
        }
    }
}