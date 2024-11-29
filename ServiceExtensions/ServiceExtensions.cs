namespace WebDiningRoom.ServiceExtensions
{
    public static class ServiceExtensions
    {



        public static void AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "front-end-cors-policy",
                    policy =>
                    {
                        //policy.WithOrigins("https://localhost:4200",
                        //                    "http://localhost:4200");
                        policy.WithOrigins("https://localhost:5173",
                                           "http://localhost:5173");
                        //policy.WithOrigins("https://localhost:7293",
                        //                  "http://localhost:7293");
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    });
            });
        }
    }
}
