namespace WebApi.Models.Email;

public class EmailRequest
{
    public string Email { get; set; }
    public int Type { get; set; }
    public string Sub { get; set; }
    public string FromName { get; set; }
}

public class EmailModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Html { get; set; }
    public string From { get; set; }
}