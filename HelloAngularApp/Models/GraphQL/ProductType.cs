using GraphQL.Types;
using HelloAngularApp.Models.Entities;

namespace HelloAngularApp.Models.GraphQL;

public class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Price);
    }
}