using ClientB;

Console.WriteLine("Cliente B");
await Task.Delay(500);

await using (Client client = new())
{
    await client.Start();
}



