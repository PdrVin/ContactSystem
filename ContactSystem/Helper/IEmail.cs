namespace ContactSystem.Helper;

public interface IEmail
{
    bool Send(string address, string subject, string message);
}
