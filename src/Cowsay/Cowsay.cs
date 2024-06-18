using System.Diagnostics;
using EventArguments;

namespace Class;

public class Cowsay
{

    public event EventHandler<CowsayReplyArgs>? Reply;

    public void Say(string? Message)
    {
        if (string.IsNullOrEmpty(Message))
        {
            Console.Write("Input should not be null or empty.");
            return;
        }
        
        var cowsayProcess = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cowsay",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            }
        };

        cowsayProcess.Start();
        cowsayProcess.StandardInput.WriteLine(Message);
        cowsayProcess.StandardInput.Close();

        CowsayReplyArgs cowsayReplyArgs = new();
        cowsayReplyArgs.Message = cowsayProcess.StandardOutput.ReadToEnd();

        Reply?.Invoke(this, cowsayReplyArgs);
        
        cowsayProcess.WaitForExit();
    }

}