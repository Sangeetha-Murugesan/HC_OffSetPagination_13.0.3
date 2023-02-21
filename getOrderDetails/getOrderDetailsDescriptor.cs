

using HotChocolate.Types;

namespace com.ramco.gql.CPOAPI;    

public class getOrderDetails_out{ }

public class getOrderDetailsExtn : ObjectTypeExtension<getOrderDetails_out>
{
    protected override void Configure(IObjectTypeDescriptor<getOrderDetails_out> descriptor)
    {
        
        descriptor.Field("getorderDetailsbycustomerNo").Description("Fetch the Order Details based on customer #").ResolveWith<CPOAPI_getOrderDetails>(r => r.getorderDetailsbycustomerNo(default));
    }
}
      