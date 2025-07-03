using FluentValidation;
using FluentValidation.Results;

namespace EndpointFiltersExample.Verifier;

public abstract class AuthorizedRequestVerifier<TUnverifiedData> :
    AbstractValidator<TUnverifiedData>,
    IAuthorizedRequestVerifier<TUnverifiedData>
{
    protected AuthorizedRequestVerifier()
    {
        RuleSet("Authorize", AuthorizationRules);
        RuleSet("Validate", ValidationRules);
    }

    protected abstract void AuthorizationRules();
    protected abstract void ValidationRules();

    public ValidationResult Authorize(
        TUnverifiedData parameters)
    {
        var result = this.Validate(parameters, options => options.IncludeRuleSets("Authorize"));

        return result;
    }

    public ValidationResult ValidateInternal(
        TUnverifiedData parameters)
    {
        return this.Validate(parameters, options => options.IncludeRuleSets("Validate"));
    }
}