namespace SantoAndreOnBus.Api.Infrastructure.Configurations.Sections;

public record AuthenticationSection
{
    public string? Secret { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? ExpirationInHours { get; set; }
}
