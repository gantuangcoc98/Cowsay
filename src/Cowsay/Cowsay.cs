using System.Diagnostics;

namespace Class;

public class Cowsay
{

    public event EventHandler<ReplyEventArgs>? Reply;
    
    public void Say(string? Message)
    {
        if (Message is null)
            return;
        
        ReplyEventArgs replyEventArgs = new();
        replyEventArgs.Process(Message);

        Reply?.Invoke(this, replyEventArgs);
    }

}

public class ReplyEventArgs : EventArgs
{

    public string? Message { get; set; }

    public void Process(string? Message)
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
        cowsay.StandardInput.WriteLine(Message);
        cowsay.StandardInput.Close();

        this.Message = cowsay.StandardOutput.ReadToEnd();

        bool exited = cowsay.WaitForExit(0);
        if (!exited)
        { 
            cowsay.Kill(); 
        }
    }
}