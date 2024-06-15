using Class;

Console.Write("Enter input: ");

var cowsay = new Cowsay();
cowsay.Reply += OnReply;
cowsay.Say();

static void OnReply() { Console.WriteLine(Cowsay.StdOut()); }
