using System.Buffers;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class ArrayPoolBenchmark
{
    private ArrayPool<int> pool = ArrayPool<int>.Shared;

    [Benchmark]
    public void ProcessWithoutArrayPool()
    {
        int[] array = new int[10000];
        // ... process the array ...
    }

    [Benchmark]
    public void ProcessWithArrayPool()
    {
        int[] rentedArray = pool.Rent(10000);
        // ... process the array ...
        pool.Return(rentedArray);
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ArrayPoolBenchmark>();
    }
}
