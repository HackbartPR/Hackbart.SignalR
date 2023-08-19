using ClientA;

Console.WriteLine("Cliente A");
await Task.Delay(3000);

await using (Client client = new())
{
    await client.Start();
}



