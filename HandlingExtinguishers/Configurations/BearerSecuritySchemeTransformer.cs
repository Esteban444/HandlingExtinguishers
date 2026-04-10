using HandlingExtinguishers.Core.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

public sealed class BearerSecuritySchemeTransformer( IAuthenticationSchemeProvider authenticationSchemeProvider ): IOpenApiDocumentTransformer
{

    public async Task TransformAsync( OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken )
    {
        var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();

        if (authenticationSchemes.Any(s => s.Name == CommonConstants.BearerSchemeName))
        {
            document.Components ??= new OpenApiComponents();

            document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>
            {
                [CommonConstants.BearerSchemeName] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = CommonConstants.BearerSchemeType,
                    BearerFormat = CommonConstants.JwtBearerFormat,
                    In = ParameterLocation.Header,
                    Description = CommonConstants.JwtAuthenticationDescription
                }
            };

            if (document.Paths is null) return;

            foreach (var path in document.Paths.Values)
            {
                foreach (var operation in path.Operations.Values)
                {
                    operation.Security ??= new List<OpenApiSecurityRequirement>();

                    operation.Security.Add(new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecuritySchemeReference(CommonConstants.BearerSchemeName, document)] = new List<string>()
                    });
                }
            }
        }
    }
}