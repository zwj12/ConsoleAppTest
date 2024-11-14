using System.Threading.Channels;

namespace ConsoleAppTestNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoundedChannelOptions options = new(3)
            {
                FullMode = BoundedChannelFullMode.DropNewest
            };

            var channel = Channel.CreateBounded<int>(options);

            Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1000));
                    await channel.Writer.WriteAsync(i);// 生产者写入消息
                    Console.WriteLine($"Writ: {i}");
                    if (i > 5)
                    {
                        channel.Writer.Complete(); //生产者也可以明确告知消费者不会发送任何消息了
                    }
                }

            });

            Task.Run(async () =>
            {
                await foreach (var item in channel.Reader.ReadAllAsync())//async stream,在没有被生产者明确Complete的情况下，这里会一致阻塞下去
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(3000));
                    Console.WriteLine(item);
                }
                Console.WriteLine("done");
            });

            Console.ReadKey();

            Console.WriteLine("Hello, World!");
        }
    }
}
