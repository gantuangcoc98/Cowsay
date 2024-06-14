namespace Class;

public class Cowsay
{
    public event EventHandler<string> Reply;
    
    private string Message = "";

    public void Say(string? Message)
    {
        if (Message is null)
            return;
        
        this.Message = Message;

        Reply(this, this.Message);
    }

}