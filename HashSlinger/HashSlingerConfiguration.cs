namespace HashSlinger.Api;

/// <summary>Stores application-wide configuration values.</summary>
/// <remarks>
/// These settings need to be persisted somewhere, but I haven't solved that yet. I'm also not convinced that every one of them is strictly necessary, but I'm keeping them all for now to support implementing Hashtopolis agent compatibility.
/// </remarks>
public static class HashSlingerConfiguration
{
    /// <summary>Gets the benchmark time.</summary>
    /// <value>Time in seconds an agent should benchmark a task.</value>
    public static int BenchmarkTime { get; } = 30;

    /// <summary>Gets the duration of the chunk.</summary>
    /// <value>Time in seconds a client should be working on a single chunk.</value>
    public static int ChunkDuration { get; } = 600;

    /// <summary>Gets the chunk timeout.</summary>
    /// <value>Time in seconds the server will consider an issued chunk as inactive or timed out and will reallocate to another client.</value>
    public static int ChunkTimeout { get; } = 30;

    /// <summary>Gets the agent timeout.</summary>
    /// <value>Time in seconds the server will consider a client inactive or timed out.</value>
    public static int AgentTimeout { get; } = 30;

    /// <summary>Gets the field separator.</summary>
    /// <value>The separator character used to separate hash and plain (or salt).</value>
    public static string FieldSeparator { get; } = ":";

    /// <summary>Gets the hashlist alias.</summary>
    /// <value>The string used as hashlist alias when creating a task.</value>
    public static string HashlistAlias { get; } = "#HL#";

    /// <summary>Gets the status timer.</summary>
    /// <value>Default interval in seconds clients should report back to the server for a task. (cracks, status, and progress).</value>
    public static int StatusTimer { get; } = 5;

    /// <summary>Gets the blacklist chars.</summary>
    /// <value>Characters that are not allowed to be used in attack command inputs.</value>
    public static string BlacklistChars { get; } = "&|`\"'{}()[]$<>;";

    /// <summary>Gets the disp tolerance.</summary>
    /// <value>
    ///   <para>
    /// Allowable deviation in the final chunk of a task in percent.</para>
    ///   <para>(avoids issuing small chunks when the remaining part of a task is slightly bigger than the normal chunk size).</para>
    /// </value>
    public static int DispTolerance { get; } = 20;

    /// <summary>Gets a value indicating whether [default bench].</summary>
    /// <value>Use speed benchmark as default.</value>
    public static bool DefaultBench { get; } = true;

    /// <summary>Gets a value indicating whether [rule split small tasks].</summary>
    /// <value>
    ///   <c>When rule splitting is applied for tasks, always make them a small task.</c>
    /// </value>
    public static bool RuleSplitSmallTasks { get; } = false;

    /// <summary>Gets the rule split always.</summary>
    /// <value>
    ///   <para>
    /// Even do rule splitting when there are not enough rules but just the benchmark is too high.</para>
    ///   <para>Can result in subtasks with just one rule.</para>
    /// </value>
    public static bool RuleSplitAlways { get; } = false;

    /// <summary>Gets the rule split disable.</summary>
    /// <value>Disable automatic task splitting with large rule files.</value>
    public static bool RuleSplitDisable { get; } = true;

    /// <summary>Gets the agent data lifetime.</summary>
    /// <value>Minimum time in seconds how long agent gpu/cpu utilization and gpu temperature data is kept on the server.</value>
    public static int AgentDataLifetime { get; } = 3600;

    /// <summary>Gets a value indicating whether [disable trimming].</summary>
    /// <value>
    ///   <c>Disable trimming of chunks and redo whole chunks.</c>
    /// </value>
    public static bool DisableTrimming { get; } = false;

    /// <summary>Gets a value indicating whether [priority0 start].</summary>
    /// <value>Automatically assign tasks with priority 0.</value>
    public static bool Priority0Start { get; } = true;

    /// <summary>Gets a value indicating whether [hashcat brain enable].</summary>
    /// <value>
    ///   <c>Allow hashcat brain to be used for hashlists</c>
    /// </value>
    public static bool HashcatBrainEnable { get; } = false;

    /// <summary>Gets the hashcat brain host.</summary>
    /// <value>Host to be used for hashcat brain (must be reachable by agents)</value>
    public static string HashcatBrainHost { get; } = string.Empty;

    /// <summary>Gets the hashcat brain port.</summary>
    /// <value>The hashcat brain port.</value>
    public static int HashcatBrainPort { get; } = 0;

    /// <summary>Gets the hashcat brain pass.</summary>
    /// <value>Password to be used to access hashcat brain server</value>
    public static string HashcatBrainPass { get; } = string.Empty;

    /// <summary>Gets a value indicating whether [hashlist import check].</summary>
    /// <value>
    ///   <c>Check all hashes of a hashlist on import in case they are already cracked in another list</c>
    /// </value>
    public static bool HashlistImportCheck { get; } = true;

    /// <summary>Gets a value indicating whether [hc error ignore].</summary>
    /// <value>
    ///   <c>Ignore error messages from crackers which contain given strings (multiple values separated by comma)</c>
    /// </value>
    public static string HcErrorIgnore { get; } = "DeviceGetFanSpeed";
}
