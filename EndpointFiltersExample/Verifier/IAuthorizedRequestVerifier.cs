using FluentValidation.Results;

namespace EndpointFiltersExample.Verifier;

public interface
    IAuthorizedRequestVerifier<in TUnverifiedData> : IRequestVerifier<
    TUnverifiedData>
{
    ValidationResult Authorize(
        TUnverifiedData parameters);
}