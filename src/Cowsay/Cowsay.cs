using System.Diagnostics;

namespace Class;

public class Cowsay
{

    public event Action? Reply;
    
    public void Say()
    {
        Reply?.Invoke();
    }

    public static string StdOut()
    {
        var cowsay = new Process()
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

        cowsay.Start();
        cowsay.StandardInput.WriteLine(Console.ReadLine());
        cowsay.StandardInput.Close();

        return cowsay.StandardOutput.ReadToEnd();
    }

}