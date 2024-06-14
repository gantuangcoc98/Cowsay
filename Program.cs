using System.Diagnostics;
using Class;

Console.Write("Enter input: ");
string? input = Console.ReadLine();

var cowsay = new Cowsay();
cowsay.Reply += OnReply;
cowsay.Say(input);

static void OnReply(object sender, string e)
{
    var cowsayProcess = new Process()
    {
        StartInfo = new ProcessStartInfo()
        {
            FileName = "cowsay",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        }
    };

    cowsayProcess.Start();
    cowsayProcess.StandardInput.WriteLine(e);
    cowsayProcess.StandardInput.Close();

    Console.WriteLine(cowsayProcess.StandardOutput.ReadToEnd());
}