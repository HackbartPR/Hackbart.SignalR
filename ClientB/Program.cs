using ClientB;

Console.WriteLine("Cliente B");
await Task.Delay(4000);

await using (Client client = new())
{
    await client.Start();
}



