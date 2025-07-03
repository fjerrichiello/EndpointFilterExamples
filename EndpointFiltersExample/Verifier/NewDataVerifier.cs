namespace EndpointFiltersExample.Verifier;

public class NewDataVerifier : AuthorizedRequestVerifier<NewData>
{
    protected override void AuthorizationRules()
    {
        throw new NotImplementedException();
    }

    protected override void ValidationRules()
    {
        throw new NotImplementedException();
    }
}