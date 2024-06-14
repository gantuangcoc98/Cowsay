namespace Class;

public class Cowsay
{

    public event EventHandler<string> Reply;
    
    public void Say(string? Message)
    {
        if (Message is null)
            return;

        Reply(this, Message);
    }

}