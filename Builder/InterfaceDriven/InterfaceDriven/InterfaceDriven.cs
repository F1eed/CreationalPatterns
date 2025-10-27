var email = Email.Builder.WithAddress("asd").Build();

public class Email
{
    public required string Address { get; init; }
    public required string Subject { get; init; }
    public required string Body { get; init; }

    public static IEmailAddressBuilder Builder
        => new EmailBuilder();

    private class EmailBuilder : IEmailAddressBuilder, IEmailBuilder
    {
        private string? _address;
        private string? _subject;
        private string? _body;
        
        public IEmailBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public IEmailBuilder WithSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public IEmailBuilder WithBody(string body)
        {
            _body = body;
            return this;
        }

        public Email Build()
        {
            return new Email
            {
                Address = _address,
                Subject = _subject,
                Body = _body,
            };
        }
    }
}

public interface IEmailBuilder
{
    IEmailBuilder WithSubject(string subject);
    IEmailBuilder WithBody(string body);
    Email Build();
}

public interface IEmailAddressBuilder
{
    IEmailBuilder WithAddress(string address);
}