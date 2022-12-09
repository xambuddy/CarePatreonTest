using CarePatreonTest.API.AppStart;
using CarePatreonTest.API.Hubs;
using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Extensions;
using CarePatreonTest.Application.Profiles;
using CarePatreonTest.Infrastructure.Extensions;
using CarePatreonTest.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System.Text.Json;
using System.Transactions;

namespace CarePatreonTest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.Configuration = configuration;
            this.WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarePatreonTest.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notificationHub");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                o.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddAutoMapper(typeof(ClientProfile));

            services.AddCosmosRepository(options =>
            {
                options.CosmosConnectionString = this.Configuration.GetSection("CosmosConnectionString").Get<string>();
                options.DatabaseId = "carepatreontest";
                options.ContainerPerItemType = true;
                options.IsAutoResourceCreationIfNotExistsEnabled = true;
            });

            services.AddSingleton<IUserIdProvider, UserIdProvider>();
            services.AddMediatR(typeof(Transaction), typeof(CreateClientCommand));

            services.ConfigureAuthentication(this.Configuration);

            services.AddInfrastructure(this.Configuration);
            services.AddApplication();

            services.ConfigureSwagger(this.Configuration, this.WebHostEnvironment);
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        if (this.WebHostEnvironment.IsDevelopment())
                        {
                            builder.WithOrigins("http://localhost:3000")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                        }
                        else
                        {
                            builder.WithOrigins("https://*.carepatreon.com")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                        }
                    });
            });
            services
            .AddControllers(o =>
            {
                o.Filters.Add(new ApiExceptionFilterAttribute());
            })
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    o.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    o.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddSignalR()
            .AddJsonProtocol(p =>
            {
                p.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                p.PayloadSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                p.PayloadSerializerOptions.PropertyNameCaseInsensitive = true;
                p.PayloadSerializerOptions.WriteIndented = true;
            })
            .AddAzureSignalR();

            services.AddEndpointsApiExplorer();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
        }
    }
}
