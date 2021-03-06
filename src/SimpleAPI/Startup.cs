using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleAPI.CustomRouting;
using SimpleAPI.Repositories;

namespace SimpleAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // if (Environment.IsDevelopment())
            //     services.AddTransient<IPaymentService, PaymentService>();
            // else
            //     services.AddTransient<IPaymentService, ExternalPaymentService>();

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("currency", typeof(CurrencyConstraint));
            });

            services.AddSingleton<IOrderRepository, MemoryOrderRepository>();
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseSampleMiddleware();

            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello, World!");
            // });

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");
            //     endpoints.MapControllerRoute("order", "order/givemeorders", new {controller = "Order", action = "Get"});
            //     endpoints.MapGet("order", context => context.Response.WriteAsync("Hi, from GET verb!"));
            //     endpoints.MapPost("order", context => context.Response.WriteAsync("Hi, from POST verb!"));
            // });

            // app.UseEndpoints(endpoints =>
            // {
                // endpoints.MapControllerRoute("default", "{controller}/{action}");
                // endpoints.MapControllerRoute("default", "{controller}/{action}/{id:guid?}");
                // endpoints.MapControllerRoute("default", "{controller}/{action}/{currency}");
            // });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}