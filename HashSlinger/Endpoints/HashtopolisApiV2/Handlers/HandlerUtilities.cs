namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

internal static class HandlerUtilities
{
    internal static bool IsInvalidSpeedBenchmarkValue(string[] benchmarkStrings)
    {
        return benchmarkStrings.Length > 2
               || string.IsNullOrEmpty(benchmarkStrings[0])
               || string.IsNullOrEmpty(benchmarkStrings[1])
               || !double.TryParse(benchmarkStrings[0], out _)
               || !double.TryParse(benchmarkStrings[1], out _);
    }
}
