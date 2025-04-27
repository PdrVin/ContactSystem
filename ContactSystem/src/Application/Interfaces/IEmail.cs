namespace Application.Interfaces;

public interface IEmail
{
    bool Send(string address, string subject, string message);
}
