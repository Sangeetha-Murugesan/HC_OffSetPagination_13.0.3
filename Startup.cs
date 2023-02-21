
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HotChocolate;

namespace com.ramco.gql.CPOAPI;

public class Startup
{
    public IConfiguration Configuration { get; set; }   
    public ILogger logger { get; set; }    

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        this.Configuration = configuration;       
    }   
    public void ConfigureServices(IServiceCollection services)
    {
       
        services.AddHttpContextAccessor();      
     
        services.AddGraphQLServer()                
                .AddExportDirectiveType()
                .AddDocumentFromString(@"
                    type Query {
                        getOrderDetails : getOrderDetails_out 
                    } 
      
                    type getOrderDetails_out{            
                        getorderDetailsbycustomerNo(customerNo : String!) : getOrderDetails                                       
                    } "
                ).AddFiltering().AddSorting()
                .AddType<getOrderDetails>()
                .AddTypeExtension<getOrderDetailsExtn>()                
                .AddResolver("Query", "getOrderDetails", t => t.Resolver<CPOAPI_getOrderDetails>().getOrderDetails_out(t).Result)
                ;       
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        try
        {         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();          
                     
                
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapGraphQL();              
            });

            app.UsePlayground("/graphql", "/playground");
        }
        catch (Exception Ex)
        {           
            throw;
        }
    }   
    

}
