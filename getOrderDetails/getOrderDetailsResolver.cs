

using HotChocolate.Resolvers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.ramco.gql.CPOAPI;
 
public class CPOAPI_getOrderDetails 
{

    IConfiguration _configuration = null;
    public  CPOAPI_getOrderDetails (IConfiguration Configuration)            
    {
        this._configuration = Configuration;                     
    } 
         
    public async Task<Dictionary<string,object>> getOrderDetails_out(IResolverContext res)
    {        
        try
        {                   
            var response = JsonConvert.DeserializeObject<Dictionary<string,object>>("{\"success\":\"success\"}");
            return response;                    
        }
        catch (Exception )
        { 
            throw;
        }          
    }
    public async Task<getOrderDetails> getorderDetailsbycustomerNo(IResolverContext res)
    {
        try
        {
            return null ;             
        }
        catch (Exception)
        {
            throw;
        }

    }   
        
}
