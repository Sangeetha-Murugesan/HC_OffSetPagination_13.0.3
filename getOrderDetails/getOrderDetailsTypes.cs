

using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.ramco.gql.CPOAPI;
public partial record getCustOrderDetails
{       
    public string? aircraftModelNo { get; set; }           
    public string? customerName { get; set; }    
    public string? customerNo { get; set; }    
    public string? customerOrderNo { get; set; }   
}

public partial record getOrderDetails
{
    [UseOffsetPaging(IncludeTotalCount =true, InferCollectionSegmentNameFromField =false)] 
    [HotChocolate.Data.UseFiltering]
    [UseSorting]
    public ICollection<getCustOrderDetails>? data { get; set; }   
    public string? message { get; set; }
}