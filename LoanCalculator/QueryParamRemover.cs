using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class QueryParamRemover : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            return;

        var queryParamsToRemove = new List<string> { "InterestRate", "LoanType" };

        foreach (var paramName in queryParamsToRemove)
        {
            var parameterToRemove = operation.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Query && p.Name == paramName);
            if (parameterToRemove != null)
            {
                operation.Parameters.Remove(parameterToRemove);
            }
        }
    }
}
