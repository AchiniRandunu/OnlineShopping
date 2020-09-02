using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.Business;
using OnlineShopping.Business.Implementations;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data;
using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Implementations;
using OnlineShopping.Data.Repositories.Interfaces;
using OnlineShopping.DTO;
using OnlineShoppingWebAPI.Extensions;
using Serilog;
using System;
using System.Text;

namespace OnlineShoppingWebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			//Inject AppSettings
			services.Configure<ApplicationSettingsDTO>(Configuration.GetSection("ApplicationSettings"));

			services.AddDbContext<OnlineShoppingDBContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<OnlineShoppingDBContext>();

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 8;
			}
			);

			services.AddCors();

			//Jwt Authentication

			var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = false;
				x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				};
			});


			//Register automapper service
			services.AddAutoMapper(typeof(AutoMapping));

			//// Inject DataContext
			services.AddScoped<IUnitOfWork, UnitOfWork<OnlineShoppingDBContext>>();

			//// Inject Repository Product  Service
			services.AddScoped<IProductRepository, ProductRepository>();
			//// Inject Product service 
			services.AddScoped<IProductService, ProductService>();
			//// Inject Login service 
			services.AddScoped<ILoginService, LoginService>();
			//// Inject register service 
			services.AddScoped<IRegistrationService, RegistrationService>();
            //// Inject Repository Account  Repository
            services.AddScoped<IAccountRepository, AccountRepository>();
            //// Inject Checkout service 
            services.AddScoped<ICheckoutService, CheckoutService>();
            //// Inject Repository Order  Repository
            services.AddScoped<IOrderRepository, OrderRepository>();
            //// Inject Repository OrderLineItems  Repository
            services.AddScoped<IOrderLineItemsRepository, OrderLineItemsRepository>();
            //// Inject Repository Payment  Repository
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            //// Inject Payment service 
            services.AddScoped<IPaymentService, PaymentService>();

            ///Add Email settings
            services.Configure<MailSettingsDTO>(Configuration.GetSection("MailSettings"));

            ///Add Eamil service
            services.AddTransient<IEmailService, EmailService>();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Shopping API V1");
            });

            app.Use(async (ctx, next) =>
			{
				await next();
				if (ctx.Response.StatusCode == 204)
				{
					ctx.Response.ContentLength = 0;
				}
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder =>
			builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
			.AllowAnyHeader()
			.AllowAnyMethod()

			);
  

            app.UseAuthentication();
			app.UseSerilogRequestLogging();

			//error handling static method injecting
			app.ConfigureExceptionHandler();
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});  

        }
    }
}
