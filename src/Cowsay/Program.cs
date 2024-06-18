using Class;
using EventArguments;

Console.Clear();
Console.Write("Tell me what you want to say: ");
string? input = Console.ReadLine();

var cowsay = new Cowsay();
cowsay.Reply += OnReply;
cowsay.Say(input);

static void OnReply(object? sender, CowsayReplyArgs e)
{
    Console.WriteLine(e.Message);
}
