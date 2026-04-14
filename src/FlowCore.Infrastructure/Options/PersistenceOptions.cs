namespace FlowCore.Infrastructure.Options;

/// <summary>
/// Konfiguration des Persistenzproviders.
/// </summary>
public sealed class PersistenceOptions
{
    public const string SectionName = "Persistence";

    /// <summary>
    /// Unterstützt: InMemory, PostgreSql.
    /// </summary>
    public string Provider { get; set; } = "InMemory";

    /// <summary>
    /// Name der zu verwendenden ConnectionStrings-Section.
    /// </summary>
    public string ConnectionStringName { get; set; } = "FlowCore";

    /// <summary>
    /// Erstellt das Schema automatisch beim Start, wenn der Provider PostgreSql aktiv ist.
    /// </summary>
    public bool EnsureCreatedOnStartup { get; set; } = true;
}
