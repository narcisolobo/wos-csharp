#pragma warning disable CS8618
using SecretPassword.Attributes;

namespace SecretPassword.Models;

public class Password
{
    [ValidPassword("samcooke")]
    public string Content { get; set; }
}
