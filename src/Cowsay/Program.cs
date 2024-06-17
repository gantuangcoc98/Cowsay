using Class;

Console.Write("Enter input: ");
string? input = Console.ReadLine();

var cowsay = new Cowsay();
cowsay.Reply += OnReply;
cowsay.Say(input);

static void OnReply(object? sender, ReplyEventArgs e)
{
    Console.WriteLine(e.Message);
}
